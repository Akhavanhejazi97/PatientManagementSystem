namespace WinFormsApp2.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblMobile = new Label();
            txtMobile = new TextBox();
            btnSendCode = new Button();
            lblCode = new Label();
            txtCode = new TextBox();
            btnVerifyCode = new Button();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(200, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ثبت‌نام کاربر جدید";
            // 
            // lblMobile
            // 
            lblMobile.Location = new Point(390, 85);
            lblMobile.Name = "lblMobile";
            lblMobile.Size = new Size(100, 25);
            lblMobile.TabIndex = 1;
            lblMobile.Text = "شماره موبایل";
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(160, 85);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(220, 27);
            txtMobile.TabIndex = 2;
            txtMobile.UseSystemPasswordChar = true;
            // 
            // btnSendCode
            // 
            btnSendCode.Location = new Point(55, 85);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(90, 30);
            btnSendCode.TabIndex = 3;
            btnSendCode.Text = "ارسال کد";
            btnSendCode.UseVisualStyleBackColor = true;
            btnSendCode.Click += btnSendCode_Click;
            // 
            // lblCode
            // 
            lblCode.Location = new Point(390, 130);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(100, 25);
            lblCode.TabIndex = 4;
            lblCode.Text = "کد تأیید";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(160, 130);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(220, 27);
            txtCode.TabIndex = 5;
            txtCode.UseSystemPasswordChar = true;
            // 
            // btnVerifyCode
            // 
            btnVerifyCode.Location = new Point(55, 130);
            btnVerifyCode.Name = "btnVerifyCode";
            btnVerifyCode.Size = new Size(90, 30);
            btnVerifyCode.TabIndex = 6;
            btnVerifyCode.Text = "تأیید کد";
            btnVerifyCode.UseVisualStyleBackColor = true;
            btnVerifyCode.Click += btnVerifyCode_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(390, 180);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 25);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "نام";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(160, 180);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(220, 27);
            txtFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(390, 220);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 25);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "نام خانوادگی";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(160, 220);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(220, 27);
            txtLastName.TabIndex = 10;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(390, 260);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 20);
            lblUsername.TabIndex = 11;
            lblUsername.Text = "نام کاربری";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(160, 260);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 27);
            txtUsername.TabIndex = 12;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(390, 300);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 25);
            lblPassword.TabIndex = 13;
            lblPassword.Text = "رمز عبور";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(160, 300);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(220, 27);
            txtPassword.TabIndex = 14;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(390, 340);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(100, 25);
            lblConfirmPassword.TabIndex = 15;
            lblConfirmPassword.Text = "تکرار رمز عبور";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(160, 340);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(220, 27);
            txtConfirmPassword.TabIndex = 16;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(220, 400);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 40);
            btnRegister.TabIndex = 17;
            btnRegister.Text = "ثبت‌نام نهایی";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 473);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(btnVerifyCode);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            Controls.Add(btnSendCode);
            Controls.Add(txtMobile);
            Controls.Add(lblMobile);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ثبت‌نام در نرم‌افزار";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMobile;
        private TextBox txtMobile;
        private Button btnSendCode;
        private Label lblCode;
        private TextBox txtCode;
        private Button btnVerifyCode;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
    }
}