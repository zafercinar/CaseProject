namespace CaseProject.WFAUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblRastgeleMetinUzunluk = new System.Windows.Forms.Label();
            this.txtRastgeleMetinUzunluk = new System.Windows.Forms.TextBox();
            this.txtOlusturulanRandomDeger = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkGreen;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.ForeColor = System.Drawing.Color.Honeydew;
            this.btnStart.Location = new System.Drawing.Point(12, 114);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(199, 32);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.Color.Honeydew;
            this.btnStop.Location = new System.Drawing.Point(229, 114);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(199, 32);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblRastgeleMetinUzunluk
            // 
            this.lblRastgeleMetinUzunluk.AutoSize = true;
            this.lblRastgeleMetinUzunluk.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRastgeleMetinUzunluk.Location = new System.Drawing.Point(12, 81);
            this.lblRastgeleMetinUzunluk.Name = "lblRastgeleMetinUzunluk";
            this.lblRastgeleMetinUzunluk.Size = new System.Drawing.Size(278, 20);
            this.lblRastgeleMetinUzunluk.TabIndex = 4;
            this.lblRastgeleMetinUzunluk.Text = "Rastgele oluşturulacak metin uzunluğu:";
            // 
            // txtRastgeleMetinUzunluk
            // 
            this.txtRastgeleMetinUzunluk.Location = new System.Drawing.Point(296, 78);
            this.txtRastgeleMetinUzunluk.Name = "txtRastgeleMetinUzunluk";
            this.txtRastgeleMetinUzunluk.Size = new System.Drawing.Size(132, 27);
            this.txtRastgeleMetinUzunluk.TabIndex = 5;
            this.txtRastgeleMetinUzunluk.Text = "5";
            // 
            // txtOlusturulanRandomDeger
            // 
            this.txtOlusturulanRandomDeger.Enabled = false;
            this.txtOlusturulanRandomDeger.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtOlusturulanRandomDeger.Location = new System.Drawing.Point(12, 12);
            this.txtOlusturulanRandomDeger.Multiline = true;
            this.txtOlusturulanRandomDeger.Name = "txtOlusturulanRandomDeger";
            this.txtOlusturulanRandomDeger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOlusturulanRandomDeger.Size = new System.Drawing.Size(416, 55);
            this.txtOlusturulanRandomDeger.TabIndex = 6;
            this.txtOlusturulanRandomDeger.Text = "Oluşturlacak Rastgele Metin Buraya Yazılacaktır.";
            this.txtOlusturulanRandomDeger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 157);
            this.Controls.Add(this.txtOlusturulanRandomDeger);
            this.Controls.Add(this.txtRastgeleMetinUzunluk);
            this.Controls.Add(this.lblRastgeleMetinUzunluk);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 204);
            this.MinimumSize = new System.Drawing.Size(453, 204);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Case Project - Hoşgeldiniz ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label lblRastgeleMetinUzunluk;
        private TextBox txtRastgeleMetinUzunluk;
        private TextBox txtOlusturulanRandomDeger;
    }
}