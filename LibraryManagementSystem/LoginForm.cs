using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Security;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // No AppData.Seed() here
            // Data is loaded in Program.cs -> AppData.LoadAll()
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter username and password.");
                return;
            }

            string hash = PasswordHelper.Sha256(password);

            var user = AppData.Users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == hash);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            this.Hide();
            var dash = new DashboardForm(user);
            dash.FormClosed += (s, args) => this.Close();
            dash.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
