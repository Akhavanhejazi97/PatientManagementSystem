using PatientManagementSystem.Data;
using PatientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PatientManagementSystem.Forms
{
    public class SearchPatientForm : Form
    {
        private readonly IPatientRepository repository;

        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvResults;

        public SearchPatientForm(IPatientRepository repository)
        {
            this.repository = repository;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "جستجوی بیمار";
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblSearch = new Label();
            lblSearch.Text = "جستجو:";
            lblSearch.Location = new Point(30, 30);
            lblSearch.AutoSize = true;

            txtSearch = new TextBox();
            txtSearch.Location = new Point(100, 25);
            txtSearch.Width = 500;

            btnSearch = new Button();
            btnSearch.Text = "جستجو";
            btnSearch.Location = new Point(620, 23);
            btnSearch.Width = 100;
            btnSearch.Click += BtnSearch_Click;

            dgvResults = new DataGridView();
            dgvResults.Location = new Point(30, 80);
            dgvResults.Size = new Size(820, 340);
            dgvResults.AutoGenerateColumns = true;
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(dgvResults);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            List<Patient> results = repository.SearchPatients(keyword);

            dgvResults.DataSource = results;
        }
    }
}