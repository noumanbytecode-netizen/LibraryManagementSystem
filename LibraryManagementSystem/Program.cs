using System;
using System.Windows.Forms;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // LOAD data from files when program starts
            AppData.LoadAll();

            // When app closes, SAVE everything
            Application.ApplicationExit += (s, e) => AppData.SaveAll();

            Application.Run(new LoginForm());
        }
    }
}
