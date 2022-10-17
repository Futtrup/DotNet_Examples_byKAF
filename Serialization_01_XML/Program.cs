using Serialization_01_XML.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization_01_XML
{
    internal class Program
    {
        static string basePath = AppDomain.CurrentDomain.BaseDirectory;

        static void Main(string[] args)
        {
            Console.WriteLine("This i s simple serialization test app");
            TestWrite();
            TestRead();
            Console.ReadLine();
        }

        static void TestRead()
        {
            Console.WriteLine("\nDeSerialize test - Read file into object");

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(contactinfo));

            string filePath = basePath + "Files\\In\\XMLFile1.xml";
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);

            contactinfo xml = (contactinfo)reader.Deserialize(file);

            Console.WriteLine("XML file loaded into memory done");
        }

        static void TestWrite()
        {
            Console.WriteLine("\nSerialize test - Create an object, serialize and create file");

            contactinfo c = new contactinfo();
            c.name = "John Doe";
            c.phone = "+1234";
            c.company = "Awesomeware 3000";

            var serializer = new XmlSerializer(typeof(contactinfo));
            string utf8;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, c);
                utf8 = writer.ToString();
            }

            string filePath = basePath + "Files\\Out\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml";
            File.WriteAllText(filePath, utf8);

            Console.WriteLine("Created XML file from object in memory done");
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
