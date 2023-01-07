using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LUTATShopping.Controller;

namespace LUTATShopping
{
    public partial class frmAddSanPham : Form
    {
        LoaiSPController loaispCtrl = new LoaiSPController();
        public frmAddSanPham()
        {
            InitializeComponent();
            loaispCtrl.HienThiCbo(cbLoaiSP);
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
            frmLoaiSanPham frm = new frmLoaiSanPham();
            frm.Show();
        }

        private void picAddLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham();
            this.Close();
            frm.Show();
        }

        private void picAddNCC_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            this.Close();
            frm.Show();
        }
    }
}
