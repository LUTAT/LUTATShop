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
    internal class KhuyenMaiData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaKM ",
                from = "FROM tb_KhuyenMai ",
                orderBy = "ORDER BY MaKM DESC";
            SqlCommand cmd = new SqlCommand(select + from + orderBy);
            return cls.GetID(cmd);
        }
        public DataSet LayDSMotDong(int malsp)
        {
            SqlCommand cmd = new SqlCommand("select * from tb_KhuyenMai where MaKM=@makm");

            cmd.Parameters.Add("makm", SqlDbType.Int).Value = malsp;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSKM()
        {
            SqlCommand sqlcmd = new SqlCommand("select tb_KhuyenMai.*, TenTT from tb_KhuyenMai, tb_TrangThai where tb_KhuyenMai.TrangThai = tb_TrangThai.MaTT");
            return cls.LayDuLieu(sqlcmd);
        }
        public DataSet LayDSKMTheoTT()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from tb_KhuyenMai where TrangThai = '5'");
            return cls.LayDuLieu(sqlcmd);
        }

        public int Them(KhuyenMai km)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_KhuyenMai (MaKM, TenKM, NoiDung, GiamGia, TrangThai) values(@makm, @tenkm, @noidung, @giamgia, @trangthai)";
            cmd.Parameters.Add("makm", SqlDbType.Int).Value = km.MaKM;
            cmd.Parameters.Add("tenkm", SqlDbType.NVarChar).Value = km.TenKM;
            cmd.Parameters.Add("noidung", SqlDbType.NVarChar).Value = km.NoiDung;
            cmd.Parameters.Add("giamgia", SqlDbType.Int).Value = km.GiaKM;
            cmd.Parameters.Add("trangthai", SqlDbType.Int).Value = km.TrangThai;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTraTonTai(string tenkm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_KhuyenMai where TenKM = @tenkm";

            cmd.Parameters.Add("tenkm", SqlDbType.NVarChar).Value = tenkm;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
        public int Sua(KhuyenMai km)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update tb_KhuyenMai set NoiDung=@noidung, GiamGia=@giamgia, TrangThai = @trangthai where MaKM = @makm";
            cmd.Parameters.Add("makm", SqlDbType.Int).Value = km.MaKM;
            cmd.Parameters.Add("noidung", SqlDbType.NVarChar).Value = km.NoiDung;
            cmd.Parameters.Add("giamgia", SqlDbType.Int).Value = km.GiaKM;
            cmd.Parameters.Add("trangthai", SqlDbType.Int).Value = km.TrangThai;
            return cls.CapNhatDL(cmd);
        }
    }

}
