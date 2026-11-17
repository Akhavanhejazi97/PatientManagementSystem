using System;
using System.Windows.Forms;
using PatientManagementSystem;
using PatientManagementSystem.Data;
using WinFormsApp2.Helpers;

namespace WinFormsApp2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string username;
            string database;

            if (RememberMeStore.TryLoad(
                out username, out database))
            {
                IUserRepository repository = null;

                if (database == "SQL")
                {
                    repository = new SqlUserRepository();
                }
                else if (database == "List")
                {
                    repository = new UserRepository();
                }

                if (repository != null)
                {
                    var user = repository.GetByUsername(username);

                    if (user != null)
                    {
                        Application.Run(
                            new MainForm(database, user, repository)
                        );

                        return;
                    }
                }

                RememberMeStore.Clear();
            }

            Application.Run(new DatabaseSelectionForm());
        }
    }
}