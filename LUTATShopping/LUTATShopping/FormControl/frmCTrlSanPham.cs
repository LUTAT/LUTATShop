using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LUTATShopping
{
    public partial class frmCTrlSanPham : UserControl
    {
        public frmCTrlSanPham()
        {
            InitializeComponent();
        }

        private Image hinhAnh;
        private string maSP;
        private string tenSP;
        private string soLuong;
        private string tenDV;
        private string tenNCC;
        private string ngayHH;
        private string trangThai;

        public Image HinhAnh 
        { 
            get { return hinhAnh; }
            set { hinhAnh = value; picSP.Image = value; }
        }
        public string MaSP 
        {
            get { return maSP; }
            set { maSP = value; lbMaSP.Text = value; }
        }
        public string TenSP 
        {
            get { return tenSP; }
            set { tenSP = value; lbTenSP.Text = value; }
        }
        public string SoLuong 
        {
            get { return soLuong; }
            set { soLuong = value; lbTenSP.Text = value; }
        }
        public string TenDV 
        {
            get { return tenDV; }
            set { tenDV = value; lbTenDV.Text = value; }
        }
        public string TenNCC 
        {
            get { return tenNCC; }
            set { tenNCC = value; lbTenNCC.Text = value; }
        }
        public string NgayHH 
        {
            get { return ngayHH; }
            set { ngayHH = value; lbNgayHH.Text = value; }
        }
        public string TrangThai 
        {
            get { return trangThai; }
            set { trangThai = value; lbTrangThai.Text = value; }
        }
    }
}
