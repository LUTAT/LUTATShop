using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.DataLayer
{
    internal class TrangThaiData
    {
        DataProvider cls = new DataProvider();

        public DataSet LayDSTrangThai()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_TrangThai where MaTT = 3 or MaTT = 4");
            return cls.LayDuLieu(sqlcmd);
        }
    }
}
