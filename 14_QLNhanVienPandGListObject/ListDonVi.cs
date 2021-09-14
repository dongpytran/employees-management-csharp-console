using _14_QLNhanVienPandGObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_QLNhanVienPandGListObject
{
    public class ListDonVi
    {
        private List<DonVi> ds;

        public List<DonVi> Ds { get => ds; set => ds = value; }
        public ListDonVi() {
            ds = new List<DonVi>();
        }
        public ListDonVi(List<DonVi> list) {
            ds = list;
        }

        public void DocFile(string filename)
        {
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            XmlNodeList dvNodeList = xml.SelectNodes("/DonVis/DonVi");
            foreach (XmlNode node in dvNodeList)
            {
                DonVi dv = new DonVi();
                dv.Madonvi = node["MADONVI"].InnerText.Trim();
                dv.Tendonvi = node["TENDONVI"].InnerText.Trim();
                dv.Masothue = node["MASOTHUE"].InnerText.Trim();
                dv.Diachi = node["DIACHI"].InnerText.Trim();

                ds.Add(dv);
            }
        }
        public void Xuat() {
            for (int i = 0; i < ds.Count; i++) {
                Console.WriteLine("- STT: {0}", i+1);
                ds[i].Xuat();
            }
        }
        public bool Them(string filename) {
            try
            {
                DonVi dv = new DonVi();
                dv.Them(ds);
                ds.Add(dv);

                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(filename);

                //Create parent and childs elements
                XmlElement ParentElement = xmlDocument.CreateElement("DonVi");
                XmlElement madv = xmlDocument.CreateElement("MADONVI");
                XmlElement tendv = xmlDocument.CreateElement("TENDONVI");
                XmlElement Masothue = xmlDocument.CreateElement("MASOTHUE");
                XmlElement Diachi = xmlDocument.CreateElement("DIACHI");

                //Sét the data
                madv.InnerText = dv.Madonvi.ToString();
                tendv.InnerText = dv.Tendonvi;
                Masothue.InnerText = dv.Masothue;
                Diachi.InnerText = dv.Diachi;

                //Add child elements to parent
                ParentElement.AppendChild(madv);
                ParentElement.AppendChild(tendv);
                ParentElement.AppendChild(Masothue);
                ParentElement.AppendChild(Diachi);

                //Add parent element to current xml file
                xmlDocument.DocumentElement.AppendChild(ParentElement);
                //Save the file
                xmlDocument.Save(filename);
                return true;
            }
            catch {
                return false;
            }
        }
        public bool Sua(string filename) {
            DonVi dv = new DonVi();
            try
            {
                //Set the infomation
                dv.Sua();
                DataSet data = new DataSet();

                //Read the xml file
                data.ReadXml(filename);

                //Find the index of element base on the infomation seted (madonvi)
                int updateIndex = ds.FindIndex(0, ds.Count, t => t.Madonvi == dv.Madonvi);

                //Update data to that index
                data.Tables[0].Rows[updateIndex]["TENDONVI"] = dv.Tendonvi;
                data.Tables[0].Rows[updateIndex]["MASOTHUE"] = dv.Masothue;
                data.Tables[0].Rows[updateIndex]["DIACHI"] = dv.Diachi;
                //Rewrite the data to the file
                data.WriteXml(filename);
                this.DocFile(filename);
                return true;
            }
            catch {
                return false;
            }
        }
        public bool Xoa(string filename) {
            //DonVi dv = new DonVi();
            //try
            //{
            //    Get the information
            //    dv.Xoa();
            //    DataSet data = new DataSet();
            //    Read the xml file
            //    data.ReadXml(filename);

            //    Find the index of the information seted
            //    int deleteIndex = ds.FindIndex(0, ds.Count, t => t.Madonvi == dv.Madonvi);

            //    Remove element át that index
            //    data.Tables[0].Rows.RemoveAt(deleteIndex);
            //    Rewrite the data to the file
            //    data.WriteXml(filename);
            //    this.DocFile(filename);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            DonVi dv = new DonVi();
            try
            {
                dv.Xoa();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                XmlNode node = xmlDocument.SelectSingleNode("/DonVis/DonVi[MADONVI='" + dv.Madonvi + "']");
                node.ParentNode.RemoveChild(node);
                xmlDocument.Save(filename);
                this.DocFile(filename);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DonVi TimKiem(string filename) {
            DonVi dv = new DonVi();
            dv.TimKiem();
            this.DocFile(filename);
            dv = ds.Where(t => t.Madonvi == dv.Madonvi).SingleOrDefault();
            return dv;
        }
    }
}
