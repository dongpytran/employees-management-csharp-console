using _14_QLNhanVienPandGObject;
using _14_QLNhanVienPandGObject.PG1;
using _14_QLNhanVienPandGObject.PG2;
using _14_QLNhanVienPandGObject.PG3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGListObject
{
    public class ListLuong
    {
        public List<NhanVien> ds = new List<NhanVien>();
        public List<NhanVien> dsnv = new List<NhanVien>();
        public int countKhongCoNangLucTot = 0;
        public ListLuong() { }

        public void DocFile(string filename) {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
        }
        public void XuatBangLuongTrongThang(string filename, int thang, int nam)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList listNodeThang;
            XmlNodeList listNodeNhanVien;
            XmlNodeList listNodeNam = xmlDocument.SelectNodes("/BangLuongs/Nam");
            foreach (XmlNode nodeNam in listNodeNam)
            {
                if (Convert.ToInt32(nodeNam.Attributes["nam"].Value) == nam)
                {
                    listNodeThang = nodeNam.SelectNodes("/BangLuongs/Nam/Thang");
                    foreach (XmlNode nodeThang in listNodeThang)
                    {
                        if (Convert.ToInt32(nodeThang.Attributes["thang"].Value) == thang)
                        {
                            if (!nodeThang.HasChildNodes)
                            {
                                Console.WriteLine("{0}/{1}: Chua Co Du Lieu Bang Luong!", thang, nam);
                            }
                            else
                            {
                                listNodeNhanVien = nodeThang.ChildNodes;
                                if (listNodeNhanVien.Count == 0)
                                {
                                    Console.WriteLine("{0}/{1} : Chua Co Du Lieu Luong!", thang, nam);
                                }
                                else
                                {
                                    LoadNhanVien(listNodeNhanVien);
                                    XuatHangThang();
                                }
                                break;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0}: Chua Co Du Lieu Bang Luong!", nam);
                }
            }
            
        }
        public void XuatBangLuongHangThang(string filename, int nam)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList listNodeThang;
            XmlNodeList listNodeNhanVien;
            XmlNodeList listNodeNam = xmlDocument.SelectNodes("/BangLuongs/Nam");
            foreach (XmlNode nodeNam in listNodeNam)
            {
                if (Convert.ToInt32(nodeNam.Attributes["nam"].Value) == nam)
                {
                    listNodeThang = nodeNam.SelectNodes("/BangLuongs/Nam/Thang");
                    foreach (XmlNode nodeThang in listNodeThang)
                    {
                        if (!nodeThang.HasChildNodes)
                        {
                            Console.WriteLine("=> {0}/{1}: Chua Co Du Lieu Bang Luong!", nodeThang.Attributes["thang"].Value, nam);
                        }
                        else
                        {
                            listNodeNhanVien = nodeThang.ChildNodes as XmlNodeList;
                            LoadNhanVien(listNodeNhanVien);
                            Console.WriteLine();
                            Console.WriteLine("=> {0}/{1}: ", nodeThang.Attributes["thang"].Value, nam);
                            XuatHangThang();
                            ds.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0}: Chua Co Du Lieu Bang Luong!", nam);
                }
            }

        }
        public void XuatHangThang()
        {
            List<NhanVien> pg1 = ds.Where(t => t.Loainv.Substring(0, 3) == "PG1").ToList();
            List<NhanVien> pg2 = ds.Where(t => t.Loainv == "PG2").ToList();
            List<NhanVien> pg3 = ds.Where(t => t.Loainv == "PG3").ToList();
            Console.WriteLine("PG1: ");
            for (int i = 0; i < pg1.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("- STT: {0}", i + 1);
                pg1[i].XuatThongTinLuong();
                Console.WriteLine("----------------------------------------");
            }
            Console.WriteLine("PG2: ");
            for (int i = 0; i < pg2.Count; i++)
            {
                Console.WriteLine();

                Console.WriteLine("- STT: {0}", i + 1);
                pg2[i].XuatThongTinLuong();
                Console.WriteLine("----------------------------------------");
            }
            Console.WriteLine("PG3: ");
            for (int i = 0; i < pg3.Count; i++)
            {
                Console.WriteLine();

                Console.WriteLine("- STT: {0}", i + 1);
                pg3[i].XuatThongTinLuong();
                Console.WriteLine("----------------------------------------");
            }
        }

        private void LoadNhanVien(XmlNodeList listNodeNhanVien)
        {
            IXmlMethod method;
            foreach (XmlNode node in listNodeNhanVien)
            {
                string loai = node["LOAINV"].InnerText.Trim();
                if (loai == "PG1_SX")
                {
                    PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
                    method = nvsx;
                    method.DocXml(node, ds);
                }
                if (loai == "PG1_KD")
                {
                    PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
                    method = nvkd;
                    method.DocXml(node, ds);
                }
                if (loai == "PG1_QL")
                {
                    PG1_CanBoQL cbql = new PG1_CanBoQL();
                    method = cbql;
                    method.DocXml(node, ds);
                }
                if (loai == "PG2")
                {
                    PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
                    method = pG2_NhanVien;
                    method.DocXml(node, ds);
                }
                if (loai == "PG3")
                {
                    PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
                    method = pG3_NhanVien;
                    method.DocXml(node, ds);
                }
            }
        }
        public List<NhanVien> DemNhanVienThiDua(string filename)
        {
            ListNhanVien list = new ListNhanVien();
            list.DocFile(filename);
            return list.Ds;
        }
        public void XuatAllThiDua(string filename, int nam, string filenv, int option) {
            dsnv = DemNhanVienThiDua(filenv);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList listNodeThang;
            XmlNodeList listNodeNhanVien;
            XmlNodeList listNodeNam = xmlDocument.SelectNodes("/BangLuongs/Nam");
            foreach (XmlNode nodeNam in listNodeNam)
            {
                if (Convert.ToInt32(nodeNam.Attributes["nam"].Value) == nam)
                {
                    listNodeThang = nodeNam.ChildNodes;
                    int index = 1;
                    foreach (NhanVien nv in dsnv) {
                        int countA = 0;
                        int countC = 0;
                        int countD = 0;
                        int countChienSi = 0;
                        int countLaoDong = 0;
                        int countKhongDat = 0;
                        foreach (XmlNode nodeThang in listNodeThang)
                        {
                            if (!nodeThang.HasChildNodes)
                            {
                                Console.WriteLine("=> {0}/{1}: Chua Co Du Lieu Bang Luong!", nodeThang.Attributes["thang"].Value, nam);
                            }
                            else
                            {
                                listNodeNhanVien = nodeThang.ChildNodes;
                                foreach (XmlNode nodeNhanVien in listNodeNhanVien)
                                {
                                    if (nodeNhanVien.FirstChild.InnerText.Trim() == nv.Manv.Trim()) {
                                        string loainv = nv.Loainv;
                                        if (loainv.Substring(0, 3) == "PG1") {
                                            PG1_NhanVien pG1_NhanVien = nv as PG1_NhanVien;
                                            if (pG1_NhanVien.TinhXepLoai() == "A") {
                                                countA++;
                                            }
                                            if (pG1_NhanVien.TinhXepLoai() == "C") {
                                                countC++;
                                            }
                                            if (pG1_NhanVien.TinhXepLoai() == "D") {
                                                countD++;
                                            }
                                        }
                                        if (loainv == "PG2") {
                                            PG2_NhanVien pG2_NhanVien = nv as PG2_NhanVien;
                                            if (pG2_NhanVien.TinhThiDua() == 1) {
                                                countChienSi++;
                                            }
                                            if (pG2_NhanVien.TinhThiDua() == 2) {
                                                countLaoDong++;
                                            }
                                            if (pG2_NhanVien.TinhThiDua() == -1) {
                                                countKhongDat++;
                                            }
                                        }
                                        if (loainv == "PG3") {
                                            PG3_NhanVien pG3_NhanVien = nv as PG3_NhanVien;
                                            if (pG3_NhanVien.TinhThiDua() == 1)
                                            {
                                                countChienSi++;
                                            }
                                            if (pG3_NhanVien.TinhThiDua() == 2)
                                            {
                                                countLaoDong++;
                                            }
                                            if (pG3_NhanVien.TinhThiDua() == -1)
                                            {
                                                countKhongDat++;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        if (option == 0)
                        {
                            Console.WriteLine("-- STT: {0}", index);
                            if (nv.GetType() == typeof(PG1_NVSanXuat) || nv.GetType() == typeof(PG1_NVKinhDoanh) || nv.GetType() == typeof(PG1_CanBoQL))
                            {
                                if (countA >= 10)
                                {
                                    Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    Console.WriteLine(" + Danh Gia Nhan Vien: Nang Luc Tot");
                                }
                                else
                                {
                                    if (countC <= 2 && countD <= 1)
                                    {
                                        Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                        Console.WriteLine(" + Danh Gia Nhan Vien: Co Nang Luc");
                                        countKhongCoNangLucTot++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                        Console.WriteLine(" + Danh Gia Nhan Vien: Khong Co Nang Luc");
                                        countKhongCoNangLucTot++;
                                    }
                                }
                            }

                            if (nv.GetType() == typeof(PG2_NhanVien) || nv.GetType() == typeof(PG3_NhanVien))
                            {
                                if (countChienSi > 9)
                                {
                                    Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    Console.WriteLine(" + Danh Gia Nhan Vien: Nang Luc Tot");
                                }
                                else
                                {
                                    if (countKhongDat < 3)
                                    {
                                        Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                        Console.WriteLine(" + Danh Gia Nhan Vien: Co Nang Luc");
                                        countKhongCoNangLucTot++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("- Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                        Console.WriteLine(" + Danh Gia Nhan Vien: Khong Co Nang Luc");
                                        countKhongCoNangLucTot++;
                                    }
                                }
                            }
                            index++;
                        }
                        else {
                            
                            if (nv.GetType() == typeof(PG1_NVSanXuat) || nv.GetType() == typeof(PG1_NVKinhDoanh) || nv.GetType() == typeof(PG1_CanBoQL))
                            {
                                if (countA >= 10)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("-- STT: {0}", index);
                                    if (countC <= 2 && countD <= 1)
                                    {
                                        Console.WriteLine(" + Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    }
                                    else
                                    {
                                        Console.WriteLine(" + Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    }
                                    index++;
                                }
                            }
                            
                            if (nv.GetType() == typeof(PG2_NhanVien) || nv.GetType() == typeof(PG3_NhanVien))
                            {
                                if (countChienSi > 9)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("-- STT: {0}", index);
                                    if (countKhongDat < 3)
                                    {
                                        Console.WriteLine(" + Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    }
                                    else
                                    {
                                        Console.WriteLine(" + Ma Nv: {0} - Ten Nhan Vien: {1}", nv.Manv, nv.Tennv);
                                    }
                                    index++;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void DemSoNhanVienKhongCoNangLucTot(int nam) {
            Console.WriteLine("=> Nam: {0} Tong Cong Ty P&G co: {1} nhan vien Khong Co \"Nang Luc Tot\"", nam, countKhongCoNangLucTot);
        }
        public void XuatTop3(string filename, int nam, int thang) {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList listNodeThang;
            XmlNodeList listNodeNhanVien;
            XmlNodeList listNodeNam = xmlDocument.SelectNodes("/BangLuongs/Nam");
            foreach (XmlNode nodeNam in listNodeNam)
            {
                if (Convert.ToInt32(nodeNam.Attributes["nam"].Value) == nam)
                {
                    listNodeThang = nodeNam.SelectNodes("/BangLuongs/Nam/Thang");
                    foreach (XmlNode nodeThang in listNodeThang)
                    {
                        if (Convert.ToInt32(nodeThang.Attributes["thang"].Value) == thang)
                        {
                            if (!nodeThang.HasChildNodes)
                            {
                                Console.WriteLine("{0}/{1}: Chua Co Du Lieu Bang Luong!", thang, nam);
                            }
                            else
                            {
                                listNodeNhanVien = nodeThang.ChildNodes;
                                LoadNhanVien(listNodeNhanVien);
                                List<NhanVien> pg1 = ds.Where(t => t.Loainv.Substring(0, 3) == "PG1").ToList();
                                List<NhanVien> pg2 = ds.Where(t => t.Loainv == "PG2").ToList();
                                List<NhanVien> pg3 = ds.Where(t => t.Loainv ==  "PG3").ToList();
                                pg1 = pg1.OrderByDescending(t => t.TinhTongThuNhap()).Take(3).ToList();
                                pg2 = pg2.OrderByDescending(t => t.TinhTongThuNhap()).Take(3).ToList();
                                pg3 = pg3.OrderByDescending(t => t.TinhTongThuNhap()).Take(3).ToList();
                                Console.WriteLine("- 3 Nhan Vien Luong Cao Nhat PG1: ");
                                foreach (NhanVien nv in pg1) {
                                    nv.XuatThongTinLuong();
                                }
                                Console.WriteLine("- 3 Nhan Vien Luong Cao Nhat PG2: ");
                                foreach (NhanVien nv in pg2)
                                {
                                    nv.XuatThongTinLuong();
                                }
                                Console.WriteLine("- 3 Nhan Vien Luong Cao Nhat PG3: ");
                                foreach (NhanVien nv in pg3)
                                {
                                    nv.XuatThongTinLuong();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0}: Chua Co Du Lieu Bang Luong!", nam);
                }
            }
        }
    }
}
