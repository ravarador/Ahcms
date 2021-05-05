using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendanceForms
{
    public partial class UpdateAttendanceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public UpdateAttendanceForm(IAttendanceRepository attendanceRepository)
        {
            InitializeComponent();
            AttendanceRepository = attendanceRepository;
        }

        private void UpdateAttendanceForm_Load(object sender, EventArgs e)
        {
            LoadGridViewAttendances();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtDateTime.Text = row.Cells[1].Value.ToString();
            txtTemperature.Text = row.Cells[2].Value.ToString();
            txtAttendeeId.Text = row.Cells[3].Value.ToString();
            txtName.Text = row.Cells[4].Value.ToString();
            txtAge.Text = row.Cells[5].Value.ToString();
            txtAddress.Text = row.Cells[6].Value.ToString();
            txtPlaceId.Text = row.Cells[7].Value.ToString();
            txtLocation.Text = row.Cells[8].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PutAttendance();
            LoadGridViewAttendances();
        }


        #region Helpers

        private void LoadGridViewAttendances()
        {
            dataGridView1.DataSource = GetAttendances();
        }

        private List<AttendanceDto> GetAttendances()
        {
            var attendances = AttendanceRepository.GetAttendances();
            return attendances.ToList();
        }

        private void PutAttendance()
        {
            var attendanceToUpdate = new Attendance()
            {
                Id = int.Parse(txtId.Text),
                Temperature = double.Parse(txtTemperature.Text),
                VisitedDateTime = Convert.ToDateTime(txtDateTime.Text),
            };
            AttendanceRepository.UpdateAttendanceStatus(attendanceToUpdate);
        }

        #endregion

        
    }
}
