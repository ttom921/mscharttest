using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainForm
{
    public partial class MainForm : Form
    {
        GenJWebEvent genJWebEvent = new GenJWebEvent();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCallChar_Click(object sender, EventArgs e)
        {
            FormChart frm2 = new FormChart(this);
            frm2.ShowEventStatistics("", "", null);
            //frm2.Show();
        }

        private void btnGenData_Click(object sender, EventArgs e)
        {
            genJWebEvent.GenTestData();
        }
    }
}
