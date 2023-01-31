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

        public DataSet LayDSTrangThai2()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_TrangThai where MaTT = 3 or MaTT = 4");
            return cls.LayDuLieu(sqlcmd);
        }
        public DataSet LayDSTrangThai1()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_TrangThai where MaTT = 1 or MaTT = 2");
            return cls.LayDuLieu(sqlcmd);
        }
        public DataSet LayDSTrangThai3()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_TrangThai where MaTT = 5 or MaTT = 6");
            return cls.LayDuLieu(sqlcmd);
        }
    }
}
