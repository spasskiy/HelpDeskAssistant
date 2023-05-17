using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HelpDeskAssistant.Content.Classes
{
    public class BufferManager
    {
       public void CtrlC(string str)
        {
            var data = new DataObject();
            data.SetText(str);
            Clipboard.SetDataObject(data);
        }
    }
}
