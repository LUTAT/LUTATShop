using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LUTATShopping.DataLayer;
namespace LUTATShopping.Controller
{
    internal class DVTController
    {
        DVTData dvtData = new DVTData();        
        public void HienThiCbo(ComboBox cb)
        {
            cb.DataSource = dvtData.LayDSDVT().Tables[0];
            cb.DisplayMember = "TenDV";
            cb.ValueMember = "MaDV";
        }

        public int GetID()
        {
            return dvtData.GetID();
        }
        public void HienThiDGV(DataGridView dgv)
        {
            dgv.DataSource = dvtData.LayDSDVT().Tables[0];
        }

        #region Chức Năng Thêm Đơn Vị Tính
        public bool KiemTraTonTai(string tenloaisp)
        {
            return dvtData.KiemTraTonTai(tenloaisp);
        }
        public int Them(DonViTinh dvt)
        {
            if (KiemTraTonTai(dvt.TenDVT))
                return -1;
            return dvtData.Them(dvt);
        }
        #endregion

    }
}
