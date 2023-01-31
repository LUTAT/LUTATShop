using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LUTATShopping.Controller;

namespace LUTATShopping
{
    public partial class frmAddSanPham : Form
    {
        LoaiSPController loaispCtrl = new LoaiSPController();
        NCCController nccCtrl = new NCCController();
        DVTController dvtCtrl = new DVTController();
        KhuyenMaiController kmCtrl = new KhuyenMaiController();
        public frmAddSanPham()
        {
            InitializeComponent();
            loaispCtrl.HienThiCbo(cbLoaiSP);
            nccCtrl.HienThiCbo(cbNCC);
            dvtCtrl.HienThiCbo(cbDVT);
            kmCtrl.HienThiCbo(cbKM);
            #region Hiện Button
            if (txtMaSP.Text == "")
            {
                btnThem.Visible = true;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }   
            else
            {
                btnThem.Visible = false;
                btnSua.Visible = true;
                btnXoa.Visible = true;
            }
            #endregion

        }

        #region Di Chuyển Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void pnAddSP_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAddLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm  = new frmLoaiSanPham();
            this.Hide();
            frm.Show();
        }

        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            this.Hide();
            frm.Show();
        }

        private void btnAddDVT_Click(object sender, EventArgs e)
        {
            frmDVT frm = new frmDVT();
            this.Hide();
            frm.Show();
        }

        private void btnAddKM_Click(object sender, EventArgs e)
        {
            frmKhuyenMai frm = new frmKhuyenMai();
            this.Hide();
            frm.Show();
        }

        private void picSanPham_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                picSanPham.Image = Image.FromFile(open.FileName);
            }
        }
        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
