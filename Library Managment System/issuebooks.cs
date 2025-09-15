using System;
using System.Data;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class issuebooks : Form
    {
        DataTable Issue_Books;

        public issuebooks()
        {
            InitializeComponent();

            // Initialize the DataTable
            Issue_Books = new DataTable("Issue_Books");

            // Define columns
            DataColumn BookId = new DataColumn("Book_ID", typeof(Int32));
            Issue_Books.Columns.Add(BookId);

            DataColumn BookName = new DataColumn("Book_Name", typeof(string));
            Issue_Books.Columns.Add(BookName);

            DataColumn StudentID = new DataColumn("Student_ID", typeof(Int32));
            Issue_Books.Columns.Add(StudentID);

            DataColumn StudentName = new DataColumn("Student_Name", typeof(string)); // Fixed column name typo
            Issue_Books.Columns.Add(StudentName);

            DataColumn IssueDate = new DataColumn("Issue_Date", typeof(string));
            Issue_Books.Columns.Add(IssueDate);

            DataColumn DueDate = new DataColumn("Due_Date", typeof(string));
            Issue_Books.Columns.Add(DueDate);

            // Bind the DataTable to the DataGridView
            dataGridViewIssueBooks.DataSource = Issue_Books;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Add a new row to the DataTable
            Issue_Books.Rows.Add(
                Convert.ToInt32(txtBid.Text),
                txtBname.Text,
                Convert.ToInt32(txtStudentId.Text),
                txtStudentName.Text,
                issueDate.Value.ToString("yyyy-MM-dd"),
                dueDate.Value.ToString("yyyy-MM-dd")
            );

            MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewIssueBooks.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewIssueBooks.SelectedRows[0].Index;

                // Update the selected row in the DataTable with new values
                Issue_Books.Rows[rowIndex]["Book_ID"] = Convert.ToInt32(txtBid.Text);
                Issue_Books.Rows[rowIndex]["Book_Name"] = txtBname.Text;
                Issue_Books.Rows[rowIndex]["Student_ID"] = Convert.ToInt32(txtStudentId.Text);
                Issue_Books.Rows[rowIndex]["Student_Name"] = txtStudentName.Text; 
                Issue_Books.Rows[rowIndex]["Issue_Date"] = issueDate.Value.ToString("yyyy-MM-dd");
                Issue_Books.Rows[rowIndex]["Due_Date"] = dueDate.Value.ToString("yyyy-MM-dd"); 

                MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            txtBid.Clear();
            txtBname.Clear();
            txtStudentId.Clear();
            txtStudentName.Clear();
            issueDate.Value = DateTime.Now;
            dueDate.Value = DateTime.Now;
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (dataGridViewIssueBooks.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewIssueBooks.SelectedRows[0].Index;
                Issue_Books.Rows[rowIndex].Delete();
                MessageBox.Show("Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            // Minimize 
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
