#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <Adafruit_MLX90614.h>
#include <SoftwareSerial.h>
#include <hidboot.h>
#include <usbhub.h>
#ifdef dobogusinclude
#include <spi4teensy3.h>
#endif
#include <SPI.h>
#include <Sharer.h>
#include <avr/wdt.h>


#define I2C_ADDR 0x5A //I2C Address for mlx90614
Adafruit_MLX90614 mlx = Adafruit_MLX90614();

LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);

int IRSensor = 3;             //digital pin for proximity sensor
int RFIDSwitch = 4;                //digital pin for ON/OFF for the RFID reader
int RedLED = 5;
int GreenLED = 6;
int resetPin = 12;            //pin for resetting the arduino (used with the watchdog)
float bodytemp = 0;           //temperature variable
float threshold = 1.0152;//3.35;                        //difference between real temp reading and the temp sensor reading
int num[10];                  //RFID array
long rfid;                //RFID long
int count = 0;                     //counter for the number of input from the RFID before switching case
int i = 1;                         //switch...case variable
int statusSensor;
int VariableChanged;
//float avg;
//bool IsAverageDone = false;
bool isTempMeasured = false;
const int voltageInputPin = A0;
const float arduinoVoltage = 3.3;
float tempObjecC;

int period = 2000;
unsigned long time_now = 0;

byte verticalLine[8] = {                   //Create special characters for the LCD
  B00100,
  B00100,
  B00100,
  B00100,
  B00100,
  B00100,
  B00100,
  B00100
};

byte char2[8] = {
  B00000,
  B00000,
  B00000,
  B11100,
  B00100,
  B00100,
  B00100,
  B00100
};

byte char1[8] = {
  0b00000,
  0b00000,
  0b00000,
  0b00111,
  0b00100,
  0b00100,
  0b00100,
  0b00100
};

byte char3[8] = {
  0b00100,
  0b00100,
  0b00100,
  0b00111,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};

byte char4[8] = {
  0b00100,
  0b00100,
  0b00100,
  0b11100,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};
byte char5[8] = {
  0b00011,
  0b00011,
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b00000,
  0b00000
};

void printFrame() {                        //Print the frame in the LCD
  int column;
  int row;
  lcd.setCursor(0, 0);
  lcd.write(byte(1));
  lcd.setCursor(19, 0);
  lcd.write(byte(2));
  lcd.setCursor(0, 3);
  lcd.write(byte(3));
  lcd.setCursor(19, 3);
  lcd.write(byte(4));
  for (column = 0; column <= 19; column = column + 19) {
    for (row = 1; row <= 2; row++) {
      lcd.setCursor(column, row);
      lcd.write(byte(0));
    }
  }
  for (row = 0; row <= 3; row = row + 3) {
    for (column = 1; column <= 18; column++) {
      lcd.setCursor(column, row);
      lcd.print('-');

    }
  }
}
void refresh() {             //refresh the lcd
  lcd.clear();
  printFrame();
}

void lcdRFID() {
  lcd.setCursor(4, 1);
  lcd.print("Waiting for");
  lcd.setCursor(6, 2);
  lcd.print("RFID...");
}

void lcdTemperature() {
  lcd.setCursor(4, 1);
  lcd.print("Temperature:");

  if (statusSensor == 0 && isTempMeasured == true) {                    //if within proximity
    if (bodytemp >= 38) {                    // if high temperature
      //refresh();
      lcd.setCursor(4, 2);
      lcd.print("Cannot Enter");
      //delay(2000);
      digitalWrite(RedLED, HIGH);
    }

    else {

      lcd.setCursor(5, 2);
      lcd.print(bodytemp);
      lcd.write(byte(5));
      lcd.print("C");

      //Serial.print(bodytemp);
      //i=1;
      digitalWrite(GreenLED, HIGH);
    }
  }
  else {

  }
  //delay(2000);
}

void lcdPUI() {
  lcd.setCursor(8, 1);
  lcd.print("PUI");
  lcd.setCursor(4, 2);
  lcd.print("Cannot Enter");
}

void lcdPositive() {
  lcd.setCursor(6, 1);
  lcd.print("POSITIVE");
  lcd.setCursor(4, 2);
  lcd.print("Cannot Enter");
}

void lcdNotRegistered() {
  lcd.setCursor(9, 1);
  lcd.print("RFID");
  lcd.setCursor(4, 2);
  lcd.print("Not Registered");
}

//void Average() {                              //Perform average reading of the Temperature Sensor
//  for (int a = 0; a < 10; a++) {
//    avg = avg + mlx.readObjectTempC();
//  }
//  bodytemp = (avg / 10) + threshold;
// IsAverageDone = true;
//}

void dependancyComp() {
  int value = analogRead(voltageInputPin);
  float voltage =  value * (arduinoVoltage / 1023.0);
  while (tempObjecC < 36.1) {

  }
  tempObjecC = tempObjecC - (voltage - 3) * 0.6;
}

void TempMeasurement() {
  dependancyComp();
  bodytemp = tempObjecC * threshold;
  isTempMeasured = true;
}



