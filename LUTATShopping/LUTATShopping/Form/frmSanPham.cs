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
    public partial class frmSanPham : Form
    {
        User user = new User();
        public frmSanPham(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            frmAddSanPham frm = new frmAddSanPham();
            frm.Show();
        }
    }
}
