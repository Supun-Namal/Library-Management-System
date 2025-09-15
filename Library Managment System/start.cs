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
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            panel2.Width += 3;

            if (panel2.Width >= 800)
            {
                timer1.Stop();
                Form1 fm = new Form1();
                this.Hide();
                fm.Show();
            }
        }
    }
}
