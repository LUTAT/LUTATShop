using LUTATShopping.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.DataLayer
{
    internal class LoaiSanPhamData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaLoaiSP ",
                from = "FROM tb_LoaiSanPham ",
                orderBy = "ORDER BY MaLoaiSP DESC";
            SqlCommand cmd = new SqlCommand(select + from + orderBy);
            return cls.GetID(cmd);
        }
        public DataSet LayDSMotDong(int malsp)
        {
            SqlCommand cmd = new SqlCommand("select * from tb_LoaiSanPham where MaLoaiSP=@maloaisp");

            cmd.Parameters.Add("maloaisp", SqlDbType.Int).Value = malsp;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSLoaiSP()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_LoaiSanPham");
            return cls.LayDuLieu(sqlcmd);
        }

        public int Them(LoaiSanPham lsp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_LoaiSanPham (MaLoaiSP,TenLoaiSP, GhiChu) values(@maloaisp,@tenloaisp,@ghichu)";
            cmd.Parameters.Add("maloaisp", SqlDbType.Int).Value = lsp.MaLoaiSP;
            cmd.Parameters.Add("tenloaisp", SqlDbType.NVarChar).Value = lsp.TenLoaiSP;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = lsp.GhiChu;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTraTonTai(string tenloaisp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_LoaiSanPham where TenLoaiSP=@tenloaisp";

            cmd.Parameters.Add("tenloaisp", SqlDbType.NVarChar).Value = tenloaisp;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
        public int Sua(LoaiSanPham loaisp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update tb_LoaiSanPham set TenLoaiSP=@tenloaisp, GhiChu=@ghichu where MaLoaiSP=@maloaisp";
            cmd.Parameters.Add("tenloaisp", SqlDbType.NVarChar).Value = loaisp.TenLoaiSP;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = loaisp.GhiChu;
            cmd.Parameters.Add("maloaisp", SqlDbType.Int).Value = loaisp.MaLoaiSP;
            return cls.CapNhatDL(cmd);
        }
    }
}
