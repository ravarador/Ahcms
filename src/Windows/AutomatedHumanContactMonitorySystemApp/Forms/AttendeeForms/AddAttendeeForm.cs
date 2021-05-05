using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms
{
    public partial class AddAttendeeForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public AddAttendeeForm(IAttendeeRepository attendeeRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
        }

        private void AddAttendeeForm_Load(object sender, EventArgs e)
        {
            LoadGridViewAttendees();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAttendee();
            LoadGridViewAttendees();
        }




        #region helpers

        private void LoadGridViewAttendees()
        { 
            dataGridView1.DataSource = GetAttendees(); 
        }

        private List<Attendee> GetAttendees()
        {
            var attendees = AttendeeRepository.GetAttendees();
            return attendees.ToList();
        }
        private Attendee GetAttendee(int id)
        {
            var attendee = AttendeeRepository.GetAttendee(id);
            return attendee;
        }

        private void AddAttendee() 
        {
            var attendeeToAdd = new Attendee()
            {
                Id = int.Parse(txtRFID.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Age = int.Parse(txtAge.Text),
                AttendeeRFID = long.Parse(txtRFID.Text),
                Status = "NORMAL",
                ContactNumber = txtContactNumber.Text
            };

            var message = AttendeeRepository.PostAttendee(attendeeToAdd);
            MessageBox.Show(message);
        }

        #endregion helpers

    }
}
