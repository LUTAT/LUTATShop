using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping.GUI
{
    internal class LoaiSanPham
    {

        private int maLoaiSP;
        private string tenloaiSP;
        private string ghiChu;

        public int MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenLoaiSP { get => tenloaiSP; set => tenloaiSP = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
