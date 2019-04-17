using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.DataVisualization.Charting.Chart Chart1 = null;

        public Form1()
        {
            InitializeComponent();
            CreatePieChar();
        }
        /// <summary>
        /// 圓餅圖
        /// </summary>
        void CreatePieChar()
        {
            string[] xValues = { "0-20", "20-30", "30-40", "40-50", "50-60", "> 60", "unknow" };
            int[] yValues = { 5, 18, 45, 17, 2, 1, 162 };

            //ChartAreas,Series,Legends 基本設定-------------------------------------------------
            Chart1 = new Chart();
            Chart1.ChartAreas.Add("ChartArea1"); //圖表區域集合
            Chart1.Legends.Add("Legends1"); //圖例集合說明
            Chart1.Series.Add("Series1"); //數據序列集合

            //設定 Chart-------------------------------------------------------------------------
            Chart1.Width = this.Width;
            Chart1.Height = this.Height;
            Title title = new Title();
            title.Text = "圓餅圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            Chart1.Titles.Add(title);

            //設定 ChartArea1--------------------------------------------------------------------
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.ChartAreas[0].AxisX.Interval = 1;

            //設定 Legends-------------------------------------------------------------------------                
            //Chart1.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
            //Chart1.Legends["Legends1"].Docking = Docking.Bottom; //自訂顯示位置
            //背景色
            Chart1.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235);
            //斜線背景
            Chart1.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            Chart1.Legends["Legends1"].BorderWidth = 1;
            Chart1.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

            //設定 Series1-----------------------------------------------------------------------
            Chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;
            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Series1"].LegendText = "#VALX:    [ #PERCENT{P1} ]"; //X軸 + 百分比
            Chart1.Series["Series1"].Label = "#VALX\n#PERCENT{P1}"; //X軸 + 百分比
            //Chart1.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色
            //字體設定
            Chart1.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            Chart1.Series["Series1"].Points.FindMaxByValue().LabelForeColor = Color.Red;
            //Chart1.Series["Series1"].Points.FindMaxByValue().Color = Color.Red;
            //Chart1.Series["Series1"].Points.FindMaxByValue()["Exploded"] = "true";
            Chart1.Series["Series1"].BorderColor = Color.FromArgb(255, 101, 101, 101);

            //Chart1.Series["Series1"]["DoughnutRadius"] = "80"; // ChartType為Doughnut時，Set Doughnut hole size
            //Chart1.Series["Series1"]["PieLabelStyle"] = "Inside"; //數值顯示在圓餅內
            Chart1.Series["Series1"]["PieLabelStyle"] = "Outside"; //數值顯示在圓餅外
            //Chart1.Series["Series1"]["PieLabelStyle"] = "Disabled"; //不顯示數值
            //設定圓餅效果，除 Default 外其他效果3D不適用
            Chart1.Series["Series1"]["PieDrawingStyle"] = "Default";
            //Chart1.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
            //Chart1.Series["Series1"]["PieDrawingStyle"] = "Concave";

            //Random rnd = new Random();  //亂數產生區塊顏色
            //foreach (DataPoint point in Chart1.Series["Series1"].Points)
            //{
            //    //pie 顏色
            //    point.Color = Color.FromArgb(150, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)); 
            //}
            this.Controls.Add(this.Chart1);
        }
        /// <summary>
        /// 長條圖
        /// </summary>
        void CreateChart()
        {
            string[] xValues = { "數值1", "數值2" };
            string[] titleArr = { "活動1", "活動2" };
            int[] yValues = { 269000, 94 };
            int[] yValues2 = { 120300, 116 };

            //ChartAreas,Series,Legends 基本設定--------------------------------------------------
            Chart1 = new Chart();
            Chart1.ChartAreas.Add("ChartArea1"); //圖表區域集合
            Chart1.Series.Add("Series1"); //數據序列集合
            Chart1.Series.Add("Series2");
            Chart1.Legends.Add("Legends1"); //圖例集合

            //設定 Chart
            Chart1.Width = 400;
            Chart1.Height = 200;
            Title title = new Title();
            title.Text = "長條圖";
            title.Alignment = ContentAlignment.MiddleCenter;
            //title.Font = new System.Drawing.Font("Trebuchet MS", 14F, FontStyle.Bold);
            Chart1.Titles.Add(title);

            //設定 ChartArea----------------------------------------------------------------------
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true; //3D效果
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = true; //並排顯示
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 40; //垂直角度
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 50; //水平角度
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = 30; //數據條深度
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0; //外牆寬度
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic; //光源
            Chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(240, 240, 240); //背景色
            Chart1.ChartAreas["ChartArea1"].AxisX2.Enabled = AxisEnabled.False; //隱藏 X2 標示
            Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.False; //隱藏 Y2 標示
            Chart1.ChartAreas["ChartArea1"].AxisY2.MajorGrid.Enabled = false;   //隱藏 Y2 軸線
            //Y 軸線顏色
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            //X 軸線顏色
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromArgb(150, 150, 150);
            Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "#,###";
            //Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 160;
            //Chart1.ChartAreas["ChartArea1"].AxisY2.Interval = 20;

            //設定 Legends------------------------------------------------------------------------                
            Chart1.Legends["Legends1"].DockedToChartArea = "ChartArea1"; //顯示在圖表內
            //Chart1.Legends["Legends1"].Docking = Docking.Bottom; //自訂顯示位置
            Chart1.Legends["Legends1"].BackColor = Color.FromArgb(235, 235, 235); //背景色
            //斜線背景
            Chart1.Legends["Legends1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            Chart1.Legends["Legends1"].BorderWidth = 1;
            Chart1.Legends["Legends1"].BorderColor = Color.FromArgb(200, 200, 200);

            //設定 Series-----------------------------------------------------------------------
            Chart1.Series["Series1"].ChartType = SeriesChartType.Column; //直條圖
            //Chart1.Series["Series1"].ChartType = SeriesChartType.Bar; //橫條圖
            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Series1"].Legend = "Legends1";
            Chart1.Series["Series1"].LegendText = titleArr[0];
            Chart1.Series["Series1"].LabelFormat = "#,###"; //金錢格式
            Chart1.Series["Series1"].MarkerSize = 8; //Label 範圍大小
            Chart1.Series["Series1"].LabelForeColor = Color.FromArgb(0, 90, 255); //字體顏色
            //字體設定
            //Chart1.Series["Series1"].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            //Label 背景色
            Chart1.Series["Series1"].LabelBackColor = Color.FromArgb(150, 255, 255, 255);
            Chart1.Series["Series1"].Color = Color.FromArgb(240, 65, 140, 240); //背景色
            Chart1.Series["Series1"].IsValueShownAsLabel = true; // Show data points labels

            Chart1.Series["Series2"].Points.DataBindXY(xValues, yValues2);
            Chart1.Series["Series2"].Legend = "Legends1";
            Chart1.Series["Series2"].LegendText = titleArr[1];
            Chart1.Series["Series2"].LabelFormat = "#,###"; //金錢格式
            Chart1.Series["Series2"].MarkerSize = 8; //Label 範圍大小
            Chart1.Series["Series2"].LabelForeColor = Color.FromArgb(255, 103, 0);
            Chart1.Series["Series2"].Font = new System.Drawing.Font("Trebuchet MS", 10, FontStyle.Bold);
            Chart1.Series["Series2"].LabelBackColor = Color.FromArgb(150, 255, 255, 255);
            Chart1.Series["Series2"].Color = Color.FromArgb(240, 252, 180, 65); //背景色
            Chart1.Series["Series2"].IsValueShownAsLabel = true; //顯示數據

            this.Controls.Add(this.Chart1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
