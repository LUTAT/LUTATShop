using LUTATShopping.DataLayer;
using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LUTATShopping.Controller
{
    internal class SanPhamController
    {
        SanPhamData spdata = new SanPhamData();

        public DataTable HienThiDSSP()
        {
            try
            {
                return spdata.LayDSSP().Tables[0];
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }

        public bool KiemTraTenTonTai(string tensp)
        {
            return spdata.KiemTraTenTonTai(tensp);
        }

        public bool KiemTraMaTonTai(string masp)
        {
            return spdata.KiemTraMaTonTai(masp);
        }

        public int Them(SanPham sp)
        {
            if (KiemTraMaTonTai(sp.MaSP))
                return 0;
            if (KiemTraTenTonTai(sp.TenSP))
                return -1;
            return spdata.Them(sp);
        }
    }
}
