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
using Guna.UI2.AnimatorNS;
using LUTATShopping.Controller;
using LUTATShopping.GUI;

namespace LUTATShopping
{
    public partial class frmAddSanPham : Form
    {
        SanPhamController spCtrl = new SanPhamController();
        LoaiSPController loaispCtrl = new LoaiSPController();
        NCCController nccCtrl = new NCCController();
        DVTController dvtCtrl = new DVTController();
        KhuyenMaiController kmCtrl = new KhuyenMaiController();
        public delegate void DoEvent();
        public event DoEvent LoadSP;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(KiemTraNhap() == true)
            {
                
                SanPham sp = new SanPham();
                sp.MaSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                sp.GiaBan = Convert.ToInt32(txtGiaBan.Text);
                sp.MaLSP = Convert.ToInt32(cbLoaiSP.SelectedValue);
                sp.MaNCC = Convert.ToInt32(cbNCC.SelectedValue);
                sp.MaDVT = Convert.ToInt32(cbDVT.SelectedValue);
                sp.MaKM = Convert.ToInt32(cbKM.SelectedValue);
                sp.AnhSP = ConvertImageToBytes(picSanPham.Image);
                sp.NgaySX = Convert.ToDateTime(dtNgaySX.Value);
                sp.NgayHH = Convert.ToDateTime(dtNgayHH.Value);
                TimeSpan time = sp.NgayHH - sp.NgaySX;
                int DemNgay = time.Days;
                if( DemNgay < 0)
                {
                    ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng nhập đúng ngày Hết Hạn hoặc ngày sản xuất", Properties.Resources.Error);
                }    
                else
                {
                    switch (spCtrl.Them(sp))
                    {
                        case 0:
                            ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Mã Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                            break;
                        case -1:
                            ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Tên Sản Phẩm Đã Tồn Tại", Properties.Resources.Error);
                            break;
                        case 1:
                            ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Mã Sản Phẩm Đã Tồn Tại", Properties.Resources.Success);
                            //LoadSP();
                            LamMoi();
                            break;
                    }
                }    
            }    
        }

        private void LamMoi()
        {

        }

        private bool KiemTraNhap()
        {
            if(txtMaSP.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng Nhập Mã Sản Phẩm", Properties.Resources.Error);
                return false;
            }
            else if (txtTenSP.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng Nhập Tên Sản Phẩm", Properties.Resources.Error);
                return false;
            }
            else if (txtSoLuong.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng Nhập Số Lượng Sản Phẩm", Properties.Resources.Error);
                return false;
            }
            else if (txtGiaBan.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui Lòng Nhập Giá Sản Phẩm", Properties.Resources.Error);
                return false;
            }
            return true;
        }
    }
}
