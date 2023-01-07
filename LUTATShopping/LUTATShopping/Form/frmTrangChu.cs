using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUTATShopping
{
    public partial class frmTrangChu : Form
    {
        User user = new User();
        public frmTrangChu(User user)
        {
            InitializeComponent();
            this.user = user;
            lbName.Text = user.HoTen;
            lbSelectButton.Text = "Trang Chủ";
        }
        public frmTrangChu()
        {
            InitializeComponent();
        }

        #region sự kiện API
        private void AbrirFormEnPanel(Form form)
        {
            Form[] child = this.MdiChildren;
            foreach (Form childForm in child)
            {
                childForm.Close();
            }
            if (!pnShow.Controls.Contains(form))
            {
                if (pnShow.Controls.Count > 0)
                {
                    pnShow.Controls.Clear();
                }
                form.TopLevel = false;
                pnShow.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                form.Show();
                form.BringToFront();
            }
            else
            {
                form.BringToFront();
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                user.DangXuat();
                frmDangNhap frm = new frmDangNhap();
                this.Close();
                frm.Show();
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmSanPham(user));
            lbSelectButton.Text = "Sản Phẩm";
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Bán Hàng";
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Khách Hàng";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Nhân Viên";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Báo Cáo";
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Kho Hàng";
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            lbSelectButton.Text = "Trang Chủ";
        }
    }
}
