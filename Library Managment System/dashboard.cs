using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Sure Want To Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }


        }

        private void btnAddstudent_Click(object sender, EventArgs e)
        {
            //Add student form will be open//
            addstudents form = new addstudents();
            form.Show();
            this.Hide();

        }

       

        private void lblClo_Click(object sender, EventArgs e)
        {
            //Close
            DialogResult check = MessageBox.Show("Are You Sure Want To Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAddbooks_Click(object sender, EventArgs e)
        {
            //Add books will be open//
            addbooks form = new addbooks();
            form.Show();
            this.Hide();
        }

        private void btnIssueBooks_Click(object sender, EventArgs e)
        {
            //Issu books will be open//
            issuebooks form = new issuebooks();
            form.Show();
            this.Hide();
        }

       
        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            //Return books reports will be open//
            returnbooksreport form = new returnbooksreport();
            form.Show();
            this.Hide();
        }

        private void btnIssuedBooksReport_Click(object sender, EventArgs e)
        {
            //Issued books reports will be open//
            issuedbooksreport form = new issuedbooksreport();
            form.Show();
            this.Hide();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            // Minimize 
            this.WindowState = FormWindowState.Minimized;
        }

        


        }

    }

