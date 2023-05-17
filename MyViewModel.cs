using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace HelpDeskAssistant
{
    public class MyViewModel
    {
        public List<Operator> Operators { get; set; }
        public Operator DefaultOperator { get; set; }

        public MyViewModel()
        {
            Operators = new();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Operator>));
            using (StreamReader reader = new StreamReader("Content/Base/Operator.xml"))
            {
                Operators = (List<Operator>)serializer.Deserialize(reader);
            }

            DefaultOperator = Operators[0];

            

        }
        
        
        
    }
}
