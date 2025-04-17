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
    public partial class Benefits : Form
    {
        private RichTextBox[] richTextBoxesPage1;
        private RichTextBox[] richTextBoxesPage2;
        private Label[] labelsPage1;
        private Label[] labelsPage2;
        private int currentPage = 1;
        public Benefits()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form3_Load);

            // Initialize richtextBoxes and labels for the 1st and 2nd page with an array
            richTextBoxesPage1 = new[] { richTextBox1, richTextBox2, richTextBox3 };
            richTextBoxesPage2 = new[] { richTextBox4, richTextBox5, richTextBox6 };
            labelsPage1 = new Label[] {label2, label3, label4};
            labelsPage2 = new Label[] {label5,  label6, label7};

            //  Initialize visibility
            ShowPage(1);
        }
        private void Form3_Load(object sender, EventArgs e)
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

        // Event handler for right button "Next"
        private void right_button_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            {
                ShowPage(2);
            }
        }

        // Event handler for left button "Previous"
        private void left_button_Click(object sender, EventArgs e)
        {
            if (currentPage == 2)
            {
                ShowPage(1);
            }
        }

        //Method to display the correct page
        private void ShowPage(int page)
        {
            if (page == 1)
            {
                // Shows the contents of the 1st page and hides the 2nd
                foreach (var rtb in richTextBoxesPage1)
                {
                    rtb.Visible = true;
                }

                foreach (var rtb in richTextBoxesPage2)
                {
                    rtb.Visible = false;
                }
                foreach (var lbl in labelsPage1)
                {
                    lbl.Visible = true;
                }

                foreach (var lbl in labelsPage2)
                {
                    lbl.Visible = false;
                }

                currentPage = 1;
            }
            else if (page == 2)
            {
                // Shows the contents of the 2nd page and hides the 1st
                foreach (var rtb in richTextBoxesPage1)
                {
                    rtb.Visible = false;
                }

                foreach (var rtb in richTextBoxesPage2)
                {
                    rtb.Visible = true;
                }
                foreach (var lbl in labelsPage1)
                {
                    lbl.Visible = false;
                }

                foreach (var lbl in labelsPage2)
                {
                    lbl.Visible = true;
                }

                currentPage = 2;
            }

            // Disable buttons if unable to move to another page
            left_button.Enabled = currentPage == 2;
            right_button.Enabled = currentPage == 1;
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

        private void ActToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activities form4 = new Activities();
            form4.Show();
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

        private void CalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Announcements form7 = new Announcements();
            form7.Show();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the application?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile form13 = new UserProfile();
            form13.Show();
        }
    }
}
