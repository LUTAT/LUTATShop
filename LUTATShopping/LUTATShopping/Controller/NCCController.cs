using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LUTATShopping.DataLayer;
namespace LUTATShopping.Controller
{
    internal class NCCController
    {
        NCCData nccdata = new NCCData();

        public void HienThiCbo(ComboBox cb)
        {
            cb.DataSource = nccdata.LayDSNCC().Tables[0];
            cb.DisplayMember = "TenNCC";
            cb.ValueMember = "MaNCC";
        }

        public int GetID()
        {
            return nccdata.GetID();
        }
        public void HienThiDGV(DataGridView dgv)
        {
            dgv.DataSource = nccdata.LayDSNCC().Tables[0];
        }
    }
}
