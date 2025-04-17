using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve user inputs
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string relativePath = "users.db";
            string databasePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            string connectionString = $"Data Source={databasePath};Version=3;";

            // Retrieve user data from the database
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // Use SQLiteCommand instead of SqlCommand
                using (var command = new SQLiteCommand("SELECT PasswordHash FROM Users WHERE Username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        // Check password (use hashing for security)
                        if (VerifyPassword(password, result.ToString()))
                        {
                            // Store user session
                            UserSession.Username = username;
                            UserSession.IsLoggedIn = true;
                            

                            // Redirect to the main form
                            HomePageRegisteredUser mainForm = new HomePageRegisteredUser();
                            mainForm.Show();
                            this.Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Wrong password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            // Implement hashing comparison (e.g., using BCrypt)
            return password == storedHash;
        }
        private void lblSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }  
    }
}
