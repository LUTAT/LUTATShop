using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.GUI
{
    internal class NhaCungCap
    {

        private int maNCC;
        private string tenNCC;
        private string diaChi;
        private string sDT;
        private DateTime ngayHopTac;
        private string ghiChu;
        private int trangThai;

        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public DateTime NgayHopTac { get => ngayHopTac; set => ngayHopTac = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
