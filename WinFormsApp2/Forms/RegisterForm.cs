using System;
using System.Windows.Forms;
using PatientManagementSystem.Models;
using PatientManagementSystem.Data;
using WinFormsApp2.Helpers;

namespace WinFormsApp2.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IUserRepository userRepository;

        private string verificationCode = "";
        private bool isMobileVerified = false;
        private string verifiedMobile = "";

        // سازنده برای باز شدن فرم در Designer
        public RegisterForm()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        // سازنده اصلی برای دریافت مخزن کاربران
        public RegisterForm(IUserRepository repository)
        {
            InitializeComponent();
            userRepository = repository;
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string mobile = txtMobile.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobile))
            {
                MessageBox.Show("شماره موبایل را وارد کنید.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                mobile, @"^09\d{9}$"))
            {
                MessageBox.Show("شماره موبایل باید ۱۱ رقم و با 09 شروع شود.");
                return;
            }

            verificationCode =
                System.Security.Cryptography.RandomNumberGenerator
                .GetInt32(1000, 10000).ToString();

            isMobileVerified = false;
            verifiedMobile = "";

            MessageBox.Show("کد تأیید شما: " + verificationCode);
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("کد تأیید را وارد کنید.");
                return;
            }

            if (string.IsNullOrWhiteSpace(verificationCode))
            {
                MessageBox.Show("ابتدا کد تأیید را ارسال کنید.");
                return;
            }

            if (txtCode.Text.Trim() == verificationCode)
            {
                isMobileVerified = true;
                verifiedMobile = txtMobile.Text.Trim();

                MessageBox.Show("شماره موبایل با موفقیت تأیید شد.");
            }
            else
            {
                isMobileVerified = false;
                verifiedMobile = "";

                MessageBox.Show("کد تأیید اشتباه است.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!isMobileVerified ||
                verifiedMobile != txtMobile.Text.Trim())
            {
                MessageBox.Show("ابتدا شماره موبایل خود را تأیید کنید.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("لطفاً تمام اطلاعات را وارد کنید.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("رمز عبور و تکرار آن یکسان نیستند.");
                return;
            }

            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("رمز عبور باید حداقل ۸ کاراکتر باشد.");
                return;
            }

            if (userRepository.GetByUsername(txtUsername.Text.Trim()) != null)
            {
                MessageBox.Show("این نام کاربری قبلاً ثبت شده است.");
                return;
            }

            if (userRepository.GetByMobile(verifiedMobile) != null)
            {
                MessageBox.Show("این شماره موبایل قبلاً ثبت شده است.");
                return;
            }

            User user = new User
            {
                Mobile = verifiedMobile,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                PasswordHash = PasswordHasher.HashPassword(txtPassword.Text)
            };

            bool result = userRepository.Add(user);

            if (result)
            {
                MessageBox.Show("ثبت‌نام با موفقیت انجام شد.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("ثبت‌نام انجام نشد. اطلاعات را بررسی کنید.");
            }
        }
    }
}