using System;
using System.IO;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace DemoFileRead
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //data reading to the rtf file from mac
                string xml = Start();
                //xml data set on Xmlreader format
            XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml));
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                        Console.WriteLine(rdr.LocalName);
                }
                    //check here node 
                    if (rdr.LocalName == "expression")
                    {
                        var attr = rdr.ReadInnerXmlAsync();
                        Console.WriteLine(attr.Result);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static string Start()
        {
            string AthenaData = "/Users/virtualemployee/Documents" + "/data.txt";
            return  PopulateAthenaData(AthenaData);
        }

        static string  PopulateAthenaData(string s)
        {
            using (StreamReader sr = File.OpenText(s))
            {
                //XmlDocument x = new XmlDocument();
                //x.Load(sr);

                ////AB 20170824
                //XmlNodeList EncryptDataNode = x.GetElementsByTagName("fieldlist");
                //string EncryptDataXML = EncryptDataNode[0].InnerXml;

                string line = sr.ReadToEnd();
                line = line.Remove(0, (404-51));
                return line;
            }
            //StreamReader sr = new StreamReader(s);
            //string line = sr.ReadToEnd();
            //return "";
        }
    }
}
