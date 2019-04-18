﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Windows.Forms;

namespace MainForm
{
    public enum BarEnum
    {
        BAR,
        PIE
    }
    public class CharController
    {
        //長條圖
        Chart BarChart = null;
        //圓餅圖
        Chart PieChart = null;
        Form parentform = null;

        #region 事件相關資料
        DateTime dtStartTime;
        DateTime dtEndTime;
        // 事件統計值
        Dictionary<string, int> dcEvent = new Dictionary<string, int>();
        public CharController(Form form)
        {
            parentform = form;
        }
        #endregion

        #region 事件統計值相關
        public void CalculateEvent(DateTime dtstarttime,DateTime dtendtime, List<JWebEventInfo> listData)
        {
            dtStartTime = dtstarttime;
            dtEndTime = dtendtime;
            foreach (var item in listData)
            {
                if(Between(item.uploaded_time,dtstarttime,dtendtime))
                {
                    if (!dcEvent.ContainsKey(item.event_name))
                    {
                        dcEvent.Add(item.event_name, 1);
                    }
                    else
                    {
                        dcEvent[item.event_name]++;
                    }
                }
            }
        }
        void OutputPieChatData(List<string> xValues, List<int> yValues)
        {
            foreach (var item in dcEvent)
            {
                xValues.Add(item.Key);
                yValues.Add(item.Value);
            }
        }
        /// <summary>
        /// 日期比較
        /// </summary>
        /// <param name="input"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool Between(DateTime input, DateTime date1, DateTime date2)
        {
            return (input >= date1 && input <= date2);
        }
        #endregion
        
        public void ShowChart(BarEnum barEnum= BarEnum.BAR)
        {
            switch (barEnum)
            {
                case BarEnum.BAR:
                    CreateBarChart();
                    break;
                case BarEnum.PIE:
                    CreatePieChart();
                    break;
            }
        }
        #region 建立長條圖
        void CreateBarChart()
        {
            if (BarChart != null)
            {
                parentform.Controls.Remove(BarChart);
                BarChart = null;
            }
            //ChartAreas,Series,Legends 基本設定--------------------------------------------------
            BarChart = new Chart();
            BarChart.ChartAreas.Add("ChartArea1"); //圖表區域集合
            BarChart.Series.Add("Series1"); //數據序列集合
            //設定 Chart
            BarChart.Width = parentform.ClientRectangle.Width;
            BarChart.Height = parentform.ClientRectangle.Height;
            Title title = new Title();
            //標題文字
            title.Text = dtStartTime.ToString("yyyy-MM-dd") + "~" + dtEndTime.ToString("yyyy-MM-dd"); // "圓餅圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            BarChart.Titles.Add(title);
            //設定 ChartArea----------------------------------------------------------------------
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true; //3D效果
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true; //並排顯示
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 40; //垂直角度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 50; //水平角度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = 10; //數據條深度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0; //外牆寬度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic; //光源
            BarChart.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(240, 240, 240); //背景色
            //Y 軸線顏色
            BarChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            //X軸背景區塊隔行變色
            //BarChart.ChartAreas["ChartArea1"].AxisX.IsInterlaced = true;
            //表示X軸上的所有標籤都會顯示
            BarChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            ////X 軸線顏色
            BarChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            //X軸邊界不留空格
            BarChart.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
            //Y坐標尺規的間距
            //BarChart.ChartAreas["ChartArea1"].AxisY.Interval = 100;
            ////設定 Series-----------------------------------------------------------------------
            BarChart.Series["Series1"].ChartType = SeriesChartType.Column; //直條圖
                                                                           //Chart1.Series["Series1"].ChartType = SeriesChartType.Bar; //橫條圖
                                                                           //設定長𪝉圖寬度                                                                
                                                                           //BarChart.Series["Series1"]["PointWidth"] = "0.2";


            //////////BarChart.Series["Series1"].Points.DataBindXY(xValues, yValues);
            //將資料塞入Chart Controls
            int Interlacedcount = 0;
            foreach (var item in dcEvent)
            {
                BarChart.Series["Series1"].Points.AddXY(item.Key, item.Value);
                if (Interlacedcount % 2 == 0) //交錯顯示
                    BarChart.Series["Series1"].Points[Interlacedcount].Color = Color.Orange;
                Interlacedcount++;
            }
            
            BarChart.Series["Series1"].IsValueShownAsLabel = true; //顯示數據
            //X坐標軸說明文字
            //BarChart.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.BlueViolet;
            //BarChart.ChartAreas["ChartArea1"].AxisX.Title = dtStartTime.ToString("yyyy-MM-dd")+"~"+ dtEndTime.ToString("yyyy-MM-dd");
            //Y坐標軸說明文字
            BarChart.ChartAreas["ChartArea1"].AxisY.Title = "Count";
            //
            parentform.Controls.Add(BarChart);
        }
        
