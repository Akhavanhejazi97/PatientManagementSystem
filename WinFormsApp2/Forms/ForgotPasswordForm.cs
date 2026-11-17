using System;
using System.Windows.Forms;
using PatientManagementSystem.Data;
using WinFormsApp2.Helpers;

namespace WinFormsApp2.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly IUserRepository userRepository;
        private string verificationCode = "";
        private string verifiedMobile = "";

        public ForgotPasswordForm(IUserRepository repository)
        {
            InitializeComponent();

            userRepository = repository;

            btnSendCode.Click += btnSendCode_Click;
            btnResetPassword.Click += btnResetPassword_Click;
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string mobile = txtMobile.Text.Trim();

            if (!System.Text.RegularExpressions.Regex.IsMatch(
                mobile, @"^09\d{9}$"))
            {
                MessageBox.Show("شماره موبایل معتبر وارد کنید.");
                return;
            }

            var user = userRepository.GetByMobile(mobile);

            if (user == null)
            {
                MessageBox.Show("کاربری با این شماره موبایل پیدا نشد.");
                return;
            }

            verificationCode =
                new Random().Next(1000, 10000).ToString();

            verifiedMobile = mobile;

            MessageBox.Show(
                "کد تأیید شما: " + verificationCode,
                "کد بازیابی رمز عبور"
            );
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(verificationCode))
            {
                MessageBox.Show("ابتدا کد تأیید را دریافت کنید.");
                return;
            }

            if (txtMobile.Text.Trim() != verifiedMobile)
            {
                MessageBox.Show("شماره موبایل تغییر کرده است.");
                return;
            }

            if (txtCode.Text.Trim() != verificationCode)
            {
                MessageBox.Show("کد تأیید اشتباه است.");
                return;
            }

            if (txtNewPassword.Text.Length < 8)
            {
                MessageBox.Show("رمز عبور باید حداقل ۸ کاراکتر باشد.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("رمزهای عبور یکسان نیستند.");
                return;
            }

            string passwordHash =
                PasswordHasher.HashPassword(txtNewPassword.Text);

            bool success = userRepository.UpdatePassword(
                verifiedMobile,
                passwordHash
            );

            if (success)
            {
                MessageBox.Show("رمز عبور با موفقیت تغییر کرد.");

                verificationCode = "";
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("تغییر رمز عبور انجام نشد.");
            }
        }
    }
}