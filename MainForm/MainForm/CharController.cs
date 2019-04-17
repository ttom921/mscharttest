using System;
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
        Chart BarChart = null;
        Chart PieChart = null;
        Form parentform = null;
        BarEnum ShowBarState = BarEnum.BAR;
        public CharController(Form form)
        {
            parentform = form;
        }
        public void ShowChart(BarEnum barEnum= BarEnum.BAR)
        {
            switch (barEnum)
            {
                case BarEnum.BAR:
                    CreateBarChart();
                    showbar();
                    break;
                case BarEnum.PIE:
                    CreatePieChart();
                    showpie();
                    break;
            }
        }
        void showbar()
        {
            if (BarChart == null) return;
            BarChart.Visible = true;
            if (PieChart == null) return;
            PieChart.Visible = false;
        }
        void showpie()
        {
            if (BarChart == null) return;
            BarChart.Visible = false;
            if (PieChart == null) return;
            PieChart.Visible = true;
        }
        void  CreateBarChart()
        {
            if (BarChart != null) return;
            string[] xValues = { "數值1", "數值2" };
            string[] titleArr = { "活動1", "活動2" };
            int[] yValues = { 269000, 94 };
            int[] yValues2 = { 120300, 116 };

            //ChartAreas,Series,Legends 基本設定--------------------------------------------------
            BarChart = new Chart();
            BarChart.ChartAreas.Add("ChartArea1"); //圖表區域集合
            BarChart.Series.Add("Series1"); //數據序列集合
            BarChart.Series.Add("Series2");
            BarChart.Legends.Add("Legends1"); //圖例集合

            //設定 Chart
            BarChart.Width = parentform.ClientRectangle.Width;
            BarChart.Height = parentform.ClientRectangle.Height;
            BarChart.Margin = new Padding(100, 100, 100, 100);
            Title title = new Title();
            title.Text = "長條圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            //title.Position.Height = 10;
            //title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            BarChart.Titles.Add(title);

            //設定 ChartArea----------------------------------------------------------------------
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true; //3D效果
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true; //並排顯示
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 40; //垂直角度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 50; //水平角度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = 30; //數據條深度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0; //外牆寬度
            BarChart.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic; //光源
            BarChart.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(240, 240, 240); //背景色
            BarChart.ChartAreas["ChartArea1"].AxisX2.Enabled = AxisEnabled.False; //隱藏 X2 標示
            BarChart.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.False; //隱藏 Y2 標示
            BarChart.ChartAreas["ChartArea1"].AxisY2.MajorGrid.Enabled = false;   //隱藏 Y2 軸線
            //Y 軸線顏色
            BarChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            //X 軸線顏色
            BarChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            BarChart.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "#,###";
            //Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 160;
            //Chart1.ChartAreas["ChartArea1"].AxisY2.Interval = 20;

            //設定 Legends------------------------------------------------------------------------                
            BarChart.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
            //Chart1.Legends["Legends1"].Docking = Docking.Bottom; //自訂顯示位置
            BarChart.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235); //背景色
            //斜線背景
            BarChart.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            BarChart.Legends["Legends1"].BorderWidth = 1;
            BarChart.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

            //設定 Series-----------------------------------------------------------------------
            BarChart.Series["Series1"].ChartType = SeriesChartType.Column; //直條圖
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Bar; //橫條圖
            BarChart.Series["Series1"].Points.DataBindXY(xValues, yValues);
            BarChart.Series["Series1"].Legend = "Legends1";
            BarChart.Series["Series1"].LegendText = titleArr[0];
            BarChart.Series["Series1"].LabelFormat = "#,###"; //金錢格式
            BarChart.Series["Series1"].MarkerSize = 8; //Label 範圍大小
            BarChart.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色
            //字體設定
            //Chart1.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            //Label 背景色
            BarChart.Series["Series1"].LabelBackColor = Color.FromArgb(150, 255, 255, 255);
            BarChart.Series["Series1"].Color = Color.FromArgb(240, 65, 140, 240); //背景色
            BarChart.Series["Series1"].IsValueShownAsLabel = true; // Show data points labels

            BarChart.Series["Series2"].Points.DataBindXY(xValues, yValues2);
            BarChart.Series["Series2"].Legend = "Legends1";
            BarChart.Series["Series2"].LegendText = titleArr[1];
            BarChart.Series["Series2"].LabelFormat = "#,###"; //金錢格式
            BarChart.Series["Series2"].MarkerSize = 8; //Label 範圍大小
            BarChart.Series["Series2"].LabelForeColor = Color.FromArgb(255, 103, 0);
            BarChart.Series["Series2"].Font = new System.Drawing.Font("Trebuchet MS", 10, FontStyle.Bold);
            BarChart.Series["Series2"].LabelBackColor = Color.FromArgb(150, 255, 255, 255);
            BarChart.Series["Series2"].Color = Color.FromArgb(240, 252, 180, 65); //背景色
            BarChart.Series["Series2"].IsValueShownAsLabel = true; //顯示數據
            //
            parentform.Controls.Add(BarChart);
            //
            
        }
        void CreatePieChart()
        {
            if (PieChart != null) return;
            string[] xValues = { "0-20", "20-30", "30-40", "40-50", "50-60", "> 60", "unknow" };
            int[] yValues = { 5, 18, 45, 17, 2, 1, 162 };

            //ChartAreas,Series,Legends 基本設定-------------------------------------------------
            PieChart = new Chart();
            PieChart.ChartAreas.Add("ChartArea1"); //圖表區域集合
            PieChart.Legends.Add("Legends1"); //圖例集合說明
            PieChart.Series.Add("Series1"); //數據序列集合

            //設定 Chart-------------------------------------------------------------------------
            PieChart.Width = parentform.ClientRectangle.Width;
            PieChart.Height = parentform.ClientRectangle.Height;
            Title title = new Title();
            title.Text = "圓餅圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            PieChart.Titles.Add(title);

            //設定 ChartArea1--------------------------------------------------------------------
            PieChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            PieChart.ChartAreas[0].AxisX.Interval = 1;

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

            //Random rnd = new Random();  //亂數產生區塊顏色
            //foreach (DataPoint point in Chart1.Series["Series1"].Points)
            //{
            //    //pie 顏色
            //    point.Color = Color.FromArgb(150, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)); 
            //}
            //
            parentform.Controls.Add(PieChart);
            //
        }
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
