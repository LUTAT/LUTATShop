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
    public partial class frmDangNhap : Form
    {

        #region Khai Báo
        Login log = new Login();
        User user = new User();
        #endregion  

        public frmDangNhap()
        {
            InitializeComponent();
            txtUserName.Select();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            XuLyDangNhap();

        }

        private void XuLyDangNhap()
        {
            if (txtUserName.Text == "" || txtPassWord.Text == "")
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Vui lòng nhập đầy đủ thông tin", Properties.Resources.Error);
            }
            else if (log.DangNhap(txtUserName.Text, txtPassWord.Text, user))
            {
                ThongBao(Color.LightGray, Color.SeaGreen, "Thành Công", "Bạn Đã Đăng Nhập Thành Công", Properties.Resources.Success);
                frmTrangChu frm = new frmTrangChu(user);
                this.Hide();
                frm.Show();
            }
            else
            {
                ThongBao(Color.LightPink, Color.DarkRed, "Thất Bại", "Sai UserName Hoặc Mật Khẩu", Properties.Resources.Error);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }
    }
}
