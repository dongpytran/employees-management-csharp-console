using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_QLNhanVienPandGObject.PG1
{
    interface IPG1XepLoai
    {
        string XepLoai();
    }
    public abstract class PG1_NhanVien : NhanVien
    {   
        private double hsluong;
        public static double luongcb = 1400000;
        public static double[] listHsl = { 2.34, 2.67, 3.0, 3.33, 3.66, 3.99, 4.32, 4.65 };
        
        public double Hsluong { get => hsluong; set => hsluong = value; }
        public PG1_NhanVien()
        {
        }
        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            do
            {
                Console.WriteLine("Nhap he so luong ( 2.34, 2.67, 3.0, 3.33, 3.66, 3.99, 4.32, 4.65 ): ");
                hsluong = Convert.ToDouble(Console.ReadLine());
                if (Array.IndexOf(listHsl, hsluong) == -1) {
                    Console.WriteLine();
                    Console.WriteLine("Nhap He So Luong Sai!");
                    Console.WriteLine();
                }
            } while (Array.IndexOf(listHsl, hsluong) == -1);
        }
        public abstract double TinhLuong();
        //public double ThuNhap() {
            
        //}
        public abstract string TinhXepLoai();
        public override double TinhTongThuNhap()
        {
            if (TinhXepLoai() == "A")
                return TinhLuong() + TinhPhuCapThamNien(TinhThamNien());
            if (TinhXepLoai() == "B")
                return (TinhLuong() * 0.75) + TinhPhuCapThamNien(TinhThamNien());
            if (TinhXepLoai() == "C")
                return (TinhLuong() * 0.5) + TinhPhuCapThamNien(TinhThamNien());
            return TinhPhuCapThamNien(TinhThamNien());
            throw new NotImplementedException();
        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + He So Luong: {0}, Luong Co Ban: {1}", hsluong, luongcb);
                Console.WriteLine(" + Xep loai: {0}", TinhXepLoai());
            }
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            do
            {
                Console.WriteLine("Nhap he so luong ( 2.34, 2.67, 3.0, 3.33, 3.66, 3.99, 4.32, 4.65 ): ");
                hsluong = Convert.ToDouble(Console.ReadLine());
                if (Array.IndexOf(listHsl, hsluong) == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhap He So Luong Sai!");
                    Console.WriteLine();
                }
            } while (Array.IndexOf(listHsl, hsluong) == -1);
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            base.SuaDataSet(data, nv, updateIndex);
            PG1_NhanVien nvpg1 = nv as PG1_NhanVien;
            data.Tables[0].Rows[updateIndex]["HESOLUONG"] = nvpg1.hsluong;
        }

    }
}
