using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject.PG3
{
    public class PG3_NhanVien : NhanVien, IXmlMethod, IThiDua
    {
        private int khdinhmuc;
        private int khmoi;

        public int Khdinhmuc { get => khdinhmuc; set => khdinhmuc = value; }
        public int Khmoi { get => khmoi; set => khmoi = value; }

        public PG3_NhanVien() { }

        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            Console.WriteLine("Nhap Ma Phong Ban: ");
            Maphongban = Console.ReadLine();
            Console.WriteLine("Nhap So Khach Hang Dinh Muc: ");
            khdinhmuc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap So Khach Hang Moi: ");
            khmoi = Convert.ToInt32(Console.ReadLine());
            Manv = TaoMaNhanVien(lst);
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            Console.WriteLine("Nhap So Khach Hang Dinh Muc Can Sua: ");
            khdinhmuc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap So Khach Hang Moi Can Sua: ");
            khmoi = Convert.ToInt32(Console.ReadLine());
        }
        public override double TinhTongThuNhap()
        {
            int vuot = khmoi - khdinhmuc;
            if (vuot < 0) {
                return 0.6 * khmoi + 2000000 + TinhPhuCapThamNien(TinhThamNien());
            }
            if (vuot == 0 || vuot <= 0.2 * khdinhmuc) {
                return khmoi + 2000000 + TinhPhuCapThamNien(TinhThamNien());
            }
            if (vuot > 0.2 * khdinhmuc && vuot <= 0.5 * khdinhmuc) {
                return 1.2 * khmoi + 2000000 + TinhPhuCapThamNien(TinhThamNien());
            }
            if (vuot > 0.5 * khdinhmuc) {
                return 1.4 * khmoi + 2000000 + 6000000 + TinhPhuCapThamNien(TinhThamNien());
            }
            throw new NotImplementedException();
        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + So KH Dinh Muc: {0}", khdinhmuc);
                Console.WriteLine(" + So KH Moi: {0}", khmoi);
            }
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            base.SuaDataSet(data, nv, updateIndex);
            PG3_NhanVien pG3_NhanVien = nv as PG3_NhanVien;
            data.Tables[0].Rows[updateIndex]["KHDINHMUC"] = pG3_NhanVien.khdinhmuc;
            data.Tables[0].Rows[updateIndex]["KHMOI"] = pG3_NhanVien.khmoi;
        }
        void IXmlMethod.DocXml(System.Xml.XmlNode node, List<NhanVien> ds) {
            PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
            pG3_NhanVien.Manv = node["MANV"].InnerText;
            pG3_NhanVien.Tennv = node["TENNV"].InnerText;
            pG3_NhanVien.Ngaysinh = Convert.ToDateTime(node["NGAYSINH"].InnerText);
            pG3_NhanVien.Gioitinh = node["GIOITINH"].InnerText;
            pG3_NhanVien.Diachi = node["DIACHI"].InnerText;
            pG3_NhanVien.Sdt = node["SDT"].InnerText;
            pG3_NhanVien.Namvaolam = Convert.ToDateTime(node["NAMVAOLAM"].InnerText);
            pG3_NhanVien.Namnvchinhthuc = Convert.ToDateTime((node["NAMNVCHINHTHUC"].InnerText));
            pG3_NhanVien.Email = node["EMAIL"].InnerText;
            pG3_NhanVien.Madonvi = node["MADONVI"].InnerText;
            pG3_NhanVien.Maphongban = node["MAPHONGBAN"].InnerText;
            pG3_NhanVien.Khdinhmuc = Convert.ToInt32(node["KHDINHMUC"].InnerText);
            pG3_NhanVien.Khmoi = Convert.ToInt32(node["KHMOI"].InnerText);
            pG3_NhanVien.Loainv = node["LOAINV"].InnerText;
            ds.Add(pG3_NhanVien);
        }
        void IXmlMethod.ThemXml(System.Xml.XmlDocument xmlDocument, System.Xml.XmlElement ParentElement, List<NhanVien> ds) {
            PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
            pG3_NhanVien.Them(ds);

            XmlElement loaiNhanVien = xmlDocument.CreateElement("LOAINV");

            XmlElement khDinhMuc = xmlDocument.CreateElement("KHDINHMUC");
            XmlElement khMoi = xmlDocument.CreateElement("KHMOI");

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
            manv.InnerText = pG3_NhanVien.Manv;
            tennv.InnerText = pG3_NhanVien.Tennv;
            ngaysinh.InnerText = pG3_NhanVien.Ngaysinh.ToShortDateString();
            gioitinh.InnerText = pG3_NhanVien.Gioitinh;
            diachi.InnerText = pG3_NhanVien.Diachi;
            sdt.InnerText = pG3_NhanVien.Sdt;
            namvaolam.InnerText = pG3_NhanVien.Namvaolam.ToShortDateString();
            email.InnerText = pG3_NhanVien.Email;
            madonvi.InnerText = pG3_NhanVien.Madonvi;
            maphongban.InnerText = pG3_NhanVien.Maphongban;
            namchinhthuc.InnerText = pG3_NhanVien.Namnvchinhthuc.ToShortDateString();

            loaiNhanVien.InnerText = "PG3";
            khDinhMuc.InnerText = pG3_NhanVien.Khdinhmuc.ToString();
            khMoi.InnerText = pG3_NhanVien.Khmoi.ToString();

            //Add child elements to parent

            ParentElement.AppendChild(loaiNhanVien);
            ParentElement.AppendChild(khDinhMuc);
            ParentElement.AppendChild(khMoi);

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
            PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
            //Set the infomation
            pG3_NhanVien.Sua(ds);
            //Find the index of element base on the infomation seted (madonvi)
            int updateIndex = ds.FindIndex(0, ds.Count, t => t.Manv == manv);
            pG3_NhanVien.SuaDataSet(data, pG3_NhanVien, updateIndex);
        }
        public int TinhThiDua()
        {
            if (TinhTongThuNhap() >= 25000000) return 1;
            if (TinhTongThuNhap() >= 20000000) return 2;
            return -1;
        }
        string IThiDua.DanhGiaThiDua()
        {
            string kq = "";
            if (TinhThiDua() == 1) kq = "Chien Si Thi Dua";
            if (TinhThiDua() == 2) kq = "Lao Dong Tien Tien";
            if (TinhThiDua() == -1) kq = "Khong Dat Chi Tieu";
            return kq;
        }
    }
}
