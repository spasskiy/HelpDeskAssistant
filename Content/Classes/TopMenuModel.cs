using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HelpDeskAssistant.Content.Classes
{
    internal static class TopMenuModel
    {
        internal static string XMLParser(string xml)
        {            
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            string result = "";
            
            XmlNodeList nodeList = doc.GetElementsByTagName("text");
            foreach (XmlNode node in nodeList)
            {
                result += node.InnerText;         
            }
            return result;
        }
        internal static string CalgearOutput()
        {
            return XMLParser("Content/Base/calgear_f.xml");
        }
    }
}
