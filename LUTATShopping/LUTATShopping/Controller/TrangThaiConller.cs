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
        public void HienThiCbo(ComboBox cb)
        {
            cb.DataSource = TTData.LayDSTrangThai().Tables[0];
            cb.DisplayMember = "TenTT";
            cb.ValueMember = "MaTT";
        }

    }
}
