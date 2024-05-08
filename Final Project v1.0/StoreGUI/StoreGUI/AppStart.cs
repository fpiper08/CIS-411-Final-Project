using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreGUI
{
    public partial class AppStart : Form
    {
        public AppStart()
        {
            InitializeComponent();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Queries Form1 = new Queries();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayEditTables Form3 = new DisplayEditTables();
            Form3.Show();
        }
    }
}
