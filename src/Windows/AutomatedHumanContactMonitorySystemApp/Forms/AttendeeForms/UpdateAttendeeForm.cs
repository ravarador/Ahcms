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
    public partial class UpdateAttendeeForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public UpdateAttendeeForm(IAttendeeRepository attendeeRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
        }

        private void UpdateAttendeeForm_Load(object sender, EventArgs e)
        {
            LoadGridViewAttendees();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtAge.Text = row.Cells[2].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PutAttendee();
            LoadGridViewAttendees();
        }

        #region

        private void PutAttendee() 
        {
            var attendeeToUpdate = new Attendee()
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Age = int.Parse(txtAge.Text)
            };
            AttendeeRepository.PutAttendee(attendeeToUpdate);
        }


        private void LoadGridViewAttendees()
        {
            dataGridView1.DataSource = GetAttendees();
        }

        private List<Attendee> GetAttendees()
        {
            var attendees = AttendeeRepository.GetAttendees();
            return attendees.ToList();
        }





        #endregion

        
    }
}
