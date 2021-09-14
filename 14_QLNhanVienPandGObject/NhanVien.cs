using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject
{
    public interface IXmlMethod
    {
        public void DocXml(XmlNode node, List<NhanVien> ds);
        public void ThemXml(XmlDocument xmlDocument, XmlElement ParentElement, List<NhanVien> ds);
        public void SuaXml(List<NhanVien> ds, string filename, DataSet data, string manv);
    }
    public interface IThiDua {
        public string DanhGiaThiDua();
    }
    public abstract class NhanVien
    {

        CultureInfo provider = CultureInfo.InvariantCulture;
        private string manv;
        private string tennv;
        private DateTime ngaysinh;
        private string gioitinh;
        private string diachi;
        private string sdt;
        private DateTime namvaolam;
        private DateTime namnvchinhthuc;
        private string email;
        private string madonvi;
        private string maphongban;
        private string loainv;
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Namvaolam { get => namvaolam; set => namvaolam = value; }
        public DateTime Namnvchinhthuc { get => namnvchinhthuc; set => namnvchinhthuc = value; }
        public string Email {
            get {
                return email;
            }
            set {
                email = value;
            }
        }

        public string Madonvi { get => madonvi; set => madonvi = value; }
        public string Maphongban { get => maphongban; set => maphongban = value; }
        public string Loainv { get => loainv; set => loainv = value; }

        public NhanVien() {

        }
        protected string TaoMaNhanVien(List<NhanVien> lst) {
            int max = Convert.ToInt32(lst[0].manv.Trim().Substring(lst[0].manv.Trim().Length - 3));
            for (int i = 1; i < lst.Count; i++) {
                if (Convert.ToInt32(lst[i].manv.Trim().Substring(lst[i].manv.Trim().Length - 3)) > max) {
                    max = Convert.ToInt32(lst[i].manv.Trim().Substring(lst[i].manv.Trim().Length - 3));
                }
            }
            return madonvi.ToString() + maphongban + namvaolam.Year.ToString() + (max + 1).ToString("D3");
        }
        private string TaoEmail(List<NhanVien> lst) {
            int duplicate = 0;
            foreach (NhanVien nv in lst) {
                if (nv.tennv == this.tennv) {
                    duplicate++;
                }
            }
            string tenmail = "";
            tennv.Split(' ').ToList().ForEach(i => tenmail += i[0].ToString());
            tenmail = tenmail.Remove(tenmail.Length - 1);
            tenmail = tennv.Split(' ').Last().ToString() + tenmail;
            if (duplicate != 0) {
                tenmail = tenmail + duplicate.ToString("D2");
            }
            return tenmail.ToLower() + "@pg.com";
        }
        public virtual void Them(List<NhanVien> lst) {

            Console.WriteLine("Nhap ten nhan vien: ");
            Tennv = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh nhan vien: ");
            Ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", provider);
            Console.WriteLine("Nhap gioi tinh nhan vien: ");
            Gioitinh = Console.ReadLine();
            Console.WriteLine("Nhap dia chi nhan vien: ");
            Diachi = Console.ReadLine();
            Console.WriteLine("Nhap so dien thoai nhan vien: ");
            Sdt = Console.ReadLine();
            do
            {
                Console.WriteLine("Nhap ngay vao lam: (du 18 tuoi tro len): ");
                Namvaolam = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", provider);
                if (Namvaolam.Year - Ngaysinh.Year < 18) {
                    Console.WriteLine();
                    Console.WriteLine("Chi Nhan Nhan Vien Du 18 tuoi tro len!");
                    Console.WriteLine();
                }
            } while ((Namvaolam.Year - Ngaysinh.Year) < 18);
            DateTime temp = namvaolam.AddMonths(3);
            Namnvchinhthuc = temp;
            Console.WriteLine("Nhap ma don vi cua nhan vien: ");
            Madonvi = Console.ReadLine();
            Manv = TaoMaNhanVien(lst);
            Email = TaoEmail(lst);
        }
        public void Xoa() {
            Console.WriteLine("Nhap Ma Nhan Vien Can Xoa: ");
            manv = Console.ReadLine();
        }
        public int TinhThamNien() {
            return (((DateTime.Now.Year - namvaolam.Year) * 12) + DateTime.Now.Month - namvaolam.Month) / 12;
        }
        public double TinhPhuCapThamNien(int thamnien) {
            //+ Nếu thâm niên<=3 năm: phụ cấp 500 ngàn đồng
            //+ Ngược lại nếu thâm niên <= 6 năm: phụ cấp 2 triệu
            //+ Ngược lại nếu thâm niên<= 10 năm: phụ cấp 4 triệu
            //+ Từ năm thứ 11: 6 triệu, và thêm 500 ngàn cho mỗi năm tăng thâm niên.
            if (thamnien <= 3) {
                return 500000;
            }
            if (thamnien <= 6) {
                return 2000000;
            }
            if (thamnien <= 10) {
                return 4000000;
            }
            int soNamThem = thamnien - 11;
            return 6000000 + soNamThem * 500000;
        }
        public virtual void Xuat(int option) {
            if (option == 1) {
                Console.WriteLine(" + Ma nhan vien: {0}, Ten nhan vien: {1}", manv, tennv);
                Console.WriteLine(" + Dia chi: {0}, SDT: {1}, Email: {2}", diachi, sdt, email);
            }
            if (option == 2) {
                Console.WriteLine(" + Ma nhan vien: {0}, Ten nhan vien: {1}, Ngay sinh: {2}", manv, tennv, ngaysinh.ToShortDateString());
                Console.WriteLine(" + Dia chi: {0}, SDT: {1}, Email: {2}", diachi, sdt, Email);
                Console.WriteLine(" + Ngay vao lam: {0}", namvaolam.ToShortDateString());
            }
            if (option == 3) {
                Console.WriteLine(" + Ma nhan vien: {0}, Ten nhan vien: {1}, Ngay sinh: {2}, Gioi tinh: {3}", manv, tennv, ngaysinh.ToShortDateString(), gioitinh);
                Console.WriteLine(" + Dia chi: {0}, SDT: {1}, Email: {2}", diachi, sdt, email);
                Console.WriteLine(" + Ngay vao lam: {0}, Ngay thanh nv chinh thuc: {1}", namvaolam.ToShortDateString(), namnvchinhthuc.ToShortDateString());
                Console.WriteLine(" + Tham nien: {0} - Phu cap tham nien: {1}", TinhThamNien(), TinhPhuCapThamNien(TinhThamNien()));
                Console.WriteLine(" + Thu Nhap: {0}", TinhTongThuNhap());
            }
        }
        public virtual void Sua(List<NhanVien> lst) {
            Console.WriteLine("Nhap ten nhan vien can sua: ");
            Tennv = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh nhan vien can sua: ");
            Ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", provider);
            Console.WriteLine("Nhap gioi tinh nhan vien can sua: ");
            Gioitinh = Console.ReadLine();
            Console.WriteLine("Nhap dia chi nhan vien can sua: ");
            Diachi = Console.ReadLine();
            Console.WriteLine("Nhap so dien thoai nhan vien can sua: ");
            Sdt = Console.ReadLine();
            do
            {
                Console.WriteLine("Nhap ngay vao lam: (du 18 tuoi tro len): ");
                Namvaolam = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", provider);
            } while ((Namvaolam.Year - Ngaysinh.Year) < 18);
            DateTime temp = namvaolam.AddMonths(3);
            Namnvchinhthuc = temp;
            Email = TaoEmail(lst);
        }
        public void TimKiem()
        {
            Console.WriteLine("Nhap ma nhan vien can tim: ");
            manv = Console.ReadLine();
        }
        public virtual void SuaDataSet(DataSet data, NhanVien nv, int updateIndex) {
            data.Tables[0].Rows[updateIndex]["TENNV"] = nv.tennv;
            data.Tables[0].Rows[updateIndex]["GIOITINH"] = nv.gioitinh;
            data.Tables[0].Rows[updateIndex]["DIACHI"] = nv.diachi;
            data.Tables[0].Rows[updateIndex]["NGAYSINH"] = nv.ngaysinh;
            data.Tables[0].Rows[updateIndex]["SDT"] = nv.sdt;
            data.Tables[0].Rows[updateIndex]["NAMVAOLAM"] = nv.namvaolam;
            data.Tables[0].Rows[updateIndex]["NAMNVCHINHTHUC"] = nv.namvaolam.AddMonths(3);
            data.Tables[0].Rows[updateIndex]["EMAIL"] = nv.email;
        }
        public abstract double TinhTongThuNhap();
        public void XuatThongTinLuong(){
            Console.WriteLine(" + Ma NV: {0}. Ten Nhan Vien: {1}", manv, tennv);
            Console.WriteLine(" + Luong: {0}", TinhTongThuNhap());
        }

    }
}
