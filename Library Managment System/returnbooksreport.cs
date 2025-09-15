using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO; // Added for File handling
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class returnbooksreport : Form
    {
        public returnbooksreport()
        {
            InitializeComponent();
        }

       

        

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            // Define the file path to auto-load the file
            string filePath = @"D:\New Project\Library Managment System\Report Files\Return Books Report.txt"; // Replace with your desired file path

            // Check if the file exists
            if (File.Exists(filePath))
            {
                LoadDataFromTextFile(filePath); // Call method to load data
            }
            else
            {
                MessageBox.Show("File not found at the specified location.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadDataFromTextFile(string filePath)
        {
            try
            {
                // Step 1: Read all lines from the text file
                string[] lines = File.ReadAllLines(filePath);

                // Step 2: Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Step 3: Loop through the lines and create columns and rows
                foreach (string line in lines)
                {
                    // Step 4: Split the line into columns (e.g., assuming CSV format)
                    string[] columns = line.Split(',');

                    // Step 5: Add columns if it's the first line (header)
                    if (dataTable.Columns.Count == 0)
                    {
                        foreach (string column in columns)
                        {
                            dataTable.Columns.Add(column.Trim()); // Add column to DataTable
                        }
                    }
                    else
                    {
                        // Step 6: Add rows to DataTable for each subsequent line
                        dataTable.Rows.Add(columns);
                    }
                }

                // Step 7: Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., file read error)
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            DialogResult check = MessageBox.Show("Are you sure you want to go to the dashboard?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                dashboard form = new dashboard();
                form.Show();
                this.Hide();
            }
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

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            // Minimize 
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
