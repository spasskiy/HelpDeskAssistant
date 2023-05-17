using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace HelpDeskAssistant.Content.Classes
{
    public class SettingsClass
    {
        public bool IsLiteraActive { get; set; }
        public string PersonalLitera { get; set; }

        public SettingsClass()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Content\\Base\\settings.xml");
            XmlNode personalLiteraNode = doc.SelectSingleNode("/SettingsClass/PersonalLitera");
            XmlNode isLiteraActiveNode = doc.SelectSingleNode("/SettingsClass/IsLiteraActive");
            string personalLiteraValue = personalLiteraNode.InnerText;
            bool isLiteraActiveValue = bool.Parse(isLiteraActiveNode.InnerText);
            PersonalLitera = personalLiteraValue ?? "";
            IsLiteraActive = isLiteraActiveValue;
        }
    }

    public static class SettingsManager
    {
        public static SettingsClass currentSettings = new SettingsClass();
        public static void SaveSettings()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsClass));

            using(FileStream file = new FileStream("Content\\Base\\settings.xml", FileMode.Create))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(file, settings);
                serializer.Serialize(writer, currentSettings);
            }
 
        }
    }


}
