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
    public partial class DeleteAttendeeForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public DeleteAttendeeForm(IAttendeeRepository attendeeRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
        }

        private void DeleteAttendeeForm_Load(object sender, EventArgs e)
        {

            LoadGridViewAttendees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAttendee(int.Parse(lblId.Text));
            LoadGridViewAttendees();  
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            lblId.Text = row.Cells[0].Value.ToString();
            lblName.Text = row.Cells[1].Value.ToString();
            lblAge.Text = row.Cells[2].Value.ToString();
            lblAddress.Text = row.Cells[3].Value.ToString();
            
        }


        #region
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

        private void DeleteAttendee(int id)
        {
            AttendeeRepository.DeleteAttendee(id);
        }

        


        #endregion

       
    }
}
