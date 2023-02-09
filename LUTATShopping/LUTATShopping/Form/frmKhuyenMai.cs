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
    public partial class frmKhuyenMai : Form
    {
        KhuyenMaiController kmCtrl = new KhuyenMaiController();
        TrangThaiConller ttCtrl = new TrangThaiConller();
        public frmKhuyenMai()
        {
            InitializeComponent();
            ttCtrl.HienThiCbo3(cbTrangThai);
            HienThiDSKM();
            btnSua.Visible = false;
            btnLamMoi.Visible = false;
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

        private void pnKhuyenMai_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LamMoi()
        {
            txtTenKhuyenMai.Enabled = true;
            txtMaKhuyenMai.Clear();
            txtTenKhuyenMai.Clear();
            txtNoiDung.Clear();
            txtGiaGiam.Clear();
            btnSua.Visible = false;
            btnThem.Visible = true;
            btnLamMoi.Visible = false;
        }

        private void HienThiDSKM()
        {
            kmCtrl.HienThiDGV(dgvKM);
            dgvKM.Columns[0].HeaderText = "Mã";
            dgvKM.Columns[0].Width = 50;
            dgvKM.Columns[1].HeaderText = "Tên Khuyến Mãi";
            dgvKM.Columns[1].Width = 150;
            dgvKM.Columns[2].HeaderText = "Nội Dung";
            dgvKM.Columns[2].Width = 200;
            dgvKM.Columns[3].HeaderText = "Giảm Giá";
            dgvKM.Columns[3].Width = 100;
            dgvKM.Columns[4].Width = 0;
            dgvKM.Columns[5].HeaderText = "Trạng Thái";
        }    

        private void HienThiThongTin()
        {
            if (dgvKM.CurrentRow != null)
            {
                txtMaKhuyenMai.Text = dgvKM.CurrentRow.Cells["MaKM"].Value.ToString();
                txtTenKhuyenMai.Text = dgvKM.CurrentRow.Cells["TenKM"].Value.ToString();
                txtNoiDung.Text = dgvKM.CurrentRow.Cells["NoiDung"].Value.ToString();
                txtGiaGiam.Text = dgvKM.CurrentRow.Cells["GiamGia"].Value.ToString();
                cbTrangThai.SelectedValue = dgvKM.CurrentRow.Cells["TrangThai"].Value.ToString();

            }
            if (Convert.ToInt32(cbTrangThai.SelectedValue) == 6)
            {
                cbTrangThai.BorderColor = Color.FromArgb(161, 0, 51);
                cbTrangThai.ForeColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                cbTrangThai.BorderColor = Color.Black;
                cbTrangThai.ForeColor = Color.Black;
            }
            btnSua.Visible = true;
            btnThem.Visible = false;
            btnLamMoi.Visible = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhuyenMai km = new KhuyenMai();
            km.MaKM = kmCtrl.GetID() + 1;
            km.TenKM = txtTenKhuyenMai.Text;
            km.NoiDung = txtNoiDung.Text;
            km.GiaKM = Convert.ToInt32(txtGiaGiam.Text);
            km.TrangThai = Convert.ToInt32(cbTrangThai.SelectedValue);
            if (txtTenKhuyenMai.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenKhuyenMai.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                switch (kmCtrl.Them(km))
                {
                    case -1:
                        ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Loại Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                        break;
                    case 1:
                        HienThiDSKM();
                        ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Thêm Khuyến Mãi Thành Công", Properties.Resources.Success);
                        LamMoi();
                        break;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiThongTin();
            txtTenKhuyenMai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhuyenMai km = new KhuyenMai();
            km.MaKM = Convert.ToInt32(txtMaKhuyenMai.Text);
            km.NoiDung = txtNoiDung.Text;
            km.GiaKM = Convert.ToInt32(txtGiaGiam.Text);
            km.TrangThai = Convert.ToInt32(cbTrangThai.SelectedValue);
            if (txtTenKhuyenMai.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
                txtTenKhuyenMai.BorderColor = Color.FromArgb(161, 0, 51);
            }
            else
            {
                kmCtrl.Sua(km);
                HienThiDSKM();
                ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Thêm Khuyến Mãi Thành Công", Properties.Resources.Success);
                LamMoi();
            }
        }
    }
}
