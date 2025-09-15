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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            if(txtName.Text == "Admin" && txtPass.Text == "1234")
            {
                //Dashboard open //
                dashboard form = new dashboard();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {
            //Close
            DialogResult check = MessageBox.Show("Are You Sure Want To Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
             //register form open //
                Register form = new Register();
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
  
