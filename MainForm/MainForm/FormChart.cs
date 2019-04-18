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
    public partial class FormChart : Form
    {
        /// <summary>
        /// 圖表控制
        /// </summary>
        CharController charController = null;

        public FormChart()
        {
            InitializeComponent();
        }
        public FormChart(Form parent)
        {
            InitializeComponent();
            this.Owner= parent;
            charController = new CharController(this);
            //charController.ShowChart(BarEnum.BAR);
        }
        // <summary>
        /// Constructor, initialize component
        /// </summary>
        /// <param name="startDat">起始時間 (字串模式)</param>
        /// <param name="endDate">結束時間 (字串模式)</param>
        /// <param name="listData">JWebEventInfo 結構列表</param>
        public void ShowEventStatistics(string startDate, string endDate, List<JWebEventInfo> listData)
        {
            try
            {
                DateTime dtStartTime = Convert.ToDateTime(startDate);
                DateTime dtEndTime = Convert.ToDateTime(endDate);
                charController.CalculeEvent(dtStartTime, dtEndTime, listData);
                charController.ShowChart(BarEnum.BAR);
                //charController.ShowChart(BarEnum.PIE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            this.Show();
        }
        /// <summary>
        /// 視窗大小改變
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChart_SizeChanged(object sender, EventArgs e)
        {
            if (charController != null)
            {
                charController.WindowSizeChange();
            }
            
        }
    }
}
