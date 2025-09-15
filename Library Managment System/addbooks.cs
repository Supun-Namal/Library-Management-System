using System;
using System.Data;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class addbooks : Form
    {
        DataTable Add_Books;

        public addbooks()
        {
            InitializeComponent();

            // Initialize the DataTable
            Add_Books = new DataTable("Add_Books");

            // Define columns
            DataColumn BookId = new DataColumn("Book_ID", typeof(Int32));
            Add_Books.Columns.Add(BookId);

            DataColumn BookName = new DataColumn("Book_Name", typeof(string));
            Add_Books.Columns.Add(BookName);

            DataColumn BookSubject = new DataColumn("Book_Subject", typeof(string));
            Add_Books.Columns.Add(BookSubject);

            DataColumn Author = new DataColumn("Author", typeof(string));
            Add_Books.Columns.Add(Author);

            DataColumn NoofCopies = new DataColumn("No_of_Copies", typeof(Int32));
            Add_Books.Columns.Add(NoofCopies);

            DataColumn ShelfNumber = new DataColumn("Shelf_Number", typeof(Int32));
            Add_Books.Columns.Add(ShelfNumber);

            DataColumn Published = new DataColumn("Published", typeof(string));
            Add_Books.Columns.Add(Published);

            // Bind the DataTable to the DataGridView
            dataGridViewAddBooks.DataSource = Add_Books;
        }

        

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Sure Want To Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddBooks.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewAddBooks.SelectedRows[0].Index;

                // Update the selected row in the DataTable with new values
                Add_Books.Rows[rowIndex]["Book_ID"] = Convert.ToInt32(txtBid.Text);
                Add_Books.Rows[rowIndex]["Book_Name"] = txtBname.Text;
                Add_Books.Rows[rowIndex]["Book_Subject"] = txtBsubject.Text;
                Add_Books.Rows[rowIndex]["Author"] = txtAuthor.Text;
                Add_Books.Rows[rowIndex]["No_of_Copies"] = Convert.ToInt32(txtCopies.Text);
                Add_Books.Rows[rowIndex]["Shelf_Number"] = Convert.ToInt32(txtShelf.Text);
                Add_Books.Rows[rowIndex]["Published"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Add_Books.Rows.Add(
                Convert.ToInt32(txtBid.Text),
                txtBname.Text,
                txtBsubject.Text,
                txtAuthor.Text,
                Convert.ToInt32(txtCopies.Text),
                Convert.ToInt32(txtShelf.Text),
                dateTimePicker1.Value.ToString("yyyy-MM-dd")
            );

            MessageBox.Show("Save Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtBid.Clear();
            txtBname.Clear();
            txtBsubject.Clear();
            txtAuthor.Clear();
            txtCopies.Clear();
            txtShelf.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnDelet_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewAddBooks.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewAddBooks.SelectedRows[0].Index;
                Add_Books.Rows[rowIndex].Delete();
                MessageBox.Show("Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Sure Want To Go Dashboard?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
