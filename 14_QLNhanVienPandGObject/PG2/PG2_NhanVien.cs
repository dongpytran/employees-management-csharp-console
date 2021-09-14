using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject.PG2
{
    public class PG2_NhanVien : NhanVien, IXmlMethod, IThiDua
    {
        private double doanhthuthang;
        private double doanhthuchitieu;
        private double phucap;

        public double Doanhthuthang { get => doanhthuthang; set => doanhthuthang = value; }
        public double Doanhthuchitieu { get => doanhthuchitieu; set => doanhthuchitieu = value; }
        public double Phucap { get => phucap; set => phucap = value; }

        public PG2_NhanVien() { }
        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            Console.WriteLine("Nhap Ma Phong Ban: ");
            Maphongban = Console.ReadLine();
            Console.WriteLine("Nhap doanh thu chi tieu thang: ");
            doanhthuchitieu = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap doanh thu thuc te trong thang: ");
            doanhthuthang = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap Phu Cap Cong Tac Phi: ");
            phucap = Convert.ToDouble(Console.ReadLine());
            Manv = TaoMaNhanVien(lst);
            
        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + Doanh Thu Chi Tieu: {0}", doanhthuchitieu);
                Console.WriteLine(" + Doanh Thu Trong Thang: {0}", doanhthuthang);
                Console.WriteLine(" + Phu Cap Cong Tac Phi: {0}", phucap);
            }
        }
        public override double TinhTongThuNhap()
        {
            double vuot = doanhthuthang - doanhthuchitieu;
            if (vuot < 0) {
                return doanhthuthang * 0.1 + TinhPhuCapThamNien(TinhThamNien()) + phucap;
            }
            if (vuot == 0 || vuot < 0.2 * doanhthuchitieu) {
                return doanhthuthang * 0.2 + TinhPhuCapThamNien(TinhThamNien()) + phucap;
            }
            if (vuot >= 0.2 * doanhthuchitieu && vuot < 0.5 * doanhthuchitieu) {
                return doanhthuthang * 0.25 + TinhPhuCapThamNien(TinhThamNien()) + phucap;
            }
            if (vuot >= 0.5 * doanhthuchitieu) {
                return doanhthuthang * 0.3 + TinhPhuCapThamNien(TinhThamNien()) + phucap + 10000000;
            }
            throw new NotImplementedException();
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            Console.WriteLine("Nhap doanh thu chi tieu thang can sua: ");
            doanhthuchitieu = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap doanh thu thuc te trong thang can sua: ");
            doanhthuthang = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap Phu Cap Cong Tac Phi can sua: ");
            phucap = Convert.ToDouble(Console.ReadLine());
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            base.SuaDataSet(data, nv, updateIndex);
            PG2_NhanVien pG2_NhanVien = nv as PG2_NhanVien;
            data.Tables[0].Rows[updateIndex]["DOANHTHUCHITIEU"] = pG2_NhanVien.doanhthuchitieu;
            data.Tables[0].Rows[updateIndex]["DOANHTHUTHANG"] = pG2_NhanVien.doanhthuthang;
            data.Tables[0].Rows[updateIndex]["PHUCAP"] = pG2_NhanVien.phucap;
        }
        void IXmlMethod.DocXml(System.Xml.XmlNode node, List<NhanVien> ds) {
            PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
            pG2_NhanVien.Manv = node["MANV"].InnerText;
            pG2_NhanVien.Tennv = node["TENNV"].InnerText;
            pG2_NhanVien.Ngaysinh = Convert.ToDateTime(node["NGAYSINH"].InnerText);
            pG2_NhanVien.Gioitinh = node["GIOITINH"].InnerText;
            pG2_NhanVien.Diachi = node["DIACHI"].InnerText;
            pG2_NhanVien.Sdt = node["SDT"].InnerText;
            pG2_NhanVien.Namvaolam = Convert.ToDateTime(node["NAMVAOLAM"].InnerText);
            pG2_NhanVien.Namnvchinhthuc = Convert.ToDateTime((node["NAMNVCHINHTHUC"].InnerText));
            pG2_NhanVien.Email = node["EMAIL"].InnerText;
            pG2_NhanVien.Madonvi = node["MADONVI"].InnerText;
            pG2_NhanVien.Maphongban = node["MAPHONGBAN"].InnerText;
            pG2_NhanVien.Doanhthuchitieu = Convert.ToDouble(node["DOANHTHUCHITIEU"].InnerText);
            pG2_NhanVien.Doanhthuthang = Convert.ToDouble(node["DOANHTHUTHANG"].InnerText);
            pG2_NhanVien.Phucap = Convert.ToDouble(node["PHUCAP"].InnerText);
            pG2_NhanVien.Loainv = node["LOAINV"].InnerText;
            ds.Add(pG2_NhanVien);
        }
        void IXmlMethod.ThemXml(System.Xml.XmlDocument xmlDocument, System.Xml.XmlElement ParentElement, List<NhanVien> ds) {
            PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
            pG2_NhanVien.Them(ds);

            XmlElement loaiNhanVien = xmlDocument.CreateElement("LOAINV");

            XmlElement doanhThuChiTieu = xmlDocument.CreateElement("DOANHTHUCHITIEU");
            XmlElement doanhThuThang = xmlDocument.CreateElement("DOANHTHUTHANG");
            XmlElement phuCap = xmlDocument.CreateElement("PHUCAP");

            XmlElement manv = xmlDocument.CreateElement("MANV");
            XmlElement tennv = xmlDocument.CreateElement("TENNV");
            XmlElement ngaysinh = xmlDocument.CreateElement("NGAYSINH");
            XmlElement gioitinh = xmlDocument.CreateElement("GIOITINH");
            XmlElement diachi = xmlDocument.CreateElement("DIACHI");
            XmlElement sdt = xmlDocument.CreateElement("SDT");
            XmlElement namvaolam = xmlDocument.CreateElement("NAMVAOLAM");
            XmlElement namchinhthuc = xmlDocument.CreateElement("NAMNVCHINHTHUC");
            XmlElement email = xmlDocument.CreateElement("EMAIL");
            XmlElement madonvi = xmlDocument.CreateElement("MADONVI");
            XmlElement maphongban = xmlDocument.CreateElement("MAPHONGBAN");


            //Sét the data
            manv.InnerText = pG2_NhanVien.Manv;
            tennv.InnerText = pG2_NhanVien.Tennv;
            ngaysinh.InnerText = pG2_NhanVien.Ngaysinh.ToShortDateString();
            gioitinh.InnerText = pG2_NhanVien.Gioitinh;
            diachi.InnerText = pG2_NhanVien.Diachi;
            sdt.InnerText = pG2_NhanVien.Sdt;
            namvaolam.InnerText = pG2_NhanVien.Namvaolam.ToShortDateString();
            email.InnerText = pG2_NhanVien.Email;
            madonvi.InnerText = pG2_NhanVien.Madonvi;
            maphongban.InnerText = pG2_NhanVien.Maphongban;
            namchinhthuc.InnerText = pG2_NhanVien.Namnvchinhthuc.ToShortDateString();

            loaiNhanVien.InnerText = "PG2";
            doanhThuChiTieu.InnerText = pG2_NhanVien.Doanhthuchitieu.ToString();
            doanhThuThang.InnerText = pG2_NhanVien.Doanhthuthang.ToString();
            phuCap.InnerText = pG2_NhanVien.Phucap.ToString();

            //Add child elements to parent

            ParentElement.AppendChild(loaiNhanVien);
            ParentElement.AppendChild(doanhThuChiTieu);
            ParentElement.AppendChild(doanhThuThang);
            ParentElement.AppendChild(phuCap);

            ParentElement.AppendChild(manv);
            ParentElement.AppendChild(tennv);
            ParentElement.AppendChild(ngaysinh);
            ParentElement.AppendChild(gioitinh);
            ParentElement.AppendChild(diachi);
            ParentElement.AppendChild(sdt);
            ParentElement.AppendChild(namvaolam);
            ParentElement.AppendChild(namchinhthuc);
            ParentElement.AppendChild(email);
            ParentElement.AppendChild(madonvi);
            ParentElement.AppendChild(maphongban);
            //Add parent element to current xml file
            xmlDocument.DocumentElement.AppendChild(ParentElement);
        }
        void IXmlMethod.SuaXml(List<NhanVien> ds, string filename, DataSet data, string manv) {
            PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
            //Set the infomation
            pG2_NhanVien.Sua(ds);
            //Find the index of element base on the infomation seted (madonvi)
            int updateIndex = ds.FindIndex(0, ds.Count, t => t.Manv == manv);
            pG2_NhanVien.SuaDataSet(data, pG2_NhanVien, updateIndex);
        }
        public int TinhThiDua() {
            if (TinhTongThuNhap() >= 25000000) return 1;
            if (TinhTongThuNhap() >= 20000000) return 2;
            return -1;
        }
        string IThiDua.DanhGiaThiDua() {
            string kq = "";
            if (TinhThiDua() == 1) kq = "Chien Si Thi Dua";
            if (TinhThiDua() == 2) kq = "Lao Dong Tien Tien";
            if (TinhThiDua() == -1) kq = "Khong Dat Chi Tieu";
            return kq;
        }
    }
}
