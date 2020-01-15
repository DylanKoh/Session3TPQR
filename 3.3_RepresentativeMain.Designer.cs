﻿namespace Session3
{
    partial class RepresentativeMain
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.bookingBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(1028, 100);
            this.panel1.TabIndex = 0;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 31);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(112, 44);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(753, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Country Representative Main Menu";
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(354, 168);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(273, 85);
            this.confirmBtn.TabIndex = 2;
            this.confirmBtn.Text = "Confirm Arrival Details";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // bookingBtn
            // 
            this.bookingBtn.Location = new System.Drawing.Point(354, 280);
            this.bookingBtn.Name = "bookingBtn";
            this.bookingBtn.Size = new System.Drawing.Size(273, 76);
            this.bookingBtn.TabIndex = 3;
            this.bookingBtn.Text = "Hotel Booking";
            this.bookingBtn.UseVisualStyleBackColor = true;
            this.bookingBtn.Click += new System.EventHandler(this.bookingBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(354, 388);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(273, 77);
            this.updateBtn.TabIndex = 4;
            this.updateBtn.Text = "Update Info / Booking";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // RepresentativeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 536);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.bookingBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RepresentativeMain";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.RespresentativeMain_Load);
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
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button bookingBtn;
        private System.Windows.Forms.Button updateBtn;
    }
}