        #endregion

        #region 建立圖餅圖
        void CreatePieChart()
        {
            if (PieChart != null)
            {
                parentform.Controls.Remove(PieChart);
                PieChart = null;
            }
            //建立資料
            List<string> dataX = new List<string>();
            List<int> dataY = new List<int>();
            OutputPieChatData(dataX, dataY);
            string[] xValues = dataX.ToArray();//{ "0-20", "20-30", "30-40", "40-50", "50-60", "> 60", "unknow" };
            int[] yValues = dataY.ToArray(); //{ 5, 18, 45, 17, 2, 1, 162 };

            //ChartAreas,Series,Legends 基本設定-------------------------------------------------
            PieChart = new Chart();
            PieChart.ChartAreas.Add("ChartArea1"); //圖表區域集合
            PieChart.Legends.Add("Legends1"); //圖例集合說明
            PieChart.Series.Add("Series1"); //數據序列集合

            //設定 Chart-------------------------------------------------------------------------
            PieChart.Width = parentform.ClientRectangle.Width;
            PieChart.Height = parentform.ClientRectangle.Height;
            //標題文字
            Title title = new Title();
            title.Text = dtStartTime.ToString("yyyy-MM-dd") + "~" + dtEndTime.ToString("yyyy-MM-dd"); // "圓餅圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            PieChart.Titles.Add(title);
            
            //設定 ChartArea1--------------------------------------------------------------------
            PieChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //PieChart.ChartAreas[0].AxisX.Interval = 1;

            //設定 Legends-------------------------------------------------------------------------                
            //Chart1.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
            //Chart1.Legends["Legends1"].Docking = Docking.Bottom; //自訂顯示位置
            //背景色
            PieChart.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235);
            //斜線背景
            PieChart.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            PieChart.Legends["Legends1"].BorderWidth = 1;
            PieChart.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

            //設定 Series1-----------------------------------------------------------------------
            PieChart.Series["Series1"].ChartType = SeriesChartType.Pie;
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
            PieChart.Series["Series1"].Points.DataBindXY(xValues, yValues);
            PieChart.Series["Series1"].LegendText = "#VALX:    [ #PERCENT{P1} ]"; //X軸 + 百分比
            PieChart.Series["Series1"].Label = "#VALX\n#PERCENT{P1}"; //X軸 + 百分比
            //Chart1.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色
            //字體設定
            PieChart.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            PieChart.Series["Series1"].Points.FindMaxByValue().LabelForeColor = Color.Red;
            //Chart1.Series["Series1"].Points.FindMaxByValue().Color = Color.Red;
            //Chart1.Series["Series1"].Points.FindMaxByValue()["Exploded"] = "true";
            PieChart.Series["Series1"].BorderColor = Color.FromArgb(255, 101, 101, 101);

            //Chart1.Series["Series1"]["DoughnutRadius"] = "80"; // ChartType為Doughnut時，Set Doughnut hole size
            //Chart1.Series["Series1"]["PieLabelStyle"] = "Inside"; //數值顯示在圓餅內
            PieChart.Series["Series1"]["PieLabelStyle"] = "Outside"; //數值顯示在圓餅外
            //Chart1.Series["Series1"]["PieLabelStyle"] = "Disabled"; //不顯示數值
            //設定圓餅效果，除 Default 外其他效果3D不適用
            PieChart.Series["Series1"]["PieDrawingStyle"] = "Default";
            //Chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
            //Chart1.Series["Series1"]["PieDrawingStyle"] = "Concave";

            

            parentform.Controls.Add(PieChart);
            //
        }
        
        #endregion

        // windows 的大小有改變
        public void WindowSizeChange()
        {
            if (BarChart != null)
            {
                BarChart.Width = parentform.ClientRectangle.Width;
                BarChart.Height = parentform.ClientRectangle.Height;
            }
            if(PieChart!=null)
            {
                PieChart.Width = parentform.ClientRectangle.Width;
                PieChart.Height = parentform.ClientRectangle.Height;
            }
        }

    }
}
