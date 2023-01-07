namespace LUTATShopping
{
    partial class frmThongBao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBao));
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.txtTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.lbLin = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.TimeLin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Image = global::LUTATShopping.Properties.Resources.Error;
            this.picIcon.Location = new System.Drawing.Point(12, 12);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(48, 48);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTitle.Location = new System.Drawing.Point(66, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(74, 27);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "Thất Bại";
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.Transparent;
            this.txtText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtText.Location = new System.Drawing.Point(66, 38);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(196, 22);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "Vui lòng nhập đầy đủ Họ Tên";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(386, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbLin
            // 
            this.lbLin.FillColor = System.Drawing.Color.White;
            this.lbLin.Location = new System.Drawing.Point(0, 65);
            this.lbLin.Name = "lbLin";
            this.lbLin.Size = new System.Drawing.Size(0, 5);
            this.lbLin.TabIndex = 4;
            // 
            // TimeLin
            // 
            this.TimeLin.Interval = 10;
            this.TimeLin.Tick += new System.EventHandler(this.TimeLin_Tick);
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 70);
            this.Controls.Add(this.lbLin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongBao";
            this.Text = "frmThongBao";
            this.Load += new System.EventHandler(this.frmThongBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtText;
        private System.Windows.Forms.PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2GradientPanel lbLin;
        private System.Windows.Forms.Timer TimeLin;
    }
}