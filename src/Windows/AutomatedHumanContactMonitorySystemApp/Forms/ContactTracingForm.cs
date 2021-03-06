using AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using Sharer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms
{
    public partial class ContactTracingForm : Form
    {
        bool isTimerRunning = true;
        string rfidValue = string.Empty;
        string bodytempValue = string.Empty;
        string proximityValue = string.Empty;
        int selectedAttendeeId = 0;
        string selectedAttendeeStatus;

        private SharerConnection connection = new SharerConnection("COM6", 9600);
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public ContactTracingForm()
        {
            InitializeComponent();
        }

        #region Helpers Repository

        public void LoadRepositories(IAttendanceRepository attendanceRepository, IAttendeeRepository attendeeRepository, IPlaceRepository placeRepository)
        {
            AttendanceRepository = attendanceRepository;
            AttendeeRepository = attendeeRepository;
            PlaceRepository = placeRepository;
        }

        #endregion Helpers Repository

        #region Helpers Attendance
        private void LoadGridViewAttendances()
        {
            //dgvAttendance.DataSource = GetAttendances();
        }

        private List<AttendanceDto> GetAttendances()
        {
            var attendances = AttendanceRepository.GetAttendances();
            return attendances.ToList();
        }

        private void AddAttendance()
        {
            var attendanceToAdd = new Attendance()
            {
                VisitedDateTime = DateTime.Now,
                Temperature = double.Parse(txtTemperature.Text),
                AttendeeId = selectedAttendeeId,
                Status = selectedAttendeeStatus,
                PlaceId = Helpers.PlaceHelper.PlaceId
            };

            AttendanceRepository.PostAttendance(attendanceToAdd);
        }

        #endregion Helpers Attendance

        #region Helpers Attendee

        private List<Attendee> GetAttendees()
        {
            var attendees = AttendeeRepository.GetAttendees();
            return attendees.ToList();
        }

        #endregion Helpers Attendee

        #region Helpers Place

        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }

        #endregion Helpers Place

        #region Helpers Timer
        private void TimerTick()
        {
            try
            {
                if (!connection.Connected)
                {
                    connection.Connect();
                    // Scan all functions shared
                    connection.RefreshFunctions();
                    connection.RefreshVariables();
                }

                if (isTimerRunning)
                {
                    rfidValue = connection.Call("returnRfid").Value.ToString(); //ok
                    txtAttendeeRFID.Text = rfidValue.ToString().PadLeft(10, '0'); //ok

                    var attendees = GetAttendees().Where(a => a.AttendeeRFID.ToString() == rfidValue &&
                                                              a.AttendeeRFID.ToString() != "0" &&
                                                              a.AttendeeRFID.ToString() != string.Empty);
                    var isRfidRegistered = attendees.Any();

                    if (!isRfidRegistered && txtAttendeeRFID.Text != "0000000000" && txtAttendeeRFID.Text != "")
                    {
                        //connectionTimer.Stop();
                        //var addAttendeeForm = new AddAttendeeForm(AttendeeRepository);
                        //addAttendeeForm.FormClosed += AddAttendeeForm_FormClosed;
                        //addAttendeeForm.txtRFID.Enabled = false;
                        //addAttendeeForm.txtRFID.Text = rfidValue;
                        //addAttendeeForm.ShowDialog();
                        btnAdd.Text = "RFID Not Registered";
                        connection.WriteVariable("i", 5);
                        Thread.Sleep(2000);
                        AutomaticReset();

                    }
                    else if (isRfidRegistered)
                    {
                        txtName.Text = attendees.SingleOrDefault().Name;
                        txtAge.Text = attendees.SingleOrDefault().Age.ToString();
                        txtAddress.Text = attendees.SingleOrDefault().Address;

                        selectedAttendeeId = attendees.SingleOrDefault().Id;
                        selectedAttendeeStatus = attendees.SingleOrDefault().Status;

                        if (selectedAttendeeStatus == "POSITIVE")
                        {
                            btnAdd.Text = "POSITIVE";
                            connection.WriteVariable("i", 4);
                            Thread.Sleep(2000);
                            AutomaticReset();
                        }
                        else if (selectedAttendeeStatus == "PUI")
                        {
                            btnAdd.Text = "PUI";
                            connection.WriteVariable("i", 3);
                            Thread.Sleep(2000);
                            AutomaticReset();
                        }
                    }

                    //txtName.Enabled = !isRfidRegistered;
                    //txtAge.Enabled = !isRfidRegistered;
                    //txtAddress.Enabled = !isRfidRegistered;
                }


                if (txtAttendeeRFID.Text != "0000000000" && txtAttendeeRFID.Text != "") //ok
                {
                    if (isTimerRunning)
                    {
                        connection.WriteVariable("i", 2);
                        //connection.Call("modifyI", 2);
                    }

                    isTimerRunning = false; //ok

                    proximityValue = connection.Call("returnProximity").Value.ToString();

                    if (proximityValue == "0")
                    {
                        bodytempValue = connection.Call("returnTemperature").Value.ToString(); //ok

                        txtTemperature.Text = bodytempValue;

                        btnAdd.PerformClick();
                    }
                    else
                    {
                        txtTemperature.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion Helpers Timer

        #region Helpers UserControl

        public void LoadUserControl()
        {
            if (!connection.Connected)
                connection.Connect();
            connection.WriteVariable("i", 0);
            connectionTimer.Start();
            isTimerRunning = true;
        }

        public void UnloadUserControl()
        {
            
            isTimerRunning = false;
            if (connection.Connected)
                connection.Disconnect();

            connectionTimer.Stop();
            //this.Close();
            
            //connection.Disconnect();

            //connectionTimer.Stop();
        }
        public void AutomaticReset()
        {
            ResetFields();
            UnloadUserControl();
            LoadUserControl();
        }

        #endregion Helpers UserControl

        private void ResetFields()
        {
            txtAddress.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtAttendeeRFID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTemperature.Text = string.Empty;
            btnAdd.Text = string.Empty;

            rfidValue = "";
            bodytempValue = string.Empty;
            proximityValue = string.Empty;
            selectedAttendeeId = 0;
        }

        private void ContactTracingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double temperature = double.Parse(txtTemperature.Text);

            if (temperature > 38)
            {
                btnAdd.Text = "Not allowed to enter due to high temperature.";
                Thread.Sleep(2000);
                AutomaticReset();

            }
            else
            {
                AddAttendance();
                btnAdd.Text = "";
                //LoadGridViewAttendances();
                Thread.Sleep(2000);

                connection.WriteVariable("i", 0);

                AutomaticReset();
            }
        }

        private void connectionTimer_Tick(object sender, EventArgs e)
        {
            TimerTick();
        }
        private void AddAttendeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var attendees = GetAttendees().Where(a => a.AttendeeRFID.ToString() == rfidValue &&
                                         a.AttendeeRFID.ToString() != "0" &&
                                         a.AttendeeRFID.ToString() != string.Empty);

            var isRfidRegistered = attendees.Any();

            if (isRfidRegistered)
            {
                txtName.Text = attendees.SingleOrDefault().Name;
                txtAge.Text = attendees.SingleOrDefault().Age.ToString();
                txtAddress.Text = attendees.SingleOrDefault().Address;

                selectedAttendeeId = attendees.SingleOrDefault().Id;
                selectedAttendeeStatus = attendees.SingleOrDefault().Status;
            }

            connectionTimer.Start();
        }

        private void ContactTracingForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            connection.WriteVariable("i", 0);
            UnloadUserControl();
            this.Close();
            
        }
    }
}
