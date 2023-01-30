using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUTATShopping.GUI;

namespace LUTATShopping.DataLayer
{
    internal class NCCData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaNCC ",
                from = "FROM tb_NhaCungCap ",
                orderBy = "ORDER BY MaNCC DESC";
            SqlCommand cmd = new SqlCommand(select + from + orderBy);
            return cls.GetID(cmd);
        }
        public DataSet LayDSMotDong(int mancc)
        {
            SqlCommand cmd = new SqlCommand("select * from tb_NhaCungCap where MaNCC=@mancc");

            cmd.Parameters.Add("mancc", SqlDbType.Int).Value = mancc;

            return cls.LayDuLieu(cmd);
        }
        public DataSet LayDSCBNCC()
        {
            SqlCommand cmd = new SqlCommand("select * from tb_NhaCungCap where TrangThai = '3'");
            return cls.LayDuLieu(cmd);
        }
        public DataSet LayDSNCC()
        {
            SqlCommand sqlcmd = new SqlCommand("select tb_NhaCungCap.*, TenTT from tb_NhaCungCap, tb_TrangThai where tb_NhaCungCap.TrangThai = tb_TrangThai.MaTT");
            return cls.LayDuLieu(sqlcmd);
        }

        public int Them(NhaCungCap ncc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_NhaCungCap (MaNCC,TenNCC, DiaChi, SDT, NgayHopTac, GhiChu, TrangThai) values(@mancc,@tenncc,@diachi, @sdt, @ngayhoptac, @ghichu, @trangthai)";
            cmd.Parameters.Add("mancc", SqlDbType.Int).Value = ncc.MaNCC;
            cmd.Parameters.Add("tenncc", SqlDbType.NVarChar).Value = ncc.TenNCC;
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = ncc.DiaChi;
            cmd.Parameters.Add("sdt", SqlDbType.NVarChar).Value = ncc.SDT;
            cmd.Parameters.Add("ngayhoptac", SqlDbType.Date).Value = ncc.NgayHopTac;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = ncc.GhiChu;
            cmd.Parameters.Add("trangthai", SqlDbType.Int).Value = ncc.TrangThai;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTraTonTai(string tenncc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_NhaCungCap where TenNCC=@tenncc";

            cmd.Parameters.Add("tenncc", SqlDbType.NVarChar).Value = tenncc;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
        public int Sua(NhaCungCap ncc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE tb_NhaCungCap SET DiaChi = @diachi, SDT = @sdt, NgayHopTac = @ngayhoptac,GhiChu = @ghichu, TrangThai = @trangthai where MaNCC = @mancc";
            cmd.Parameters.Add("mancc", SqlDbType.Int).Value = ncc.MaNCC;
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = ncc.DiaChi;
            cmd.Parameters.Add("sdt", SqlDbType.NVarChar).Value = ncc.SDT;
            cmd.Parameters.Add("ngayhoptac", SqlDbType.Date).Value = ncc.NgayHopTac;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = ncc.GhiChu;
            cmd.Parameters.Add("trangthai", SqlDbType.Int).Value = ncc.TrangThai;
            return cls.CapNhatDL(cmd);

        }

    }
}
