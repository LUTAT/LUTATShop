using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LUTATShopping.DataLayer;
using LUTATShopping.GUI;

namespace LUTATShopping.Controller
{

    internal class LoaiSPController
    {

        LoaiSanPhamData loaispdata = new LoaiSanPhamData();

        public void HienThiCbo(ComboBox cb)
        {
            cb.DataSource = loaispdata.LayDSLoaiSP().Tables[0];
            cb.DisplayMember = "TenLoaiSP";
            cb.ValueMember = "MaLoaiSP";
        }

        public int GetID()
        {
            return loaispdata.GetID();
        }
        public void HienThiDGV(DataGridView dgv)
        {
            dgv.DataSource = loaispdata.LayDSLoaiSP().Tables[0];
        }

        #region Chức Năng Thêm Loại Sản Phẩm
        public bool KiemTraTonTai(string tenloaisp)
        {
            return loaispdata.KiemTraTonTai(tenloaisp);
        }
        public int Them(LoaiSanPham lsp)
        {
            if (KiemTraTonTai(lsp.TenLoaiSP))
                return -1;
            return loaispdata.Them(lsp);
        }
        #endregion

        public int Sua(LoaiSanPham loaisp)
        {
            if (KiemTraTonTai(loaisp.TenLoaiSP))
                return -1;
            return loaispdata.Sua(loaisp);
        }
    }
}
