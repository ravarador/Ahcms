using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using AutomatedHumanContactMonitorySystemApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharer;
using AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendanceForms
{
    public partial class AddAttendanceForm : Form
    {
        bool isTimerRunning = true;
        string rfidValue = string.Empty;
        string bodytempValue = string.Empty;
        string proximityValue = string.Empty;
        int selectedAttendeeId = 0;

        private SharerConnection connection = new SharerConnection("COM6", 9600);
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public AddAttendanceForm(IAttendanceRepository attendanceRepository, IAttendeeRepository attendeeRepository, IPlaceRepository placeRepository)
        {
            InitializeComponent();
            AttendanceRepository = attendanceRepository;
            AttendeeRepository = attendeeRepository;
            PlaceRepository = placeRepository;
        }

        private void AddAttendanceForm_Load(object sender, EventArgs e)
        {
            LoadGridViewAttendances();
            timer1.Start();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double temperature = double.Parse(txtTemperature.Text);

            if (temperature > 38)
            {
                string message1 = "Fever";
                MessageBox.Show(message1);
            }
            else
            {
                AddAttendance();
                LoadGridViewAttendances();
            }

            //connection.WriteVariable("i", 1);
        }

        #region Helpers Attendance

        private void LoadGridViewAttendances()
        {
            dataGridView1.DataSource = GetAttendances();
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
                PlaceId = 1
            };

            AttendanceRepository.PostAttendance(attendanceToAdd);
        }

        #endregion Helpers
        #region Helpers Attendee

        private List<Attendee> GetAttendees()
        {
            var attendees = AttendeeRepository.GetAttendees();
            return attendees.ToList();
        }
 
        #endregion
        #region Helpers Place

        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
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
                    timer1.Stop();
                    var addAttendeeForm = new AddAttendeeForm(AttendeeRepository);
                    addAttendeeForm.FormClosed += AddAttendeeForm_FormClosed;
                    addAttendeeForm.txtRFID.Enabled = false;
                    addAttendeeForm.txtRFID.Text = rfidValue;
                    addAttendeeForm.ShowDialog();
                }
                else if (isRfidRegistered)
                {
                    txtName.Text = attendees.SingleOrDefault().Name;
                    txtAge.Text = attendees.SingleOrDefault().Age.ToString();
                    txtAddress.Text = attendees.SingleOrDefault().Address;

                    selectedAttendeeId = attendees.SingleOrDefault().Id;
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
                    //bodytempValue = connection.ReadVariable("bodytemp").Value.ToString(); //ok
                    txtTemperature.Text = bodytempValue;
                }
                else
                {
                    txtTemperature.Text = string.Empty;
                }

            }

            //try
            //{
            //    if (isTimerRunning)
            //    {

            //    }

            //    if (value.ToString() != "0" || value.ToString() != "")
            //    {
            //        isTimerRunning = false;



            //        var runFunctionChangeVariableIToNum = connection.WriteVariable("i", 2);

            //        connection.WriteVariable("rfid", 0);
            //    }

            //}
            //catch(Exception ex)
            //{

            //}


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
            }

            timer1.Start();
        }
    }
}
