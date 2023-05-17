using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HelpDeskAssistant.Content.Classes
{
    public class InfoClass
    {
        public string GetInfo()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Content/Base/Info.xml");
            
            XmlNode infoNode = doc.SelectSingleNode("/Information/Info");
            string infoValue = infoNode.InnerText;
            return infoValue;
        }

        public InfoClass() { }
    }
}
