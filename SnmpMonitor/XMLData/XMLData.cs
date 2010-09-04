using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace XMLData
{
    public class XMLData
    {
        XmlDocument doc;
        XmlReader reader;
        public XMLData()
        {
            doc = new XmlDocument();
            string path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Data.xml");
            reader = XmlReader.Create(path);
            doc.Load(reader);
        }
        public string GetDato(string branch, string parametro)
        {
            String valor = "";
            XmlNode nodo = doc.SelectSingleNode("/Data/" + branch);
            valor = nodo[parametro].Attributes["valor"].Value;
            valor.Trim();
            return valor;
        }
        public void SetDato(string branch, string parametro, string valor)
        {
            XmlNode nodo = doc.SelectSingleNode("/Data/" + branch);
            nodo[parametro].Attributes["valor"].Value = valor;
        }
    }
}
