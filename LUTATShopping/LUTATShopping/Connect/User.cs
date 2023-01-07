using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUTATShopping
{
    public class User
    {
        private string userName;
        private string hoTen;
        private string sDT;
        private int phanQuyen;
        private string cMND;
        public string UserName { get => userName; set => userName = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
        public string CMND { get => cMND; set => cMND = value; }

        public User()
        {
        }

        public User(User user)
        {
            this.UserName = user.UserName;
            this.HoTen = user.HoTen;
            this.SDT = user.SDT;
            this.PhanQuyen= user.PhanQuyen;
            this.CMND = user.CMND;
        }

        public void DangXuat()
        {
            this.UserName = "";
            this.HoTen = "";
            this.SDT = "";
            this.PhanQuyen = 0;
            this.CMND = "";
        }

    }
}
