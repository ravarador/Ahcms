using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms
{
    public partial class SetAttendeeStatusByDateForm : Form
    {
        private IAttendeeRepository AttendeeRepository { get; set; }
        private AdminUserControl AdminUserControl;
        public SetAttendeeStatusByDateForm(IAttendeeRepository attendeeRepository, AdminUserControl adminUserControl)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
            AdminUserControl = adminUserControl;
        }

        private void SetAttendeeStatusByDateForm_Load(object sender, EventArgs e)
        {
            LoadAttendees();
        }

        private void LoadAttendees()
        {
            dataGridView1.Rows.Clear();

            var attendees = AttendeeRepository.GetAttendees();

            foreach (var attendee in attendees)
            {
                dataGridView1.Rows.Add(attendee.Id, attendee.AttendeeRFID, attendee.Status);
            }
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            AdminUserControl.UpdateAttendanceById(dateTimePickerVisitedDate.Value, int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), comboBox1.Text);
            AdminUserControl.LoadAttendanceList();

            this.Cursor = Cursors.Default;

            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
