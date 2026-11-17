using System;
using System.Windows.Forms;
using PatientManagementSystem.Data;
using WinFormsApp2.Forms;

namespace WinFormsApp2
{
    public partial class DatabaseSelectionForm : Form
    {
        public DatabaseSelectionForm()
        {
            InitializeComponent();

            cmbDatabase.Items.Add("SQL");
            cmbDatabase.Items.Add("Access");
            cmbDatabase.Items.Add("List");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex == -1)
            {
                MessageBox.Show("لطفاً نوع دیتابیس را انتخاب کنید.");
                return;
            }

            string selectedDatabase =
                cmbDatabase.SelectedItem.ToString();

            IUserRepository userRepository;

            if (selectedDatabase == "SQL")
            {
                userRepository = new SqlUserRepository();
            }
            else if (selectedDatabase == "List")
            {
                userRepository = new UserRepository();
            }
            else
            {
                MessageBox.Show(
                    "اتصال کاربران به دیتابیس Access هنوز آماده نشده است."
                );
                return;
            }

            LoginForm loginForm =
                new LoginForm(userRepository, selectedDatabase);

            loginForm.Show();
            this.Hide();
        }
    }
}