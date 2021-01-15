using System;
using System.Xml;

namespace READ_FILE_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPathFile = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\READ FILE XML\READ FILE XML\books.xml";

            ReadFromFileXML(strPathFile);
        }

        public static void ReadFromFileXML(string filePath)
        {
            using (XmlTextReader xmlReader = new XmlTextReader(@"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\READ FILE XML\READ FILE XML\books.xml"))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                    }
                }
            }
        }
    }
}
