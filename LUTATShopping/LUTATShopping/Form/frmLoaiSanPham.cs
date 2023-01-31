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
using LUTATShopping.Controller;
using LUTATShopping.GUI;

namespace LUTATShopping
{
    public partial class frmLoaiSanPham : Form
    {
        LoaiSPController loaispctrl = new LoaiSPController();

        public frmLoaiSanPham()
        {
            InitializeComponent();
            HienThiDanhSachLoaiSP();
        }

        #region Di Chuyển Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region CLose
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
        #endregion

        #region Hiển Thị danh sách loại sản phẩm
        private void HienThiDanhSachLoaiSP()
        {
            loaispctrl.HienThiDGV(dgvLoaiSP);
            dgvLoaiSP.Columns[0].HeaderText = "Mã";
            dgvLoaiSP.Columns[0].Width = 50;
            dgvLoaiSP.Columns[1].HeaderText = "Tên Loại";
            dgvLoaiSP.Columns[1].Width = 300;
            dgvLoaiSP.Columns[2].HeaderText = "Ghi Chú";
        }
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

        #region Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiSanPham lsp = new LoaiSanPham();
            lsp.MaLoaiSP = loaispctrl.GetID() + 1;
            lsp.TenLoaiSP = txtTenLoaiSP.Text;
            lsp.GhiChu = txtGhiChu.Text;
            if (txtTenLoaiSP.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenLoaiSP.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                switch (loaispctrl.Them(lsp))
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
        #endregion

        #region Làm Mới
        public void LamMoi()
        {
            txtMaLoaiSP.Clear();
            txtTenLoaiSP.Clear();
            txtGhiChu.Clear();
            txtTenLoaiSP.BorderColor = Color.FromArgb(24, 24, 24);
            btnThem.Visible = true;
            btnSua.Visible = false;
            btnLamMoi.Visible = false;
            HienThiDanhSachLoaiSP();
        }
        #endregion

        private void HienThiThongTin()
        {
            if (dgvLoaiSP.CurrentRow != null)
            {
                txtMaLoaiSP.Text = dgvLoaiSP.CurrentRow.Cells["MaLoaiSP"].Value.ToString();
                txtTenLoaiSP.Text = dgvLoaiSP.CurrentRow.Cells["TenLoaiSP"].Value.ToString();
                txtGhiChu.Text = dgvLoaiSP.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

              DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtTenLoaiSP.Text == "")
                {
                    ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng Nhập Tên Loại Sản Phẩm", Properties.Resources.Error);
                }
                else
                {

                    LoaiSanPham lsp = new LoaiSanPham();
                    lsp.TenLoaiSP = txtTenLoaiSP.Text;
                    lsp.GhiChu = txtGhiChu.Text;
                    lsp.MaLoaiSP = Convert.ToInt32(txtMaLoaiSP.Text);
                    switch (loaispctrl.Sua(lsp))
                    {
                        case -1:
                            ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Loại Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                            break;
                        case 1:
                            LamMoi();
                            ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Sửa Loại Sản Phẩm Thành Công", Properties.Resources.Success);
                            break;
                    }
                }
            }
        }

        private void pnLoaiSP_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiThongTin();
            btnThem.Visible = false;
            btnSua.Visible = true;
            btnLamMoi.Visible = true;
        }
    }
}
