using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.LoginForms
{
    public partial class ChangePasswordForm : Form
    {
        private IAppUserRepository AppUserRepository { get; set; }
        public ChangePasswordForm(IAppUserRepository appUserRepository)
        {
            InitializeComponent();
            AppUserRepository = appUserRepository;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewPassword.Text) &&
                !string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    var newAppUser = new AppUser()
                    {
                        Password = txtNewPassword.Text,
                        Id = Helpers.PlaceHelper.AppUserId
                    };

                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");

                    var isValidated = hasNumber.IsMatch(txtNewPassword.Text) && hasUpperChar.IsMatch(txtNewPassword.Text) && hasMinimum8Chars.IsMatch(txtNewPassword.Text);

                    if (isValidated)
                    {
                        var response = AppUserRepository.ChangePassword(newAppUser);

                        MessageBox.Show($"StatusCode: {response.StatusCode.ToString()}");
                    }
                    else
                    {
                        MessageBox.Show("Password must contain a number, an uppercase character and must have a minimum of 8 characters.");
                    }

                }
                else
                {
                    MessageBox.Show("Password does not match.");
                }
            }
            else
            {
                MessageBox.Show("Please input all details!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
