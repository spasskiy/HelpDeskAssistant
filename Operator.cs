using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;

namespace HelpDeskAssistant
{
    public class Operator
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TheirIP { get; set; }

        public string OurIP { get; set; }
        public string Theme { get; set; }

        public Operator(string name, string email, string TheirIP, string OurIP, string theme)
        {
            Name = name;
            Email = email;
            this.TheirIP = TheirIP;
            this.OurIP = OurIP;
            Theme = theme;
        }
        public Operator()
        {
            Name = "";
            Email = "";
            this.TheirIP = "";
            this.OurIP = "";
            Theme = "";
        }
        public override string ToString()
        {
            return Email;
        }
    }
}
