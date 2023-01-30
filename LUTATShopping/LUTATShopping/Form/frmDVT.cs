using LUTATShopping.Controller;
using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUTATShopping
{
    public partial class frmDVT : Form
    {
        DVTController dvtCtrl = new DVTController();
        public frmDVT()
        {
            InitializeComponent();
        }
        #region Di Chuyển Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region Thông Báo
        void ThongBao(Color backcolor, Color color, string title, string text, Image icon)
        {
            frmThongBao frm = new frmThongBao();
            frm.BackColor = backcolor;
            frm.ColorAlert = color;
            frm.TitleAlert = title;
            frm.TextAlert = text;
            frm.IconAlert = icon;
            frm.ShowDialog();
        }
        #endregion
        private void pnDVT_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void HienThiThongTin()
        {
            if (dgvDVT.CurrentRow != null)
            {
                txtMaDV.Text = dgvDVT.CurrentRow.Cells["MaDVT"].Value.ToString();
                txtTenDV.Text = dgvDVT.CurrentRow.Cells["TenDVT"].Value.ToString();
            }
        }

        private void HienThiDanhSachDVT()
        {
            dvtCtrl.HienThiDGV(dgvDVT);
            dgvDVT.Columns[0].HeaderText = "Mã";
            dgvDVT.Columns[0].Width = 50;
            dgvDVT.Columns[1].HeaderText = "Tên ĐVT";
        }

        private void LamMoi()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                frmAddSanPham frm = new frmAddSanPham();
                frm.Show();
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DonViTinh dvt = new DonViTinh();
            dvt.MaDVT = dvtCtrl.GetID() + 1;
            dvt.TenDVT = txtTenDV.Text;
            if (txtTenDV.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenDV.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                switch (dvtCtrl.Them(dvt))
                {
                    case -1:
                        ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Loại Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                        break;
                    case 1:
                        HienThiDanhSachDVT();
                        ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Thêm Loại Sản Phẩm Thành Công", Properties.Resources.Success);
                        LamMoi();
                        break;
                }
            }
        }
    }
}
