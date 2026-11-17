using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PatientManagementSystem.Data;
using PatientManagementSystem.Helpers;
using PatientManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using WinFormsApp2.Extensions;

namespace PatientManagementSystem.Forms
{
    public partial class AddEditPatientForm : Form
    {
        public delegate void RecordEventHandler(Patient patient);

        public event RecordEventHandler RecordInserted;
        public event RecordEventHandler RecordUpdated;
        private IPatientRepository _repository;
        private Patient _editingPatient;
        private Button btnSaveAndNew;
        private bool _isEditMode;

        // سازنده برای افزودن بیمار جدید
        public AddEditPatientForm(IPatientRepository repository)
        {
            _repository = repository;
            _isEditMode = false;
            _editingPatient = null;
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorToolTip = new ToolTip();
            AttachValidationEvents();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.Text = "افزودن بیمار جدید";
            btnSave.Text = "ثبت بیمار";
        }

        // سازنده برای ویرایش بیمار
        public AddEditPatientForm(IPatientRepository repository, Patient patient)
        {
            _repository = repository;
            _editingPatient = patient;
            _isEditMode = true;
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorToolTip = new ToolTip();
            btnSaveAndNew.Visible = false;
            this.Text = "ویرایش بیمار";
            btnSave.Text = "به‌روزرسانی";
            LoadPatientData();
        }

        private void InitializeComponent()
        {
            lblNationalCode = new Label();
            txtNationalCode = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnSaveAndNew = new Button();
            SuspendLayout();
            // 
            // lblNationalCode
            // 
            lblNationalCode.AutoSize = true;
            lblNationalCode.Location = new Point(340, 20);
            lblNationalCode.Name = "lblNationalCode";
            lblNationalCode.Size = new Size(59, 20);
            lblNationalCode.TabIndex = 13;
            lblNationalCode.Text = "کد ملی:";
            // 
            // txtNationalCode
            // 
            txtNationalCode.Location = new Point(150, 17);
            txtNationalCode.MaxLength = 10;
            txtNationalCode.Name = "txtNationalCode";
            txtNationalCode.Size = new Size(184, 27);
            txtNationalCode.TabIndex = 12;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(367, 55);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(30, 20);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "نام:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 52);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(184, 27);
            txtFirstName.TabIndex = 10;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(333, 90);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(93, 20);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "نام خانوادگی:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 87);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(184, 27);
            txtLastName.TabIndex = 8;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(341, 125);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(72, 20);
            lblDateOfBirth.TabIndex = 7;
            lblDateOfBirth.Text = "تاریخ تولد:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(150, 122);
            dtpDateOfBirth.MaxDate = new DateTime(2026, 9, 7, 12, 54, 21, 864);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(184, 27);
            dtpDateOfBirth.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(360, 160);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(40, 20);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "تلفن:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(150, 157);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(184, 27);
            txtPhone.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(356, 195);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(47, 20);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "آدرس:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(150, 192);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(184, 60);
            txtAddress.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(189, 270);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "ذخیره";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(83, 270);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "انصراف";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSaveAndNew
            // 
            btnSaveAndNew.Location = new Point(297, 270);
            btnSaveAndNew.Name = "btnSaveAndNew";
            btnSaveAndNew.Size = new Size(100, 30);
            btnSaveAndNew.TabIndex = 14;
            btnSaveAndNew.Text = "ذخیره و جدید";
            btnSaveAndNew.UseVisualStyleBackColor = true;
            btnSaveAndNew.Click += btnSaveAndNew_Click;
            // 
            // AddEditPatientForm
            // 
            ClientSize = new Size(420, 320);
            Controls.Add(btnSaveAndNew);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(lblDateOfBirth);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtNationalCode);
            Controls.Add(lblNationalCode);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditPatientForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblNationalCode;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ToolTip errorToolTip;
        private ErrorProvider errorProvider;


