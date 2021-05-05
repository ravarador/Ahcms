using AutomatedHumanContactMonitorySystemApp.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.UserControls
{
    public partial class AttendanceListUserControl : UserControl
    {
        private IAttendanceRepository AttendanceRepository { get; set; }

        public AttendanceListUserControl()
        {
            InitializeComponent();
        }

        private void AttendanceListUserControl_Load(object sender, EventArgs e)
        {

        }

        public void LoadRepositories(IAttendanceRepository attendanceRepository)
        {
            AttendanceRepository = attendanceRepository;
        }

        public void LoadAttendanceList()
        {
            var attendances = AttendanceRepository.GetAttendances();

            foreach (var attendance in attendances)
            {
                dataGridView1.Rows.Add(attendance.Name,
                                       attendance.VisitedDateTime,
                                       attendance.Temperature,
                                       attendance.Location,
                                       attendance.AttendeeRFID,
                                       "STATUS");
            }
        }
    }
}
