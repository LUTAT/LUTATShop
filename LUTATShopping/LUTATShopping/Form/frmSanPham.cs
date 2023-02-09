using LUTATShopping.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUTATShopping
{
    public partial class frmSanPham : Form
    {
        User user = new User();
        SanPhamController spCtrl = new SanPhamController();
        private static frmSanPham _instance;
        public static frmSanPham Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmSanPham();
                }
                return _instance;
            }
        }
        public frmSanPham()
        {
            InitializeComponent();
        }
        public frmSanPham(User user)
        {
            InitializeComponent();
            this.user = user;
            ShowConTrol();
            if (pnShow.Controls.Count == 0)
            {
                MessageBox.Show("Không Có Sản Phẩm!");
            }
        }

        public void ShowConTrol()
        {
            pnShow.Controls.Clear();
            DataTable dt = spCtrl.HienThiDSSP();
            if (dt != null)
            {
                if (dt.Rows.Count > 0) // also has some records in it
                {
                    frmCTrlSanPham[] listItems = new frmCTrlSanPham[dt.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            listItems[i] = new frmCTrlSanPham();
                            MemoryStream ms = new MemoryStream((byte[])row["HinhAnh"]);
                            listItems[i].HinhAnh = new Bitmap(ms);
                            listItems[i].MaSP = row["MaSP"].ToString();
                            listItems[i].TenSP = row["TenSP"].ToString();
                            listItems[i].SoLuong = row["SoLuong"].ToString();
                            listItems[i].TenDV = row["TenDV"].ToString();
                            listItems[i].TenNCC = row["TenNCC"].ToString();
                            listItems[i].NgayHH = row["NgayHH"].ToString();
                            //listItems[i].TrangThai = row["TrangThai"].ToString();
                            pnShow.Controls.Add(listItems[i]);
                            //listItems[i].Click += new System.EventHandler(this.userCtrl1_Click);
                        }
                    }
                }

            }
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            frmAddSanPham frm = new frmAddSanPham();
            frm.LoadSP += new frmAddSanPham.DoEvent(ShowConTrol);
            frm.Show();
        }
    }
}