        private void LoadPatientData()
        {
            txtNationalCode.Text = _editingPatient.NationalCode;
            txtFirstName.Text = _editingPatient.FirstName;
            txtLastName.Text = _editingPatient.LastName;
            dtpDateOfBirth.Value = _editingPatient.DateOfBirth;
            txtPhone.Text = _editingPatient.Phone;
            txtAddress.Text = _editingPatient.Address;
        }
        private void AttachValidationEvents()
        {
            txtNationalCode.TextChanged += (s, e) =>
                errorProvider.SetError(txtNationalCode, "");

            txtFirstName.TextChanged += (s, e) =>
                errorProvider.SetError(txtFirstName, "");

            txtLastName.TextChanged += (s, e) =>
                errorProvider.SetError(txtLastName, "");

            txtPhone.TextChanged += (s, e) =>
                errorProvider.SetError(txtPhone, "");

            txtAddress.TextChanged += (s, e) =>
                errorProvider.SetError(txtAddress, "");
        }
        private bool ValidatePatient(Patient patient)
        {
            errorProvider.Clear();

            var context = new ValidationContext(patient);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                patient,
                context,
                results,
                validateAllProperties: true
            );

            foreach (var result in results)
            {
                foreach (var memberName in result.MemberNames)
                {
                    Control control = null;

                    switch (memberName)
                    {
                        case nameof(Patient.NationalCode):
                            control = txtNationalCode;
                            break;

                        case nameof(Patient.FirstName):
                            control = txtFirstName;
                            break;

                        case nameof(Patient.LastName):
                            control = txtLastName;
                            break;

                        case nameof(Patient.Phone):
                            control = txtPhone;
                            break;

                        case nameof(Patient.Address):
                            control = txtAddress;
                            break;
                    }

                    if (control != null)
                    {
                        string message = result.ErrorMessage ?? "خطای نامشخص";

                        errorProvider.SetError(control, message);
                        errorProvider.SetIconAlignment(
                            control,
                            ErrorIconAlignment.MiddleRight
                        );
                    }
                }
            }

            return isValid;
        }


        private bool ValidateFields()
        {
            errorProvider.Clear();

            Patient patient = new Patient(
                txtNationalCode.Text.Trim()
            );

            patient.FirstName = txtFirstName.Text.Trim();
            patient.LastName = txtLastName.Text.Trim();
            patient.DateOfBirth = dtpDateOfBirth.Value;
            patient.Phone = txtPhone.Text.Trim();
            patient.Address = txtAddress.Text.Trim();

            return ValidatePatient(patient);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            Patient patient = new Patient(txtNationalCode.Text.Trim());
            patient.NationalCode = txtNationalCode.Text.Trim();
            patient.FirstName = txtFirstName.Text.Trim();
            patient.LastName = txtLastName.Text.Trim();
            patient.DateOfBirth = dtpDateOfBirth.Value;
            patient.Phone = txtPhone.Text.Trim();
            patient.Address = txtAddress.Text.Trim();

            bool success;

            if (_isEditMode)
            {
                patient.Id = _editingPatient.Id;
                success = _repository.UpdatePatient(patient);
                if (success)
                    ValidationHelper.ShowSuccess("بیمار با موفقیت ویرایش شد.");
            }
            else
            {
                success = _repository.AddPatient(patient);
                if (success)
                    ValidationHelper.ShowSuccess("بیمار با موفقیت ثبت شد.");
                RecordInserted?.Invoke(patient);
            }

            if (success)
            {
                if (_isEditMode)
                {
                    RecordUpdated?.Invoke(patient);
                }
                else
                {
                    RecordInserted?.Invoke(patient);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ValidationHelper.ShowValidationError("خطا در ذخیره اطلاعات.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            Patient patient = new Patient(txtNationalCode.Text.Trim());

            patient.FirstName = txtFirstName.Text.Trim();
            patient.LastName = txtLastName.Text.Trim();
            patient.DateOfBirth = dtpDateOfBirth.Value;
            patient.Phone = txtPhone.Text.Trim();
            patient.Address = txtAddress.Text.Trim();

            bool success = _repository.AddPatient(patient);

            if (success)
            {
                ValidationHelper.ShowSuccess("بیمار با موفقیت ثبت شد.");

                txtNationalCode.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();

                txtNationalCode.Focus();
            }
            else
            {
                ValidationHelper.ShowValidationError("خطا در ذخیره اطلاعات.");
            }

        }
    }
}