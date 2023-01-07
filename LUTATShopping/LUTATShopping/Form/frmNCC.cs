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
    public partial class frmNCC : Form
    {
        NCCController nccCtrl = new NCCController();
        public frmNCC()
        {
            InitializeComponent();
            HienThiDSNCC();
        }

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
    }
}
