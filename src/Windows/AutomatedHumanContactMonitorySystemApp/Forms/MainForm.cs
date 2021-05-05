using AutomatedHumanContactMonitorySystemApp.Forms.AttendanceForms;
using AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms;
using AutomatedHumanContactMonitorySystemApp.Forms.LoginForms;
using AutomatedHumanContactMonitorySystemApp.Forms.PlaceForms;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp
{
    public partial class MainForm : Form
    {

        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public IAppUserRepository AppUserRepository { get; private set; }
        public MainForm(IAttendeeRepository attendeeRepository, IPlaceRepository placeRepository, IAttendanceRepository attendanceRepository, IAppUserRepository appUserRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
            PlaceRepository = placeRepository;
            AttendanceRepository = attendanceRepository;
            AppUserRepository = appUserRepository;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLoginForm();
        }

        #region Login
        private void LoadLoginForm()
        {
            var loginForm = new LoginForm(AppUserRepository);
            loginForm.FormClosed += LoginForm_FormClosed;
            this.Hide();
            loginForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        #endregion Login

        #region AttendeeMenuStrip
        private void toolStripMenuAddAttendee_Click(object sender, EventArgs e)
        {
            var addAttendeeForm = new AddAttendeeForm(AttendeeRepository);
            addAttendeeForm.Show();
        }

        private void toolStripMenuEditAttendee_Click(object sender, EventArgs e)
        {
            var updateAttendeeForm = new UpdateAttendeeForm(AttendeeRepository);
            updateAttendeeForm.Show();
        }

        private void toolStripMenuDeleteAttendee_Click(object sender, EventArgs e)
        {
            var deleteAttendeeForm = new DeleteAttendeeForm(AttendeeRepository);
            deleteAttendeeForm.Show();
        }
        #endregion AttendeeMenuStrip

        #region PlaceMenuStrip
        private void toolStripMenuAddPlace_Click(object sender, EventArgs e)
        {
            var addPlaceForm = new AddPlaceForm(PlaceRepository);
            addPlaceForm.Show();
        }
        private void toolStripMenuEditPlace_Click(object sender, EventArgs e)
        {
            var updatePlaceForm = new UpdatePlaceForm(PlaceRepository);
            updatePlaceForm.Show();
        }
        private void toolStripMenuDeletePlace_Click(object sender, EventArgs e)
        {
            var deletePlaceForm = new DeletePlaceForm(PlaceRepository);
            deletePlaceForm.Show();
        }

        #endregion PlaceMenuStrip
       
        #region AttendanceMenuStrip
        private void toolStripMenuItemAddAttendance_Click(object sender, EventArgs e)
        {
            var addAttendanceForm = new AddAttendanceForm(AttendanceRepository, AttendeeRepository, PlaceRepository);
            addAttendanceForm.ShowDialog();
        }

        private void toolStripMenuEditAttendance_Click(object sender, EventArgs e)
        {
            var updateAttendanceForm = new UpdateAttendanceForm(AttendanceRepository);
            updateAttendanceForm.Show();
        }
        private void toolStripMenuDeleteAttendance_Click(object sender, EventArgs e)
        {
            var deleteAttendanceForm = new DeleteAttendanceForm(AttendanceRepository);
            deleteAttendanceForm.Show();
        }


        #endregion AttendanceMenuStrip


    }
}
