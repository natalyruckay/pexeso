using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uloha7_pexeso
{
    public partial class start : Form
    {
        private Form1 form1;
        public start()
        {
            InitializeComponent();
        }

        private void button1start_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
            Hide();
        }

    }
}
