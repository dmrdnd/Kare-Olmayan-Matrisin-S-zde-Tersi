using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlab1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            random.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ElleGiris ellegiris = new ElleGiris();
            ellegiris.Show();
        }
    }
}
