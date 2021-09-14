using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject.PG1
{
    public class PG1_CanBoQL : PG1_NhanVien, IPG1XepLoai, IXmlMethod
    {
        private string chucvu;
        private double hschucvu;

        public string Chucvu { get => chucvu; set => chucvu = value; }
        public double Hschucvu { get => hschucvu; set => hschucvu = value; }

        public PG1_CanBoQL() { }

        string IPG1XepLoai.XepLoai() {
            return "A";
        }
        public override string TinhXepLoai()
        {
            IPG1XepLoai nhanVienPG1 = this;
            return nhanVienPG1.XepLoai();
            throw new NotImplementedException();
        }
        public double TinhPhuCapChucVu() {
            return hschucvu * 2000000;
        }
        public override double TinhLuong()
        {
            return Hsluong * luongcb + TinhPhuCapChucVu();
            throw new NotImplementedException();
        }
        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            Maphongban = "QLY";
            Console.WriteLine("Nhap Chuc Vu: ");
            Chucvu = Console.ReadLine();
            Console.WriteLine("Nhap He So Chuc Vu: ");
            Hschucvu = Convert.ToDouble(Console.ReadLine());
            Manv = TaoMaNhanVien(lst);
        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + Chuc Vu: {0}, He So Chuc Vu: {1}", chucvu, hschucvu);
            }
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            Console.WriteLine("Nhap Chuc Vu Can Sua: ");
            chucvu = Console.ReadLine();
            Console.WriteLine("Nhap He So Chuc Vu Can Sua: ");
            hschucvu = Convert.ToDouble(Console.Read());
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            base.SuaDataSet(data, nv, updateIndex);
            PG1_CanBoQL ql = nv as PG1_CanBoQL;
            data.Tables[0].Rows[updateIndex]["CHUCVU"] = ql.chucvu;
            data.Tables[0].Rows[updateIndex]["HSCHUCVU"] = ql.hschucvu;
        }

        void IXmlMethod.DocXml(System.Xml.XmlNode node, List<NhanVien> ds) {
            PG1_CanBoQL cbql = new PG1_CanBoQL();
            cbql.Manv = node["MANV"].InnerText;
            cbql.Tennv = node["TENNV"].InnerText;
            cbql.Ngaysinh = Convert.ToDateTime(node["NGAYSINH"].InnerText);
            cbql.Gioitinh = node["GIOITINH"].InnerText;
            cbql.Diachi = node["DIACHI"].InnerText;
            cbql.Sdt = node["SDT"].InnerText;
            cbql.Namvaolam = Convert.ToDateTime(node["NAMVAOLAM"].InnerText);
            cbql.Namnvchinhthuc = Convert.ToDateTime((node["NAMNVCHINHTHUC"].InnerText));
            cbql.Email = node["EMAIL"].InnerText;
            cbql.Madonvi = node["MADONVI"].InnerText;
            cbql.Maphongban = node["MAPHONGBAN"].InnerText;
            cbql.Hsluong = Convert.ToDouble(node["HESOLUONG"].InnerText);
            cbql.Chucvu = node["CHUCVU"].InnerText;
            cbql.Hschucvu = Convert.ToDouble(node["HSCHUCVU"].InnerText);
            cbql.Loainv = node["LOAINV"].InnerText;
            ds.Add(cbql);
        }
        void IXmlMethod.ThemXml(System.Xml.XmlDocument xmlDocument, System.Xml.XmlElement ParentElement, List<NhanVien> ds) {
            PG1_CanBoQL cbql = new PG1_CanBoQL();
            cbql.Them(ds);

            XmlElement loaiNhanVien = xmlDocument.CreateElement("LOAINV");
            XmlElement hesoLuong = xmlDocument.CreateElement("HESOLUONG");
            XmlElement chucVu = xmlDocument.CreateElement("CHUCVU");
            XmlElement hsChucVu = xmlDocument.CreateElement("HSCHUCVU");

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
            manv.InnerText = cbql.Manv;
            tennv.InnerText = cbql.Tennv;
            ngaysinh.InnerText = cbql.Ngaysinh.ToShortDateString();
            gioitinh.InnerText = cbql.Gioitinh;
            diachi.InnerText = cbql.Diachi;
            sdt.InnerText = cbql.Sdt;
            namvaolam.InnerText = cbql.Namvaolam.ToShortDateString();
            email.InnerText = cbql.Email;
            madonvi.InnerText = cbql.Madonvi;
            maphongban.InnerText = cbql.Maphongban;
            namchinhthuc.InnerText = cbql.Namnvchinhthuc.ToShortDateString();

            loaiNhanVien.InnerText = "PG1_QL";
            hesoLuong.InnerText = cbql.Hsluong.ToString();
            chucVu.InnerText = cbql.Chucvu;
            hsChucVu.InnerText = cbql.Hschucvu.ToString();

            //Add child elements to parent

            ParentElement.AppendChild(loaiNhanVien);
            ParentElement.AppendChild(hesoLuong);
            ParentElement.AppendChild(chucVu);
            ParentElement.AppendChild(hsChucVu);

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
            PG1_CanBoQL cbql = new PG1_CanBoQL();
            //Set the infomation
            cbql.Sua(ds);
            //Find the index of element base on the infomation seted (madonvi)
            int updateIndex = ds.FindIndex(0, ds.Count, t => t.Manv == manv);
            cbql.SuaDataSet(data, cbql, updateIndex);
        }
    }
}
