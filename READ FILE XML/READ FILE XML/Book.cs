using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
//using System.Xml.Linq;

namespace READ_FILE_XML
{
    class Book
    {
        private string _title;
        private double _price;

        public double Price { get => _price; set => _price = value; }
        public string Title { get => _title; set => _title = value; }
        public Book(string title, double price)
        {
            _title = title;
            _price = price;
        }

        public string ReadFromFileXML(string filePath)
        {
            XmlTextReader textReader = new XmlTextReader(@"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\READ FILE XML\books.xml");
            //XmlReader read = new XmlReader();
        }
    }
}
