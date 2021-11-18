using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Repository.Repository;
using Repository;
namespace InputRepo
{
    public class XMLAlbumRepo : Rrepository, IAlbumRepo
    {
        private string outputPath = "../../../XMLFiles/Output.xml";
        public XMLAlbumRepo(string path)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("row");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                StringBuilder stringBuilder = new();
                for (int j = 0; j <= 7; j++)
                {
                    stringBuilder.Append(xmlnode[i].ChildNodes.Item(j).InnerText.Trim());
                    stringBuilder.Append(',');
                }
                //take input and make it in csv format
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                string str = stringBuilder.ToString();
                Insert(AddFromDataBaseElement(str));
            }
        }
        public override void Save()
        {
            using (StreamWriter sw = File.CreateText(outputPath))
            {
                var ser = new XmlSerializer(typeof(List<Album>));
                ser.Serialize(sw, albums);
            }
        }

    }
}
