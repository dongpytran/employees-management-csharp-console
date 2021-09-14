using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _14_QLNhanVienPandGObject;
using System.Xml;
using System.Data;

namespace _14_QLNhanVienPandGListObject
{
    public class ListPhongBan
    {
        private List<PhongBan> ds;

        public List<PhongBan> Ds { get => ds; set => ds = value; }
        public ListPhongBan()
        {
            ds = new List<PhongBan>();
        }
        public ListPhongBan(List<PhongBan> list)
        {
            ds = list;
        }

        public void DocFile(string filename)
        {
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);
            XmlNodeList dvNodeList = xml.SelectNodes("/PhongBans/PhongBan");
            foreach (XmlNode node in dvNodeList)
            {
                PhongBan pb = new PhongBan();
                pb.Maphong = node["MAPHONGBAN"].InnerText.Trim();
                pb.Tenphong = node["TENPHONGBAN"].InnerText.Trim();

                ds.Add(pb);
            }
        }

        public void Xuat()
        {
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine("- STT: {0}", i + 1);
                ds[i].Xuat();
            }
        }

        public bool Them(string filename)
        {
            try
            {
                PhongBan pb = new PhongBan();
                pb.Them();
                ds.Add(pb);

                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(filename);

                //Create parent and childs elements
                XmlElement ParentElement = xmlDocument.CreateElement("PhongBan");
                XmlElement mapb = xmlDocument.CreateElement("MAPHONGBAN");
                XmlElement tenpb = xmlDocument.CreateElement("TENPHONGBAN");

                //Sét the data
                mapb.InnerText = pb.Maphong.ToString();
                tenpb.InnerText = pb.Tenphong;

                //Add child elements to parent
                ParentElement.AppendChild(mapb);
                ParentElement.AppendChild(tenpb);

                //Add parent element to current xml file
                xmlDocument.DocumentElement.AppendChild(ParentElement);
                //Save the file
                xmlDocument.Save(filename);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(string filename)
        {
            PhongBan pb = new PhongBan();
            try
            {
                //Set the infomation
                pb.Sua();
                DataSet data = new DataSet();

                //Read the xml file
                data.ReadXml(filename);

                //Find the index of element base on the infomation seted (madonvi)
                int updateIndex = ds.FindIndex(0, ds.Count, t => t.Maphong == pb.Maphong);

                //Update data to that index
                data.Tables[0].Rows[updateIndex]["TENPHONGBAN"] = pb.Tenphong;

                //Rewrite the data to the file
                data.WriteXml(filename);
                this.DocFile(filename);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(string filename)
        {
            PhongBan pb = new PhongBan();
            try
            {
                pb.Xoa();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                XmlNode node = xmlDocument.SelectSingleNode("/PhongBans/PhongBan[MAPHONGBAN='" + pb.Maphong + "']");
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

        public PhongBan TimKiem(string filename)
        {
            PhongBan pb = new PhongBan();
            pb.TimKiem();
            this.DocFile(filename);
            pb = ds.Where(t => t.Maphong == pb.Maphong).SingleOrDefault();
            return pb;
        }
    }
}
