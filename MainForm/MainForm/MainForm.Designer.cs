namespace MainForm
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCallChar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallChar
            // 
            this.btnCallChar.Location = new System.Drawing.Point(52, 53);
            this.btnCallChar.Name = "btnCallChar";
            this.btnCallChar.Size = new System.Drawing.Size(75, 23);
            this.btnCallChar.TabIndex = 0;
            this.btnCallChar.Text = "呼叫圖表";
            this.btnCallChar.UseVisualStyleBackColor = true;
            this.btnCallChar.Click += new System.EventHandler(this.btnCallChar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCallChar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallChar;
    }
}

