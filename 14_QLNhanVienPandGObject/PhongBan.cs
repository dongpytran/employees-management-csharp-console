using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_QLNhanVienPandGObject
{
    public class PhongBan
    {
        TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
        private string maphong;
        private string tenphong;

        public string Maphong { get => maphong; set => maphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public PhongBan() { }

        public string TaoMaPhong()
        {
            string ma = "";
            tenphong.Split(' ').ToList().ForEach(i => ma += i[0].ToString());
            return ma.ToUpper() + tenphong.Last().ToString().ToUpper();
        }
        public void Them()
        {
            Console.WriteLine("Nhap Ten Phong Ban: ");
            tenphong = Console.ReadLine();
            tenphong = textInfo.ToTitleCase(tenphong);
            maphong = TaoMaPhong();
            if (maphong.Length > 3)
            {
                maphong = maphong.Substring(0, 2) + maphong.Last();
            }
        }

        public void Sua()
        {
            Console.WriteLine("Nhap ma phong ban can sua:  ");
            maphong = Console.ReadLine();

            Console.WriteLine("Nhap ten phong ban can sua:  ");
            tenphong = Console.ReadLine();
        }

        public void Xoa()
        {
            Console.WriteLine("Nhap ma phong ban can xoa: ");
            maphong = Console.ReadLine();
        }

        public void TimKiem()
        {
            Console.WriteLine("Nhap ma phong ban can tim: ");
            maphong = Console.ReadLine();
        }

        public void Xuat()
        {
            Console.WriteLine(" + Ma Phong: {0} - Ten Phong: {1}", maphong, tenphong);
        }
    }
}
