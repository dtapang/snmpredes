using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Base
{
    class XMLData
    {
        XmlDocument doc;
        XmlReader reader;
        public XMLData()
        {
            doc = new XmlDocument();
            string path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "conexion.xml");
            reader = XmlReader.Create(path);
            doc.Load(reader);
        }
        public string GetParametro(string parametro)
        {
            String valor = "";
            XmlNode nodo = doc.SelectSingleNode("/Data/Parametros");
            valor = nodo[parametro].Attributes["valor"].Value;
            valor.Trim();
            return valor;
        }
        public void SetParametro(string parametro, string valor)
        {
            XmlNode nodo = doc.SelectSingleNode("/Data/Parametros");
            nodo[parametro].Attributes["valor"].Value = valor;
        }
    }
}
