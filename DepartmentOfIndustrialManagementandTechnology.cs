using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class DepartmentOfIndustrialManagementandTechnology : Form
    {
        public DepartmentOfIndustrialManagementandTechnology()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form6_Load);
        }
        private void Form6_Load(object sender, EventArgs e)
        {
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

        private void CalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Announcements form7 = new Announcements();
            form7.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("\"Do you want to exit the application?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
