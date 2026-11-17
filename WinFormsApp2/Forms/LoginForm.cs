using PatientManagementSystem;
using PatientManagementSystem.Data;
using System;
using System.Windows.Forms;
using WinFormsApp2.Helpers;

namespace WinFormsApp2.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository userRepository;
        private readonly string selectedDatabase;

        public LoginForm(IUserRepository repository, string database)
        {
            InitializeComponent();

            userRepository = repository;
            selectedDatabase = database;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("نام کاربری و رمز عبور را وارد کنید.");
                return;
            }

            var user = userRepository.GetByUsername(
                txtUsername.Text.Trim()
            );

            if (user == null ||
                !PasswordHasher.VerifyPassword(
                    txtPassword.Text, user.PasswordHash))
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
                return;
            }

            if (chkRememberMe.Checked)
            {
                RememberMeStore.Save(
                    user.Username,
                    selectedDatabase
                );
            }
            else
            {
                RememberMeStore.Clear();
            }

            MainForm mainForm =
                new MainForm(selectedDatabase, user, userRepository);

            mainForm.Show();
            this.Hide();
        }

        private void lnkRegister_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm =
                new RegisterForm(userRepository);

            registerForm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void lnkForgotPassword_LinkClicked(
    object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotForm =
                new ForgotPasswordForm(userRepository);

            forgotForm.ShowDialog();
        }
    }
}