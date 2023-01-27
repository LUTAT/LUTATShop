﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LUTATShopping.Controller;
using LUTATShopping.GUI;

namespace LUTATShopping
{
    public partial class frmNCC : Form
    {
        NCCController nccCtrl = new NCCController();
        public frmNCC()
        {
            InitializeComponent();
            HienThiDSNCC();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void HienThiDSNCC()
        {
            nccCtrl.HienThiDGV(dgvNCC);
            dgvNCC.Columns[0].HeaderText = "Mã";
            dgvNCC.Columns[0].Width = 50;
            dgvNCC.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNCC.Columns[1].Width = 150;
            dgvNCC.Columns[2].HeaderText = "Địa Chỉ";
            dgvNCC.Columns[3].HeaderText = "Số Điện Thoại";
            dgvNCC.Columns[3].Width = 100;
            dgvNCC.Columns[4].HeaderText = "Ngày Hợp Tác";
            dgvNCC.Columns[4].Width = 100;
            dgvNCC.Columns[5].HeaderText = "Ghi Chú";
        }

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

        private void LamMoi()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnThem.Visible = true;
            btnLamMoi.Visible = false;
            HienThiDSNCC();
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

        private void pnNCC_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = nccCtrl.GetID() + 1;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.SDT = txtSDT.Text;
            ncc.NgayHopTac = Convert.ToDateTime(dtNgayHopTac.ToString());
            ncc.GhiChu = txtGhiChu.Text;
            if (txtTenNCC.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenNCC.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else if (txtSDT.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenNCC.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                switch (nccCtrl.Them(ncc))
                {
                    case -1:
                        ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Loại Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                        break;
                    case 1:
                        ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Thêm Loại Sản Phẩm Thành Công", Properties.Resources.Success);
                        LamMoi();
                        break;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
