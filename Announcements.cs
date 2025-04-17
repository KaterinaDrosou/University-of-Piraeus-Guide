﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class Announcements : Form
    {
        String connectionString = "Data source=calendar_events.db;Version=3;";
        SQLiteConnection connection;

        public Announcements()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form7_Load);

        }

        // Event handler for form loading (to load initial events)
        private void Form7_Load(object sender, EventArgs e)
        {
            // Retrieve events for the current date when the form loads
            LoadEvents(DateTime.Now.Date);
            if (!UserSession.IsLoggedIn)
            {
                userProfileToolStripMenuItem.Visible = false;
                labelWelcome.Visible = false;
            }
            else
            {
                userProfileToolStripMenuItem.Visible = true;
                labelWelcome.Visible = true;
                labelWelcome.Text = $"You are logged in as: {UserSession.Username}!";
            }
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage form1 = new MainPage();
            form1.Show();
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History form2 = new History();
            form2.Show();
        }

        private void InfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentOfInformatics form5 = new DepartmentOfInformatics();
            form5.Show();
        }

        private void IMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentOfIndustrialManagementandTechnology form6 = new DepartmentOfIndustrialManagementandTechnology();
            form6.Show();
        }

        private void BenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benefits form3 = new Benefits();
            form3.Show();
        }

        private void ActToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activities form4 = new Activities();
            form4.Show();
        }

        // When the user selects a date in the MonthCalendar
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Get the selected date from the MonthCalendar
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;

            // Call the method to display the date events
            LoadEvents(selectedDate);
        }

        // Method to retrieve the events from the database for a specific date
        private void LoadEvents(DateTime date)
        {
            // Create the connection to the database
            var connection = new SQLiteConnection(connectionString);

            try
            {
                // Open connection
                connection.Open();

                // SQL query to retrieve events based on date
                string searchSQL = "SELECT Description FROM Events WHERE Date = @Date";

                // Create the SQLiteCommand
                var command = new SQLiteCommand(searchSQL, connection);

                // Add the parameter for the date
                command.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                // Execute the command and retrieve the data
                var reader = command.ExecuteReader();

                // Clear the richTextBox before displaying the events
                richTextBox1.Clear();

                // Display the results in the richTextBox
                while (reader.Read())
                {
                    string eventDescription = reader["Description"].ToString();
                    richTextBox1.AppendText($"- {eventDescription}\n\n");
                }

                // If there are no events for the date, we display a message
                if (richTextBox1.Text == "")
                {
                    richTextBox1.Text = "There are no events for the selected date.";
                }

                // Close the reader after retrieving the data
                reader.Close();
            }
            catch (Exception ex)
            {
                // Display the error message if something goes wrong
                MessageBox.Show("Error retrieving events: " + ex.Message);
            }
            finally
            {
                // Close the connection to the database
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to exit the application?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUpForm Form9 = new SignUpForm();
            Form9.Show();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                LoginForm Form8 = new LoginForm();
                Form8.Show();
            }
            else
            {
                if (MessageBox.Show("You are already logged in as: " + UserSession.Username + ". Do you want to log out?", "Login",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Handle sign-out logic here
                    UserSession.IsLoggedIn = false;  // Sign out the user
                    MainPage Form1 = new MainPage();   // Show login form
                    Form1.Show();
                    this.Hide();
                }
            }
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile form13 = new UserProfile();
            form13.Show();
        }
    }
}
