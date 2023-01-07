using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping
{
    public class Login
    {


        DataProvider cls = new DataProvider();

        public bool DangNhap(string username, string password, User user)
        {
            SqlCommand cmd = new SqlCommand("select * from tb_NhanVien where UserName=@username and PassWord=@password");

            cmd.Parameters.Add("username", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = password;

            DataSet ds = cls.LayDuLieu(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.HoTen = ds.Tables[0].Rows[0]["HoTen"].ToString();
                user.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                user.SDT = ds.Tables[0].Rows[0]["SDT"].ToString();
                user.CMND = ds.Tables[0].Rows[0]["CMND"].ToString();
                return true;
            }

            return false;
        }

        public int DoiMatKhau(string matKhau, string taiKhoan)
        {
            SqlCommand cmd = new SqlCommand();
            string update = "UPDATE tb_NhanVien SET PassWord = @password ",
                where = "WHERE UserName = @username";

            cmd.CommandText = update + where;

            cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = matKhau;
            cmd.Parameters.Add("username", SqlDbType.NVarChar).Value = taiKhoan;

            return cls.CapNhatDL(cmd);
        }

        public bool XacThuc(string sdt, string tenDangNhap)
        {
            SqlCommand cmd = new SqlCommand();

            string select = "SELECT * ",
                from = "FROM tb_NhanVien",
                where = "WHERE UserName = @username AND SDT = @sdt";

            cmd.CommandText = select + from + where;

            cmd.Parameters.Add("sdt", SqlDbType.NChar).Value = sdt;
            cmd.Parameters.Add("username", SqlDbType.NVarChar).Value = tenDangNhap;

            return cls.KiemTra(cmd);
        }

    }
}
