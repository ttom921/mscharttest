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
        List<JWebEventInfo> jWebEventInfos = new List<JWebEventInfo>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCallChar_Click(object sender, EventArgs e)
        {
            string startdate = "2019-03-29  00:00:00";
            string endate = "2019-03-30 23:00:00";
            FormChart frm2 = new FormChart(this);
            frm2.ShowEventStatistics(startdate, endate, jWebEventInfos);
        }

        private void btnGenData_Click(object sender, EventArgs e)
        {
            jWebEventInfos=genJWebEvent.GenTestData();
        }

        private void btnCallPie_Click(object sender, EventArgs e)
        {
            string startdate = "2019-03-29  00:00:00";
            string endate = "2019-03-30 23:00:00";
            FormChart frm2 = new FormChart(this, BarEnum.PIE);
            frm2.ShowEventStatistics(startdate, endate, jWebEventInfos);
        }
    }
}
