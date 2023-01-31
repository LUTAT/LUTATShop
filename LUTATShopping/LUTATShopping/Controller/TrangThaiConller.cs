using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using LUTATShopping.DataLayer;

namespace LUTATShopping.Controller
{
    internal class TrangThaiConller
    {
        TrangThaiData TTData = new TrangThaiData();
        public void HienThiCbo2(ComboBox cb)
        {
            cb.DataSource = TTData.LayDSTrangThai2().Tables[0];
            cb.DisplayMember = "TenTT";
            cb.ValueMember = "MaTT";
        }
        public void HienThiCbo1(ComboBox cb)
        {
            cb.DataSource = TTData.LayDSTrangThai1().Tables[0];
            cb.DisplayMember = "TenTT";
            cb.ValueMember = "MaTT";
        }

        public void HienThiCbo3(ComboBox cb)
        {
            cb.DataSource = TTData.LayDSTrangThai3().Tables[0];
            cb.DisplayMember = "TenTT";
            cb.ValueMember = "MaTT";
        }
    }
}
