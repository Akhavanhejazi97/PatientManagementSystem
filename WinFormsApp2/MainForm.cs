using System;
using System.Data;
using WinFormsApp2.Extensions;
using PatientManagementSystem.Data;
using PatientManagementSystem.Forms;
using PatientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp2.Helpers;
using WinFormsApp2.Data;
using WinFormsApp2.Forms;

namespace PatientManagementSystem
{
    public partial class MainForm : Form
    {
        private IPatientRepository _repository;
        private AddEditPatientForm _addEditForm;
        private Button btnAddDoctor;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblLoggedInUser;
        private ToolStripStatusLabel lblLoginTime;
        private Button btnEditDoctor;
        private Button btnDeleteDoctor;
        private SearchPatientForm _searchForm;
        private Button btnLogout;
        private string _selectedDatabase;
        private void PatientForm_RecordInserted(Patient patient)
        {
            LoadPatients();
        }

        private void PatientForm_RecordUpdated(Patient patient)
        {
            LoadPatients();
        }
        private readonly IUserRepository _userRepository;
        private User _loggedInUser;

        public MainForm() : this("List", null, null)
        {
        }

        public MainForm(string selectedDatabase) : this(selectedDatabase, null, null)
        {
        }

        public MainForm(string selectedDatabase, User loggedInUser, IUserRepository userRepository)
        {
            _selectedDatabase = selectedDatabase;
            _loggedInUser = loggedInUser;
            _userRepository = userRepository;

            if (_selectedDatabase == "SQL")
            {
                _repository = new SqlPatientRepository();
            }
            else if (_selectedDatabase == "Access")
            {
                _repository = new AccessPatientRepository();
            }
            else
            {
                _repository = new PatientRepository();
            }

            InitializeComponent();

            if (_loggedInUser != null)
            {
                lblLoggedInUser.Text = "کاربر واردشده: " +
                    _loggedInUser.FirstName + " " + _loggedInUser.LastName;
            }

            lblLoginTime.Text = "زمان ورود: " +
                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            LoadPatients();
        }

        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            columnEdit = new DataGridViewButtonColumn();
            columnDelete = new DataGridViewButtonColumn();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnAddDoctor = new Button();
            btnEditDoctor = new Button();
            btnDeleteDoctor = new Button();
            statusStrip = new StatusStrip();
            lblLoggedInUser = new ToolStripStatusLabel();
            lblLoginTime = new ToolStripStatusLabel();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { columnEdit, columnDelete });
            dgvPatients.Location = new Point(14, 127);
            dgvPatients.Margin = new Padding(3, 4, 3, 4);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(869, 486);
            dgvPatients.TabIndex = 0;
            dgvPatients.CellContentClick += dgvPatients_CellContentClick;
            // 
            // columnEdit
            // 
            columnEdit.MinimumWidth = 6;
            columnEdit.Name = "columnEdit";
            columnEdit.ReadOnly = true;
            // 
            // columnDelete
            // 
            columnDelete.MinimumWidth = 6;
            columnDelete.Name = "columnDelete";
            columnDelete.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(14, 9);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 54);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "افزودن بیمار";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(510, 9);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 54);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "جستجو";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(498, 9);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 54);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "بازخوانی";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(635, 29);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(228, 27);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(869, 32);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "جستجو:";
            lblSearch.Click += lblSearch_Click;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.Location = new Point(14, 65);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Size = new Size(114, 54);
            btnAddDoctor.TabIndex = 8;
            btnAddDoctor.Text = "افزودن پزشک";
            btnAddDoctor.UseVisualStyleBackColor = true;
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // btnEditDoctor
            // 
            btnEditDoctor.Location = new Point(135, 65);
            btnEditDoctor.Name = "btnEditDoctor";
            btnEditDoctor.Size = new Size(114, 54);
            btnEditDoctor.TabIndex = 9;
            btnEditDoctor.Text = "ویرایش پزشک";
            btnEditDoctor.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDoctor
            // 
            btnDeleteDoctor.Location = new Point(256, 65);
            btnDeleteDoctor.Name = "btnDeleteDoctor";
            btnDeleteDoctor.Size = new Size(114, 55);
            btnDeleteDoctor.TabIndex = 10;
            btnDeleteDoctor.Text = "حذف پزشک";
            btnDeleteDoctor.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblLoggedInUser, lblLoginTime });
            statusStrip.Location = new Point(0, 603);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(939, 26);
            statusStrip.TabIndex = 0;
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(0, 20);
            // 
            // lblLoginTime
            // 
            lblLoginTime.Name = "lblLoginTime";
            lblLoginTime.Size = new Size(0, 20);
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(156, 9);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(114, 51);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "خروج از حساب";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 629);
            Controls.Add(btnLogout);
            Controls.Add(statusStrip);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(dgvPatients);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "سیستم مدیریت بیماران";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dgvPatients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataRowView rowView =
     (DataRowView)dgvPatients.Rows[e.RowIndex].DataBoundItem;

            Patient selectedPatient = new Patient(
                rowView["NationalCode"].ToString())
            {
                Id = Convert.ToInt32(rowView["Id"]),
                FirstName = rowView["FirstName"].ToString(),
                LastName = rowView["LastName"].ToString(),
                DateOfBirth = Convert.ToDateTime(rowView["DateOfBirth"]),
                Phone = rowView["Phone"].ToString(),
                Address = rowView["Address"].ToString(),
                RegistrationDate = Convert.ToDateTime(rowView["RegistrationDate"])
            };

            if (dgvPatients.Columns[e.ColumnIndex] == columnEdit)
            {
                _addEditForm = new AddEditPatientForm(_repository, selectedPatient);
                _addEditForm.RecordUpdated += PatientForm_RecordUpdated;
                _addEditForm.Show();
            }

            if (dgvPatients.Columns[e.ColumnIndex] == columnDelete)
            {
                DialogResult result = MessageBox.Show(
                    "آیا از حذف بیمار " + selectedPatient.FirstName + " " + selectedPatient.LastName + " مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = _repository.Delete(selectedPatient.Id);

                    if (success)
                    {
                        MessageBox.Show(
                            "بیمار با موفقیت حذف شد.",
                            "موفقیت",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadPatients();
                    }
                    else
                    {
                        MessageBox.Show(
                            "خطا در حذف بیمار.",
                            "خطا",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

        }

        // ============== متغیرهای فرم ==============
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Button btnAdd;
        private DataGridViewButtonColumn columnEdit;
        private DataGridViewButtonColumn columnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        // ============== بارگذاری بیماران ==============
        private void LoadPatients()
        {
            List<Patient> patients = _repository.GetAll();

            DataTable dataTable =
                WinFormsApp2.Extensions.DataTableExtensions.ToDataTable(patients);

            dgvPatients.DataSource = null;
            dgvPatients.DataSource = dataTable;

            if (dgvPatients.Columns.Count > 0)
            {
                if (dgvPatients.Columns.Contains("Id"))
                    dgvPatients.Columns["Id"].HeaderText = "شناسه";
                if (dgvPatients.Columns.Contains("NationalCode"))
                    dgvPatients.Columns["NationalCode"].HeaderText = "کد ملی";
                if (dgvPatients.Columns.Contains("FirstName"))
                    dgvPatients.Columns["FirstName"].HeaderText = "نام";
                if (dgvPatients.Columns.Contains("LastName"))
                    dgvPatients.Columns["LastName"].HeaderText = "نام خانوادگی";
                if (dgvPatients.Columns.Contains("DateOfBirth"))
                    dgvPatients.Columns["DateOfBirth"].HeaderText = "تاریخ تولد";
                if (dgvPatients.Columns.Contains("Phone"))
                    dgvPatients.Columns["Phone"].HeaderText = "تلفن";
                if (dgvPatients.Columns.Contains("Address"))
                    dgvPatients.Columns["Address"].HeaderText = "آدرس";
                if (dgvPatients.Columns.Contains("RegistrationDate"))
                    dgvPatients.Columns["RegistrationDate"].HeaderText = "تاریخ ثبت نام";
            }
        }

        // ============== افزودن بیمار جدید ==============
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _addEditForm = new AddEditPatientForm(_repository);
            _addEditForm.RecordInserted += PatientForm_RecordInserted;
            _addEditForm.Show();
        }

        // ============== ویرایش بیمار ==============
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.", "توجه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Patient selectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;

            _addEditForm = new AddEditPatientForm(_repository, selectedPatient);
            _addEditForm.RecordUpdated += PatientForm_RecordUpdated;

            _addEditForm.Show();
        }






        // ============== حذف بیمار ==============
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفاً یک بیمار را انتخاب کنید.", "توجه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Patient selectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                "آیا از حذف بیمار " + selectedPatient.FirstName + " " + selectedPatient.LastName + " مطمئن هستید؟",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = _repository.Delete(selectedPatient.Id);
                if (success)
                {
                    MessageBox.Show("بیمار با موفقیت حذف شد.", "موفقیت",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatients();
                }
                else
                {
                    MessageBox.Show("خطا در حذف بیمار.", "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============== جستجوی پیشرفته ==============
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchForm = new SearchPatientForm(_repository);
            _searchForm.ShowDialog();
        }

        // ============== بازخوانی ==============
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
            txtSearch.Clear();
        }

        // ============== جستجوی سریع ==============

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadPatients();
                return;
            }

            List<Patient> results = _repository.Search(txtSearch.Text.Trim());

            DataTable dataTable =
                WinFormsApp2.Extensions.DataTableExtensions.ToDataTable(results);

            dgvPatients.DataSource = null;
            dgvPatients.DataSource = dataTable;
        }




        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            DoctorRepository doctorRepository = new DoctorRepository();

            AddEditDoctorForm doctorForm =
                new AddEditDoctorForm(doctorRepository);

            doctorForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "آیا می‌خواهید از حساب کاربری خارج شوید؟",
                "خروج از حساب",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                RememberMeStore.Clear();

                WinFormsApp2.Forms.LoginForm loginForm =
                    new WinFormsApp2.Forms.LoginForm(
                        _userRepository,
                        _selectedDatabase
                    );

                loginForm.Show();
                this.Hide();
            }
        }
    }
}
