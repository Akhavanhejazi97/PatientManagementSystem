namespace WinFormsApp2
{
    partial class DatabaseSelectionForm
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
            lblChooseDatabase = new Label();
            cmbDatabase = new ComboBox();
            btnEnter = new Button();
            SuspendLayout();
            // 
            // lblChooseDatabase
            // 
            lblChooseDatabase.AutoSize = true;
            lblChooseDatabase.Location = new Point(283, 25);
            lblChooseDatabase.Name = "lblChooseDatabase";
            lblChooseDatabase.Size = new Size(128, 20);
            lblChooseDatabase.TabIndex = 0;
            lblChooseDatabase.Text = "Choose Database:";
            // 
            // cmbDatabase
            // 
            cmbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDatabase.FormattingEnabled = true;
            cmbDatabase.Location = new Point(271, 68);
            cmbDatabase.Name = "cmbDatabase";
            cmbDatabase.Size = new Size(151, 28);
            cmbDatabase.TabIndex = 1;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(301, 123);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(94, 29);
            btnEnter.TabIndex = 2;
            btnEnter.Text = "ENTER";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // DatabaseSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 433);
            Controls.Add(btnEnter);
            Controls.Add(cmbDatabase);
            Controls.Add(lblChooseDatabase);
            Name = "DatabaseSelectionForm";
            Text = "Choose Database";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChooseDatabase;
        private ComboBox cmbDatabase;
        private Button btnEnter;
    }
}