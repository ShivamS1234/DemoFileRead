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
                    // please set here your node 
                    if (rdr.LocalName == "expression")
                    {
                        //it will be read your node value
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

                string line = sr.ReadToEnd();
                //if you want remove text to file then you could set text index start to end.
                line = line.Remove(0, (404-51));
                sr.Close();
                return line;
            }
        }
    }
}
