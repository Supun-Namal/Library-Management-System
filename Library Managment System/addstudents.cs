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
    public partial class addstudents : Form
    {
        DataTable Student_Details;

        public addstudents()
        {
            InitializeComponent();

            // Initialize the DataTable
            Student_Details = new DataTable("Student_Details");

            // Define columns
            DataColumn StudentId = new DataColumn("Student_ID", typeof(Int32));
            Student_Details.Columns.Add(StudentId);

            DataColumn FirstName = new DataColumn("First_Name", typeof(string));
            Student_Details.Columns.Add(FirstName);

            DataColumn LastName = new DataColumn("Last_Name", typeof(string));
            Student_Details.Columns.Add(LastName);

            DataColumn Birthday = new DataColumn("Birthday", typeof(string));
            Student_Details.Columns.Add(Birthday);

            DataColumn MobileNumber = new DataColumn("Mobile_Number", typeof(string));
            Student_Details.Columns.Add(MobileNumber);

            DataColumn Gender = new DataColumn("Gender", typeof(string));
            Student_Details.Columns.Add(Gender);

            DataColumn Grade = new DataColumn("Grade", typeof(string));
            Student_Details.Columns.Add(Grade);

            DataColumn Address = new DataColumn("Address", typeof(string));
            Student_Details.Columns.Add(Address);


            // Bind the DataTable to the DataGridView
            dataGridViewStudents.DataSource = Student_Details;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            //Close
            DialogResult check = MessageBox.Show("Are You Sure Want To Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                //  selected gender
                string gender = radioMale.Checked ? "Male" : "Female";

                // Add a new row to the DataTable
                Student_Details.Rows.Add(
                    Convert.ToInt32(txtId.Text),
                    txtFname.Text,
                    txtLname.Text,
                    dateTimePicker1.Value.ToString("yyyy-MM-dd"), // Format birthday
                    txtMobile.Text,
                    gender,
                    txtGrade.Text,
                    richTxtAddress.Text
                );
                MessageBox.Show("Save Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtFname.Clear();
            txtLname.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtMobile.Clear();
            radioMale.Checked = false;     // Uncheck Male radio button
            radioFemale.Checked = false;   // Uncheck Female radio button
            txtGrade.Clear();
            richTxtAddress.Clear();
        }

     
        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewStudents.SelectedRows[0].Index;
                Student_Details.Rows[rowIndex].Delete();

                MessageBox.Show("Dlelted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewStudents.SelectedRows[0].Index;

                // Update selected row with new data
                Student_Details.Rows[rowIndex]["Student_ID"] = Convert.ToInt32(txtId.Text);
                Student_Details.Rows[rowIndex]["First_Name"] = txtFname.Text;
                Student_Details.Rows[rowIndex]["Last_Name"] = txtLname.Text;
                Student_Details.Rows[rowIndex]["Birthday"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                Student_Details.Rows[rowIndex]["Mobile_Number"] = txtMobile.Text;
                Student_Details.Rows[rowIndex]["Gender"] = radioMale.Checked ? "Male" : "Female";
                Student_Details.Rows[rowIndex]["Grade"] = txtGrade.Text;
                Student_Details.Rows[rowIndex]["Address"] = richTxtAddress.Text;

                MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void richTxtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Sure Want To Go Dashboard?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                //Dashboard open //
                dashboard form = new dashboard();
                form.Show();
                this.Hide();
            }

        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            // Minimize 
            this.WindowState = FormWindowState.Minimized;
        }
    }
}