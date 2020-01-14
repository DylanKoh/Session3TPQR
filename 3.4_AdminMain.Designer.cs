namespace Session3
{
    partial class AdminMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.arrivalSummaryBtn = new System.Windows.Forms.Button();
            this.hotelSummaryBtn = new System.Windows.Forms.Button();
            this.guestsSummaryBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 85);
            this.panel1.TabIndex = 0;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 18);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(99, 45);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(732, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(353, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Administrator Main Menu";
            // 
            // arrivalSummaryBtn
            // 
            this.arrivalSummaryBtn.Location = new System.Drawing.Point(376, 146);
            this.arrivalSummaryBtn.Name = "arrivalSummaryBtn";
            this.arrivalSummaryBtn.Size = new System.Drawing.Size(245, 94);
            this.arrivalSummaryBtn.TabIndex = 2;
            this.arrivalSummaryBtn.Text = "Arrival Summary";
            this.arrivalSummaryBtn.UseVisualStyleBackColor = true;
            this.arrivalSummaryBtn.Click += new System.EventHandler(this.arrivalSummaryBtn_Click);
            // 
            // hotelSummaryBtn
            // 
            this.hotelSummaryBtn.Location = new System.Drawing.Point(376, 264);
            this.hotelSummaryBtn.Name = "hotelSummaryBtn";
            this.hotelSummaryBtn.Size = new System.Drawing.Size(245, 97);
            this.hotelSummaryBtn.TabIndex = 3;
            this.hotelSummaryBtn.Text = "Hotel Summary";
            this.hotelSummaryBtn.UseVisualStyleBackColor = true;
            this.hotelSummaryBtn.Click += new System.EventHandler(this.hotelSummaryBtn_Click);
            // 
            // guestsSummaryBtn
            // 
            this.guestsSummaryBtn.Location = new System.Drawing.Point(376, 385);
            this.guestsSummaryBtn.Name = "guestsSummaryBtn";
            this.guestsSummaryBtn.Size = new System.Drawing.Size(245, 86);
            this.guestsSummaryBtn.TabIndex = 4;
            this.guestsSummaryBtn.Text = "Guests Summary";
            this.guestsSummaryBtn.UseVisualStyleBackColor = true;
            this.guestsSummaryBtn.Click += new System.EventHandler(this.guestsSummaryBtn_Click);
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 483);
            this.Controls.Add(this.guestsSummaryBtn);
            this.Controls.Add(this.hotelSummaryBtn);
            this.Controls.Add(this.arrivalSummaryBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdminMain";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.AdminMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button arrivalSummaryBtn;
        private System.Windows.Forms.Button hotelSummaryBtn;
        private System.Windows.Forms.Button guestsSummaryBtn;
    }
}