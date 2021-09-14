using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGObject.PG1
{
    public class PG1_NVKinhDoanh : PG1_NhanVien, IPG1XepLoai, IXmlMethod
    {
        private double doanhsoTT;
        private double doanhthu;

        public double DoanhsoTT { get => doanhsoTT; set => doanhsoTT = value; }
        public double Doanhthu { get => doanhthu; set => doanhthu = value; }

        public PG1_NVKinhDoanh() { }

        string IPG1XepLoai.XepLoai() {
            if (doanhthu < 0.5 * doanhsoTT) return "D";
            if (doanhthu < doanhsoTT) return "C";
            if (doanhthu == doanhsoTT) return "B";
            return "A";
        }
        public double TinhHoaHong() {
            if (doanhthu - doanhsoTT > 0)
            {
                return (doanhthu - doanhsoTT) * 0.15;
            }
            return 0;
        }
        public override string TinhXepLoai()
        {
            IPG1XepLoai nhanVienPG1 = this;
            return nhanVienPG1.XepLoai();
        }
        public override double TinhLuong()
        {
            return Hsluong * luongcb + TinhHoaHong();
            
            throw new NotImplementedException();
        }
        public override void Them(List<NhanVien> lst)
        {
            base.Them(lst);
            Maphongban = "KDH";
            Console.WriteLine("Nhap vao doanh so toi thieu: ");
            doanhsoTT = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap vao doanh thu thang nay: ");
            doanhthu = Convert.ToDouble(Console.ReadLine());
            Manv = TaoMaNhanVien(lst);

        }
        public override void Xuat(int option)
        {
            base.Xuat(option);
            if (option == 3) {
                Console.WriteLine(" + Doanh So Toi Thieu: {0}, Doanh Thu Thuc Te: {1}", doanhsoTT, doanhthu);
                Console.WriteLine(" + Hoa Hong: {0}", TinhHoaHong());
            }
        }
        public override void Sua(List<NhanVien> lst)
        {
            base.Sua(lst);
            Console.WriteLine("Nhap Doanh So Toi Thieu Can Sua: ");
            doanhsoTT = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap Doanh Thu Thuc Te Can Sua: ");
            doanhthu = Convert.ToDouble(Console.ReadLine());
        }
        public override void SuaDataSet(DataSet data, NhanVien nv, int updateIndex)
        {
            base.SuaDataSet(data, nv, updateIndex);
            PG1_NVKinhDoanh nvkd = nv as PG1_NVKinhDoanh;
            data.Tables[0].Rows[updateIndex]["DOANHSOTT"] = nvkd.doanhsoTT;
            data.Tables[0].Rows[updateIndex]["DOANHTHU"] = nvkd.doanhthu;
        }

        void IXmlMethod.DocXml(System.Xml.XmlNode node, List<NhanVien> ds) {
            PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
            nvkd.Manv = node["MANV"].InnerText;
            nvkd.Tennv = node["TENNV"].InnerText;
            nvkd.Ngaysinh = Convert.ToDateTime(node["NGAYSINH"].InnerText);
            nvkd.Gioitinh = node["GIOITINH"].InnerText;
            nvkd.Diachi = node["DIACHI"].InnerText;
            nvkd.Sdt = node["SDT"].InnerText;
            nvkd.Namvaolam = Convert.ToDateTime(node["NAMVAOLAM"].InnerText);
            nvkd.Namnvchinhthuc = Convert.ToDateTime((node["NAMNVCHINHTHUC"].InnerText));
            nvkd.Email = node["EMAIL"].InnerText;
            nvkd.Madonvi = node["MADONVI"].InnerText;
            nvkd.Maphongban = node["MAPHONGBAN"].InnerText;
            nvkd.Hsluong = Convert.ToDouble(node["HESOLUONG"].InnerText);
            nvkd.DoanhsoTT = Convert.ToDouble(node["DOANHSOTT"].InnerText);
            nvkd.Doanhthu = Convert.ToDouble(node["DOANHTHU"].InnerText);
            nvkd.Loainv = node["LOAINV"].InnerText;
            ds.Add(nvkd);
        }
        void IXmlMethod.ThemXml(System.Xml.XmlDocument xmlDocument, System.Xml.XmlElement ParentElement, List<NhanVien> ds) {
            PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
            nvkd.Them(ds);
            XmlElement loaiNhanVien = xmlDocument.CreateElement("LOAINV");
            XmlElement hesoLuong = xmlDocument.CreateElement("HESOLUONG");
            XmlElement doanhSoTT = xmlDocument.CreateElement("DOANHSOTT");
            XmlElement doanhThu = xmlDocument.CreateElement("DOANHTHU");

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
            manv.InnerText = nvkd.Manv;
            tennv.InnerText = nvkd.Tennv;
            ngaysinh.InnerText = nvkd.Ngaysinh.ToShortDateString();
            gioitinh.InnerText = nvkd.Gioitinh;
            diachi.InnerText = nvkd.Diachi;
            sdt.InnerText = nvkd.Sdt;
            namvaolam.InnerText = nvkd.Namvaolam.ToShortDateString();
            email.InnerText = nvkd.Email;
            madonvi.InnerText = nvkd.Madonvi;
            maphongban.InnerText = nvkd.Maphongban;
            namchinhthuc.InnerText = nvkd.Namnvchinhthuc.ToShortDateString();

            loaiNhanVien.InnerText = "PG1_KD";
            hesoLuong.InnerText = nvkd.Hsluong.ToString();
            doanhSoTT.InnerText = nvkd.DoanhsoTT.ToString();
            doanhThu.InnerText = nvkd.Doanhthu.ToString();

            //Add child elements to parent
            ParentElement.AppendChild(loaiNhanVien);
            ParentElement.AppendChild(hesoLuong);
            ParentElement.AppendChild(doanhSoTT);
            ParentElement.AppendChild(doanhThu);

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
            PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
            //Set the infomation
            nvkd.Sua(ds);

            

            //Find the index of element base on the infomation seted (madonvi)
            int updateIndex = ds.FindIndex(0, ds.Count, t => t.Manv == manv);
            nvkd.SuaDataSet(data, nvkd, updateIndex);
        }
    }
}
