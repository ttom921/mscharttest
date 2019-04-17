namespace MainForm
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PieMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarMenuItem,
            this.PieMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuchar";
            // 
            // BarMenuItem
            // 
            this.BarMenuItem.Name = "BarMenuItem";
            this.BarMenuItem.Size = new System.Drawing.Size(44, 24);
            this.BarMenuItem.Text = "Bar";
            this.BarMenuItem.Click += new System.EventHandler(this.BarMenuItem_Click);
            // 
            // PieMenuItem
            // 
            this.PieMenuItem.Name = "PieMenuItem";
            this.PieMenuItem.Size = new System.Drawing.Size(42, 24);
            this.PieMenuItem.Text = "Pie";
            this.PieMenuItem.Click += new System.EventHandler(this.PieMenuItem_Click);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChart";
            this.Text = "FormChart";
            this.SizeChanged += new System.EventHandler(this.FormChart_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PieMenuItem;
    }
}