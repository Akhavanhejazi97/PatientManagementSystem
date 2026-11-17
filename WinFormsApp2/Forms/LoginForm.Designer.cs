namespace WinFormsApp2.Forms
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            chkRememberMe = new CheckBox();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            lnkForgotPassword = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(225, 25);
            label1.Name = "label1";
            label1.Size = new Size(150, 30);
            label1.TabIndex = 0;
            label1.Text = "خوش آمدید";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(396, 88);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "نام کاربری";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Location = new Point(396, 161);
            label3.Name = "label3";
            label3.Size = new Size(104, 24);
            label3.TabIndex = 2;
            label3.Text = "رمز عبور";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(140, 85);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 158);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 4;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(140, 217);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(139, 24);
            chkRememberMe.TabIndex = 5;
            chkRememberMe.Text = "مرا به خاطر بسپار";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(187, 259);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 40);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ورود";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.Location = new Point(315, 320);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(90, 25);
            lnkRegister.TabIndex = 7;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "ثبت‌نام";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Location = new Point(126, 320);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(120, 20);
            lnkForgotPassword.TabIndex = 8;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "فراموشی رمز عبور";
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 403);
            Controls.Add(lnkForgotPassword);
            Controls.Add(lnkRegister);
            Controls.Add(btnLogin);
            Controls.Add(chkRememberMe);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ورود به نرم‌افزار";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkRememberMe;
        private Button btnLogin;
        private LinkLabel lnkRegister;
        private LinkLabel lnkForgotPassword;
    }
}