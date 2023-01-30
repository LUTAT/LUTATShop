using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.DataLayer
{
    internal class DVTData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaDV ",
                from = "FROM tb_DVT ",
                orderBy = "ORDER BY MaDV DESC";
            SqlCommand cmd = new SqlCommand(select + from + orderBy);
            return cls.GetID(cmd);
        }
        public DataSet LayDSMotDong(int madvt)
        {
            SqlCommand cmd = new SqlCommand("select * from tb_DVT where MaDV=@madv");

            cmd.Parameters.Add("madv", SqlDbType.Int).Value = madvt;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSDVT()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_DVT");
            return cls.LayDuLieu(sqlcmd);
        }

        public int Them(DonViTinh dvt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_DVT (MaDV,TenDV) values(@madv,@tendv)";
            cmd.Parameters.Add("madv", SqlDbType.Int).Value = dvt.MaDVT;
            cmd.Parameters.Add("tendv", SqlDbType.NVarChar).Value = dvt.TenDVT;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTraTonTai(string tendvt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_DVT where TenDV=@tendv";

            cmd.Parameters.Add("tendv", SqlDbType.NVarChar).Value = tendvt;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }

    }
}
