using AutomatedHumanContactMonitorySystemApp.Helpers;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.LoginForms
{
    public partial class LoginForm : Form
    {
        public IAppUserRepository AppUserRepository { get; set; }
        public LoginForm(IAppUserRepository appUserRepository)
        {
            AppUserRepository = appUserRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var appUser = new AppUser()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username/Password should not be blank");
            }
            else
            {
                try
                {
                    var appUserLogin = AppUserRepository.IsAuthorized(appUser);

                    if (appUserLogin != null)
                    {
                        PlaceHelper.AppUserName = appUserLogin.Username;
                        PlaceHelper.PlaceId = appUserLogin.PlaceId;
                        PlaceHelper.IsAdmin = appUserLogin.IsAdmin;
                        PlaceHelper.AppUserId = appUserLogin.Id;
                        SaveRememberMeInfo();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username/Password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect Username/Password");
                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ReadRememberMeInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Remember Me
        private void SaveRememberMeInfo()
        {
            var pathDirectory = Application.UserAppDataPath;
            var filePathDirectory = Path.Combine(pathDirectory, $"remembermeinfo.txt");

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(filePathDirectory))
                {
                    File.Delete(filePathDirectory);
                }

                // Create a new file     
                using (FileStream fs = File.Create(filePathDirectory))
                {
                    // Add some text to file    
                    Byte[] loginInfo = new UTF8Encoding(true).GetBytes("");

                    if (checkRememberMe.Checked)
                    {
                        // Add some text to file    
                        loginInfo = new UTF8Encoding(true).GetBytes($"{txtUsername.Text}|{EncryptionHelper.Encrypt(txtPassword.Text)}|true");
                    }

                    fs.Write(loginInfo, 0, loginInfo.Length);
                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private void ReadRememberMeInfo()
        {
            var pathDirectory = Application.UserAppDataPath;
            var filePathDirectory = Path.Combine(pathDirectory, $"remembermeinfo.txt");

            try
            {
                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(filePathDirectory))
                {
                    string info = "";
                    while ((info = sr.ReadLine()) != null)
                    {
                        var infos = info.Split('|').ToArray();

                        txtUsername.Text = infos[0];
                        txtPassword.Text = EncryptionHelper.Decrypt(infos[1]);
                        checkRememberMe.Checked = bool.Parse(infos[2]);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
    }
}
