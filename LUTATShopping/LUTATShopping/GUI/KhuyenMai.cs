using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.GUI
{
    internal class KhuyenMai
    {

        private int maKM;
        private string tenKM;
        private string noiDung;
        private int giaKM;
        private int trangThai;

        public int MaKM { get => maKM; set => maKM = value; }
        public string TenKM { get => tenKM; set => tenKM = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public int GiaKM { get => giaKM; set => giaKM = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
