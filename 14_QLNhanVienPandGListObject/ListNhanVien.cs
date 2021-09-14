using _14_QLNhanVienPandGObject;
using _14_QLNhanVienPandGObject.PG1;
using _14_QLNhanVienPandGObject.PG2;
using _14_QLNhanVienPandGObject.PG3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _14_QLNhanVienPandGListObject
{
    public class ListNhanVien
    {
        private List<NhanVien> ds;

        public List<NhanVien> Ds { get => ds; set => ds = value; }
        public ListNhanVien() {
            ds = new List<NhanVien>();
        }
        public void DocFile(string filename) {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            XmlNodeList dvNodeList = xml.SelectNodes("/NhanViens/NhanVien");
            IXmlMethod method;
            foreach (XmlNode node in dvNodeList)
            {
                string loai = node["LOAINV"].InnerText.Trim();
                if (loai == "PG1_SX") {
                    PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
                    method = nvsx;
                    method.DocXml(node, ds);
                }
                if (loai == "PG1_KD") {
                    PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
                    method = nvkd;
                    method.DocXml(node, ds);
                }
                if (loai == "PG1_QL") {
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
        public void Xuat(int option)
        {
            for (int i = 0; i < ds.Count; i++) {
                Console.WriteLine();
                Console.WriteLine("- STT: {0}", i + 1);
                ds[i].Xuat(option);
                Console.WriteLine("----------------------------------------");
            }
        }
        public bool Them(string filename, int type)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                //Create parent and childs elements
                XmlElement ParentElement = xmlDocument.CreateElement("NhanVien");
                IXmlMethod method;
                if (type == 1) {
                    PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
                    method = nvsx;
                    method.ThemXml(xmlDocument, ParentElement, ds);
                    //Save the file
                    xmlDocument.Save(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (type == 2) {
                    PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
                    method = nvkd;
                    method.ThemXml(xmlDocument, ParentElement, ds);
                    //Save the file
                    xmlDocument.Save(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (type == 3) {
                    PG1_CanBoQL cbql = new PG1_CanBoQL();
                    method = cbql;
                    method.ThemXml(xmlDocument, ParentElement, ds);
                    //Save the file
                    xmlDocument.Save(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (type == 4)
                {
                    PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
                    method = pG2_NhanVien;
                    method.ThemXml(xmlDocument, ParentElement, ds);
                    //Save the file
                    xmlDocument.Save(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (type == 5)
                {
                    PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
                    method = pG3_NhanVien;
                    method.ThemXml(xmlDocument, ParentElement, ds);
                    //Save the file
                    xmlDocument.Save(filename);
                    this.DocFile(filename);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Sua(string filename, string manv) {
            NhanVien nv = ds.Where(t => t.Manv == manv).Single();
            try
            {
                IXmlMethod method;
                if (nv.Loainv == "PG1_SX") {
                    PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
                    DataSet data = new DataSet();
                    //Read the xml file
                    data.ReadXml(filename);
                    method = nvsx;
                    method.SuaXml(ds, filename, data, manv);
                    data.WriteXml(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (nv.Loainv == "PG1_KD") {
                    PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
                    DataSet data = new DataSet();
                    //Read the xml file
                    data.ReadXml(filename);
                    method = nvkd;
                    method.SuaXml(ds, filename, data, manv);
                    data.WriteXml(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (nv.Loainv == "PG1_QL") {
                    PG1_CanBoQL cbql = new PG1_CanBoQL();
                    DataSet data = new DataSet();
                    //Read the xml file
                    data.ReadXml(filename);
                    method = cbql;
                    method.SuaXml(ds, filename, data, manv);
                    //Rewrite the data to the file
                    data.WriteXml(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (nv.Loainv == "PG2")
                {
                    PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
                    DataSet data = new DataSet();
                    //Read the xml file
                    data.ReadXml(filename);
                    method = pG2_NhanVien;
                    method.SuaXml(ds, filename, data, manv);
                    //Rewrite the data to the file
                    data.WriteXml(filename);
                    this.DocFile(filename);
                    return true;
                }
                if (nv.Loainv == "PG3")
                {
                    PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
                    //Set the infomation
                    DataSet data = new DataSet();
                    //Read the xml file
                    data.ReadXml(filename);
                    method = pG3_NhanVien;
                    method.SuaXml(ds, filename, data, manv);
                    //Rewrite the data to the file
                    data.WriteXml(filename);
                    this.DocFile(filename);
                    return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(string filename) {
            try
            {
                PG1_NVSanXuat nv = new PG1_NVSanXuat();
                nv.Xoa();

                //When delete whe dont need to classify the Type of NhanVien because
                // the Delete method need the same input is "manV"

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                XmlNode node = xmlDocument.SelectSingleNode("/NhanViens/NhanVien[MANV='" + nv.Manv + "']");
                node.ParentNode.RemoveChild(node);
                xmlDocument.Save(filename);
                this.DocFile(filename);
                return true;
            }
            catch {
                return false;
            }
        }
        public NhanVien TimKiem(string filename, string manv) {
            this.DocFile(filename);
            string loai = ds.Where(t => t.Manv == manv).SingleOrDefault().Loainv;
            if (loai != null)
            {
                if (loai == "PG1_SX")
                {
                    PG1_NVSanXuat nvsx = new PG1_NVSanXuat();
                    nvsx = ds.Where(t => t.Manv == manv).SingleOrDefault() as PG1_NVSanXuat;
                    return nvsx;
                }
                if (loai == "PG1_KD")
                {
                    PG1_NVKinhDoanh nvkd = new PG1_NVKinhDoanh();
                    nvkd = ds.Where(t => t.Manv == manv).SingleOrDefault() as PG1_NVKinhDoanh;
                    return nvkd;
                }
                if (loai == "PG1_QL")
                {
                    PG1_CanBoQL ql = new PG1_CanBoQL();
                    ql = ds.Where(t => t.Manv == manv).SingleOrDefault() as PG1_CanBoQL;
                    return ql;
                }
                if (loai == "PG2") {
                    PG2_NhanVien pG2_NhanVien = new PG2_NhanVien();
                    pG2_NhanVien = ds.Where(t => t.Manv == manv).SingleOrDefault() as PG2_NhanVien;
                    return pG2_NhanVien;
                }
                if (loai == "PG3")
                {
                    PG3_NhanVien pG3_NhanVien = new PG3_NhanVien();
                    pG3_NhanVien = ds.Where(t => t.Manv == manv).SingleOrDefault() as PG3_NhanVien;
                    return pG3_NhanVien;
                }
                return null;
            }
            else {
                return null;
            }
        }

        public void DemSoNhanVienMoiCty()
        {
            int pg1, pg2, pg3 = 0;
            pg1 = ds.Count(t => t.Loainv.Substring(0, 3) == "PG1");
            pg2 = ds.Count(t => t.Loainv == "PG2");
            pg3 = ds.Count(t => t.Loainv == "PG3");
            Console.WriteLine();
            Console.WriteLine("- So Nhan Vien Cong Ty P&G 1 La: {0}", pg1);
            Console.WriteLine("- So Nhan Vien Cong Ty P&G 2 La: {0}", pg2);
            Console.WriteLine("- So Nhan Vien Cong Ty P&G 3 La: {0}", pg3);
            Console.WriteLine();
        }
        public void DemSoNhanVienMoi(int thang, int nam){
            int pg1, pg2, pg3 = 0;
            pg1 = ds.Where(t=>t.Loainv.Substring(0,3) == "PG1").Count(t => t.Namvaolam.Month == thang && t.Namvaolam.Year == nam);
            pg2 = ds.Where(t => t.Loainv == "PG2").Count(t => t.Namvaolam.Month == thang && t.Namvaolam.Year == nam);
            pg3 = ds.Where(t => t.Loainv == "PG3").Count(t => t.Namvaolam.Month == thang && t.Namvaolam.Year == nam);
            Console.WriteLine();
            Console.WriteLine("- So Nhan Vien Moi Vao Cong Ty P&G 1 Trong {0}/{1} La: {2}", thang, nam, pg1);
            Console.WriteLine("- So Nhan Vien Moi Vao Cong Ty P&G 2 Trong {0}/{1} La: {2}", thang, nam, pg2);
            Console.WriteLine("- So Nhan Vien Moi Vao Cong Ty P&G 3 Trong {0}/{1} La: {2}", thang, nam, pg3);
            Console.WriteLine();
        }
    }
}
