using LUTATShopping.DataLayer;
using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUTATShopping.Controller
{
    internal class KhuyenMaiController
    {

        KhuyenMaiData KMData = new KhuyenMaiData();
        public void HienThiCbo(ComboBox cb)
        {
            cb.DataSource = KMData.LayDSKMTheoTT().Tables[0];
            cb.DisplayMember = "TenKM";
            cb.ValueMember = "MaKM";
        }

        public int GetID()
        {
            return KMData.GetID();
        }
        public void HienThiDGV(DataGridView dgv)
        {
            dgv.DataSource = KMData.LayDSKM().Tables[0];
        }

        #region Chức Năng Thêm Khuyến Mãi
        public bool KiemTraTonTai(string tenloaisp)
        {
            return KMData.KiemTraTonTai(tenloaisp);
        }
        public int Them(KhuyenMai km)
        {
            if (KiemTraTonTai(km.TenKM))
                return -1;
            return KMData.Them(km);
        }
        #endregion

        public int Sua(KhuyenMai km)
        {
            if (KiemTraTonTai(km.TenKM))
                return -1;
            return KMData.Sua(km);
        }
    }

}
