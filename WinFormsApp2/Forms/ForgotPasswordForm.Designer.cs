namespace WinFormsApp2.Forms
{
    partial class ForgotPasswordForm
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
            lblMobile = new Label();
            lblTitle = new Label();
            txtMobile = new TextBox();
            btnSendCode = new Button();
            lblCode = new Label();
            txtCode = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnResetPassword = new Button();
            SuspendLayout();
            // 
            // lblMobile
            // 
            lblMobile.Location = new Point(370, 80);
            lblMobile.Name = "lblMobile";
            lblMobile.Size = new Size(120, 25);
            lblMobile.TabIndex = 0;
            lblMobile.Text = "شماره موبایل";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(175, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "بازیابی رمز عبور\t\t";
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(130, 78);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(220, 27);
            txtMobile.TabIndex = 2;
            // 
            // btnSendCode
            // 
            btnSendCode.Location = new Point(170, 115);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(180, 35);
            btnSendCode.TabIndex = 3;
            btnSendCode.Text = "دریافت کد تأیید";
            btnSendCode.UseVisualStyleBackColor = true;
            // 
            // lblCode
            // 
            lblCode.Location = new Point(370, 170);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(120, 25);
            lblCode.TabIndex = 4;
            lblCode.Text = "کد تأیید";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(130, 168);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(220, 27);
            txtCode.TabIndex = 5;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Location = new Point(370, 220);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(120, 25);
            lblNewPassword.TabIndex = 6;
            lblNewPassword.Text = "رمز عبور جدید\t";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(130, 218);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(220, 27);
            txtNewPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(370, 270);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(120, 25);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "تکرار رمز عبور";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(130, 268);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(220, 27);
            txtConfirmPassword.TabIndex = 9;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(170, 330);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(180, 40);
            btnResetPassword.TabIndex = 10;
            btnResetPassword.Text = "ثبت رمز جدید";
            btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 403);
            Controls.Add(btnResetPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            Controls.Add(btnSendCode);
            Controls.Add(txtMobile);
            Controls.Add(lblTitle);
            Controls.Add(lblMobile);
            Name = "ForgotPasswordForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "بازیابی رمز عبور";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMobile;
        private Label lblTitle;
        private TextBox txtMobile;
        private Button btnSendCode;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnResetPassword;
    }
}