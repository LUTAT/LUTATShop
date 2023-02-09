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
    internal class SanPhamData
    {

        DataProvider cls = new DataProvider();

        public DataSet LayDSSP()
        {
            SqlCommand sqlcmd = new SqlCommand("select tb_SanPham.*, TenNCC from tb_SanPham, tb_NhaCungCap where tb_SanPham.NCC = tb_NhaCungCap.MaNCC");
            return cls.LayDuLieu(sqlcmd);
        }

        public int Them(SanPham sp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO tb_SanPham (MaSP ,TenSP, SoLuong ,GiaBan, LoaiSP, NCC, DVT, KM, NgaySX, NgayHH, HinhAnh) VALUES (@masp,@tensp,@soluong, @giaban, @loaisp, @ncc, @dvt, @km, @ngaysx, @ngayhh, @hinhanh)";
            cmd.Parameters.Add("masp", SqlDbType.Int).Value = sp.MaSP;
            cmd.Parameters.Add("tensp", SqlDbType.NVarChar).Value = sp.TenSP;
            cmd.Parameters.Add("soluong", SqlDbType.Int).Value = sp.SoLuong;
            cmd.Parameters.Add("giaban", SqlDbType.Int).Value = sp.GiaBan;
            cmd.Parameters.Add("loaisp", SqlDbType.Int).Value = sp.MaLSP;
            cmd.Parameters.Add("ncc", SqlDbType.Int).Value = sp.MaNCC;
            cmd.Parameters.Add("dvt", SqlDbType.Int).Value = sp.MaDVT;
            cmd.Parameters.Add("km", SqlDbType.Int).Value = sp.MaKM;
            cmd.Parameters.Add("ngaysx", SqlDbType.Date).Value = sp.NgaySX;
            cmd.Parameters.Add("ngayhh", SqlDbType.Date).Value = sp.NgayHH;
            cmd.Parameters.Add("hinhanh", SqlDbType.Image).Value = sp.AnhSP;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTraTenTonTai(string tensp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_SanPham where TenSP=@tensp";

            cmd.Parameters.Add("tensp", SqlDbType.NVarChar).Value = tensp;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
        public bool KiemTraMaTonTai(string masp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tb_SanPham where MaSP=@masp";

            cmd.Parameters.Add("masp", SqlDbType.Int).Value = masp;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
    }
}
