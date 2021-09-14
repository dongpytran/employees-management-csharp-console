using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject.PG1
{
    public class PG1_NVSanXuat : PG1_NhanVien, IPG1XepLoai, IXmlMethod
    {
        
        private int songaynghi;

        public static double hesophucap = 0.1;
        
        public int Songaynghi { get => songaynghi; set => songaynghi = value; }

        public PG1_NVSanXuat() { }

        string IPG1XepLoai.XepLoai()
        {
            if (songaynghi <= 1)
            {
                return "A";
            }
            if (songaynghi <= 3)
            {
                return "B";
            }
            if (songaynghi <= 5)
            {
                return "C";
            }
            return "D";

        }
        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            Maphongban = "SXT";
            Console.WriteLine("Nhap so ngay nghi: ");
            songaynghi = Convert.ToInt32(Console.ReadLine());
            Manv = TaoMaNhanVien(lst);
        }
        public override string TinhXepLoai()
        {
            IPG1XepLoai nhanVienPG1 = this;
            return nhanVienPG1.XepLoai();
            throw new NotImplementedException();
        }
        public override double TinhLuong()
        {
            return Hsluong * luongcb * (1 + hesophucap);
            throw new NotImplementedException();
        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + He so phu cap nang nhoc: {0}, So ngay nghi: {1}", hesophucap, songaynghi);
            }
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            Console.WriteLine("Nhap So ngay nghi can sua: ");
            Songaynghi = Convert.ToInt32(Console.ReadLine());
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            PG1_NVSanXuat nvsx = nv as PG1_NVSanXuat;
            base.SuaDataSet(data, nv, updateIndex);
            data.Tables[0].Rows[updateIndex]["SONGAYNGHI"] = nvsx.songaynghi;
        }

        void IXmlMethod.DocXml(XmlNode node, List<NhanVien> ds) {
            PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
            nvsx.Manv = node["MANV"].InnerText;
            nvsx.Tennv = node["TENNV"].InnerText;
            nvsx.Ngaysinh = Convert.ToDateTime(node["NGAYSINH"].InnerText);
            nvsx.Gioitinh = node["GIOITINH"].InnerText;
            nvsx.Diachi = node["DIACHI"].InnerText;
            nvsx.Sdt = node["SDT"].InnerText;
            nvsx.Namvaolam = Convert.ToDateTime(node["NAMVAOLAM"].InnerText);
            nvsx.Namnvchinhthuc = Convert.ToDateTime((node["NAMNVCHINHTHUC"].InnerText));
            nvsx.Email = node["EMAIL"].InnerText;
            nvsx.Madonvi = node["MADONVI"].InnerText;
            nvsx.Maphongban = node["MAPHONGBAN"].InnerText;
            nvsx.Hsluong = Convert.ToDouble(node["HESOLUONG"].InnerText);
            nvsx.Songaynghi = Convert.ToInt32(node["SONGAYNGHI"].InnerText);
            nvsx.Loainv = node["LOAINV"].InnerText;
            ds.Add(nvsx);
        }
        void IXmlMethod.ThemXml(XmlDocument xmlDocument, XmlElement ParentElement, List<NhanVien> ds) {
            PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
            nvsx.Them(ds);
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

            XmlElement loaiNhanVien = xmlDocument.CreateElement("LOAINV");
            XmlElement hesoLuong = xmlDocument.CreateElement("HESOLUONG");
            XmlElement soNgayNghi = xmlDocument.CreateElement("SONGAYNGHI");

            //Sét the data
            manv.InnerText = nvsx.Manv;
            tennv.InnerText = nvsx.Tennv;
            ngaysinh.InnerText = nvsx.Ngaysinh.ToShortDateString();
            gioitinh.InnerText = nvsx.Gioitinh;
            diachi.InnerText = nvsx.Diachi;
            sdt.InnerText = nvsx.Sdt;
            namvaolam.InnerText = nvsx.Namvaolam.ToShortDateString();
            email.InnerText = nvsx.Email;
            madonvi.InnerText = nvsx.Madonvi;
            maphongban.InnerText = nvsx.Maphongban;
            namchinhthuc.InnerText = nvsx.Namnvchinhthuc.ToShortDateString();

            loaiNhanVien.InnerText = "PG1_SX";
            hesoLuong.InnerText = nvsx.Hsluong.ToString();
            soNgayNghi.InnerText = nvsx.Songaynghi.ToString();

            //Add child elements to parent
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

            ParentElement.AppendChild(loaiNhanVien);
            ParentElement.AppendChild(hesoLuong);
            ParentElement.AppendChild(soNgayNghi);

            //Add parent element to current xml file
            xmlDocument.DocumentElement.AppendChild(ParentElement);
        }

        void IXmlMethod.SuaXml(List<NhanVien> ds, string filename, DataSet data, string manv) {
            PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
            //Set the infomation
            nvsx.Sua(ds);
            //Find the index of element base on the infomation seted (madonvi)
            int updateIndex = ds.FindIndex(0, ds.Count, t => t.Manv == manv);
            nvsx.SuaDataSet(data, nvsx, updateIndex);
        }
    }
}
