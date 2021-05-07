# Automated Human Contact Monitoring System (AHCMS)

What is <b>AHCMS</b>?
A contact tracing solution to the rising number of Covid-19 cases in the Philippine. In every establishment that utilizes AHCMS, processing time
of information gathering is significantly shorter than manually inputting data of each visitor.

<hr>

## How to setup?

### ARDUINO SETUP

#### Arduino Wiring Diagram
![image](https://user-images.githubusercontent.com/41227131/117397394-9fd7ab80-af2e-11eb-80c9-8b982764143f.png)

##### <i> After setting up the Arduino hardware, compile and upload the code to the Arduino. </i>


### API SETUP

##### 1. Go to your appsettings.json file then edit your connection string.

```c#
"AhcmsContext": "Data Source=InsertYourServerNameHere; Initial Catalog=AhcmsContext;"
```

##### 2. Run your Package Manager Console and execute the following code:
###### <i>This code creates migrations for your API database. </i>
``` c#
add-migration InitialDb
```
###### <i>This code runs the migration code then updates the database. </i>
``` c#
dotnet ef database update --startup-project AhcmsAPI --context AhcmsContext
```
##### 3. Setup for API is complete. You can now run the API and copy the API address to be used in setting up the windows application.



### WINDOWS APPLICATION SETUP

##### 1. Go to solution explorer. Right click the project then select properties.
##### 2. In the properties page, select the Settings tab. You will find the ApiAddress settings there.
![image](https://user-images.githubusercontent.com/41227131/117402976-02827480-af3a-11eb-8c56-449b688cb5a9.png)
##### 3. Change its value to the API address you have right now. Make sure API is running when you run the windows application.

## User Interface

### COMMON MODULE

##### Login page
![image](https://user-images.githubusercontent.com/41227131/117114981-1190e780-adbf-11eb-9b7b-7984a2115fb8.png)

##### Dashboard tab
![image](https://user-images.githubusercontent.com/41227131/117115037-25d4e480-adbf-11eb-8545-d26383fbc281.png)

### ADMIN MODULE

##### Admin tab
![image](https://user-images.githubusercontent.com/41227131/117115721-1609d000-adc0-11eb-974d-1f2fa41fabac.png)

##### Register tab
![image](https://user-images.githubusercontent.com/41227131/117115120-3f762c00-adbf-11eb-954f-0dcc8b2752d9.png)
