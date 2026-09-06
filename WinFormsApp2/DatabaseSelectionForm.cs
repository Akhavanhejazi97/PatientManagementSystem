using PatientManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class DatabaseSelectionForm : Form
    {
        public DatabaseSelectionForm()
        {
            InitializeComponent(); //
            cmbDatabase.Items.Add("SQL");
            cmbDatabase.Items.Add("Access");
            cmbDatabase.Items.Add("List");

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex == -1)
{
    MessageBox.Show("Please choose a database.");
    return;
}

string selectedDatabase = cmbDatabase.SelectedItem.ToString();

            MainForm mainForm = new MainForm(selectedDatabase);
            mainForm.Show();
            this.Hide();
        }
    }
}
