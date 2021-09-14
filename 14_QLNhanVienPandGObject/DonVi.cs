using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject
{
    public class DonVi
    {
        private string madonvi;
        private string tendonvi;
        private string masothue;
        private string diachi;

        public string Madonvi { get => madonvi; set => madonvi = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
        public string Masothue { get => masothue; set => masothue = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        public DonVi() { }
        public DonVi(string madonvi, string tendonvi, string masothue, string diachi) {
            this.madonvi = madonvi;
            this.tendonvi = tendonvi;
            this.masothue = masothue;
            this.diachi = diachi;
        }
        public string TaoMaDonVi(List<DonVi> lst) {
            int max = Convert.ToInt32(lst[0].madonvi.Trim());
            for (int i = 1; i < lst.Count; i++)
            {
                if (Convert.ToInt32(lst[i].madonvi.Trim()) > max) {
                    max = Convert.ToInt32(lst[i].madonvi.Trim());
                }
            }
            return (max + 1).ToString("D2");
        }
        public void Them(List<DonVi> lst) {
            Madonvi = TaoMaDonVi(lst);
            Console.WriteLine("Nhap ten don vi: ");
            Tendonvi = Console.ReadLine();
            Console.WriteLine("Nhap ma so thue: ");
            Masothue = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            Diachi = Console.ReadLine();
        }
        public void Sua() {
            Console.WriteLine("Nhap ma don vi can sua:  ");

            madonvi = Console.ReadLine();
            Console.WriteLine("Nhap ten don vi can sua:  ");
            tendonvi = Console.ReadLine();
            Console.WriteLine("Nhap ma so thue can sua:  ");
            masothue = Console.ReadLine();
            Console.Write("Nhap dia chi can sua: ");
            diachi = Console.ReadLine();
            
        }
        public void Xoa() {
            Console.WriteLine("Nhap ma don vi can xoa: ");
            madonvi = Console.ReadLine();
        }
        public void TimKiem() {
            Console.WriteLine("Nhap ma don vi can tim: ");
            madonvi = Console.ReadLine();
        }
        public void Xuat() {
            Console.WriteLine(" + Ma Don Vi: {0}, Ten Don Vi: {1}", madonvi, tendonvi);
            Console.WriteLine(" + Ma So Thue: {0}, Dia Chi: {1}", masothue, diachi);
        }
    }
}
