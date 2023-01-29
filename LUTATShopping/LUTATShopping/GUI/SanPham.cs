using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.GUI
{
    internal class SanPham
    {

        private int maSP;
        private string tenSP;
        private int soLuong;
        private int giaBan;
        private int maLSP;
        private int maNCC;
        private int maDVT;
        private int maKM;
        private DateTime ngaySX;
        private DateTime ngayHH;
        private Image anhSP;

        public int MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int MaLSP { get => maLSP; set => maLSP = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public int MaDVT { get => maDVT; set => maDVT = value; }
        public int MaKM { get => maKM; set => maKM = value; }
        public DateTime NgaySX { get => ngaySX; set => ngaySX = value; }
        public DateTime NgayHH { get => ngayHH; set => ngayHH = value; }
        public Image AnhSP { get => anhSP; set => anhSP = value; }
    }
}
