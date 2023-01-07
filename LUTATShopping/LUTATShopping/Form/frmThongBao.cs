using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUTATShopping
{
    public partial class frmThongBao : Form
    {
        public frmThongBao()
        {
            InitializeComponent();
        }

        public Color BackColorAlert
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        public Color ColorAlert
        {
            get { return lbLin.BackColor; }
            set { lbLin.BackColor = txtTitle.ForeColor = txtText.ForeColor = value; }
        }
        public Image IconAlert
        {
            get { return picIcon.Image; }
            set { picIcon.Image = value; }
        }
        public String TitleAlert
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }
        public String TextAlert
        {
            get { return txtText.Text; }
            set { txtText.Text = value; }
        }
        private void PositionAlert()
        {
            int xPos = 0;
            int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeLin_Tick(object sender, EventArgs e)
        {
            lbLin.Width = lbLin.Width + 5;
            if (lbLin.Width == 500)
            {
                this.Close();
            }
        }

        private void frmThongBao_Load(object sender, EventArgs e)
        {
            PositionAlert();
            for (int i = 0; i < 500; i++)
                TimeLin.Start();
        }
    }
}