class KbdRptParser : public KeyboardReportParser //define what task the usb host must carry out
{
    void PrintKey(uint8_t mod, uint8_t key);

  protected:


    void OnKeyDown  (uint8_t mod, uint8_t key);
    void OnKeyPressed(uint8_t key);
};

void KbdRptParser::OnKeyDown(uint8_t mod, uint8_t key)
{

  uint8_t c = OemToAscii(mod, key);

  if (c)
    OnKeyPressed(c);

}

void KbdRptParser::OnKeyPressed(uint8_t key)
{
  if (rfid == 0) {
    if (count < 10) {             //read exactly 10 inputs before proceeding to the next task
      num[count] = (int)key - 48;
      count++;
    }
    else {
      for (int a = 0; a < 10; a++) { //convert the array into a long variable (leading zero are not displayed need to be fixed on c# code)
        rfid = rfid * 10;
        rfid = rfid + num [a];

      }
      //Serial.print(rfid);         // print in the serial monitor rfid number (without leading zeroes)
      //i = 2;                    //switch to reading temperature case

    }
  }
}



USB     Usb;
//USBHub     Hub(&Usb);
HIDBoot<USB_HID_PROTOCOL_KEYBOARD>    HidKeyboard(&Usb);

KbdRptParser Prs;
void setup() {
  pinMode(RFIDSwitch, OUTPUT);
  pinMode(IRSensor, INPUT);
  pinMode(RedLED, OUTPUT);
  pinMode(GreenLED, OUTPUT);

  lcd.begin(20, 4);
  mlx.begin();
  Sharer.init(9600);

 // wdt_enable(WDTO_4S);

#if !defined(__MIPSEL__)
  while (!Serial);                    // Wait for serial port to connect - used on Leonardo, Teensy and other boards with built-in USB CDC serial connection
#endif

  if (Usb.Init() == -1)
    Serial.println("OSC did not start.");

  //delay( 200 );

  HidKeyboard.SetReportParser(0, &Prs);

  lcd.begin(20, 4);
  lcd.createChar(0, verticalLine);
  lcd.createChar(1, char1);
  lcd.createChar(2, char2);
  lcd.createChar(3, char3);
  lcd.createChar(4, char4);
  lcd.createChar(5, char5);
  printFrame();

  Sharer_ShareVariable(long, rfid);
  Sharer_ShareVariable(float, bodytemp);
  Sharer_ShareVariable(int, i);
  Sharer_ShareVariable(int, statusSensor);

  Sharer_ShareFunction(long, returnRfid);
  Sharer_ShareFunction(float, returnTemperature);
  Sharer_ShareFunction(int, returnProximity);
}

long returnRfid() {
  return rfid;
}

float returnTemperature() {
  return bodytemp;
}

int returnProximity() {
  return statusSensor;
}

void Reset() {                         //Reset Variables
  //i = 1;
  bodytemp = 0;
  rfid = 0;
  count = 0;
  isTempMeasured = false;

  //avg = 0;
  digitalWrite(RedLED, LOW);
  digitalWrite(GreenLED, LOW);
  for (int Clear = 0; Clear < 10; Clear ++) {
    num[Clear] = "";
  }
}


void CheckCase() {                        //Refresh the LCD everytime it changes a case
  if (VariableChanged != i) {
    refresh();
    VariableChanged = i;
  }
}


void loop() {
  time_now = millis();
  Sharer.run();
  Usb.Task();

  statusSensor = digitalRead (IRSensor);  //initialize proximity sensor

  tempObjecC = mlx.readObjectTempC();

  if (i == 1 ) {                               //function for turning ON/OFF the rfid sensor
    digitalWrite(RFIDSwitch, HIGH);

  }
  else {
    digitalWrite(RFIDSwitch, LOW);
  }

  //if (count == 0 || count == 10) {            //reset the program if an error during the reading of an RFID occurs (sometimes not all the 10 digits are read, causing the program to stall)
    //wdt_reset();
  //} 


  switch (i) {
    case 0:                                   //case waiting for the c# app use between cases while the app process the data
      Reset();
      //CheckCase();
      //while ( millis() < time_now + period) {
      //}
      i = 1;
      break;

    case 1:                                        //Case for reading the RFID
      CheckCase();
      lcdRFID();
      break;

    case 2:                                        //Case for measuring the temperature
      CheckCase();
      lcdTemperature();
      if (isTempMeasured == false && statusSensor == 0) {
        TempMeasurement();
      }
      break;
    case 3:
      CheckCase();
      lcdPUI();
      digitalWrite(RedLED, HIGH);
      break;
    case 4:
      CheckCase();
      lcdPositive();
      digitalWrite(RedLED, HIGH);
      break;
    case 5:
      CheckCase();
      //lcdNotRegistered();
      lcd.setCursor(8, 1);
      lcd.print("RFID");
      lcd.setCursor(3, 2);
      lcd.print("Not Registered");
      digitalWrite(RedLED, HIGH);
  }
}
