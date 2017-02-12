namespace WindowsFormsApplication1
{
    partial class OpenResepyHttp
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
            this.label1 = new System.Windows.Forms.Label();
            this.ratio = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Персон";
            // 
            // ratio
            // 
            this.ratio.AutoSize = true;
            this.ratio.Location = new System.Drawing.Point(466, 499);
            this.ratio.Name = "ratio";
            this.ratio.Size = new System.Drawing.Size(35, 13);
            this.ratio.TabIndex = 7;
            this.ratio.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(486, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 28);
            this.button3.TabIndex = 9;
            this.button3.Tag = "Convert.ToString(reader[\"id\"])";
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // OpenResepyHttp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(656, 759);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ratio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "OpenResepyHttp";
            this.Text = "OpenResepyHttp";
            this.Load += new System.EventHandler(this.OpenResepyHttp_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ratio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}