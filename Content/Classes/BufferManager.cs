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

            /*
             try
            {
                Application.Current.Dispatcher.UnhandledException += (sender, e) =>
                {
                    MessageBox.Show("Произошла ошибка: " + e.Exception.Message);
                    e.Handled = true;
                };     

                Thread thread = new Thread(() =>
                {
                    OutputField.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var data = new DataObject();
                        data.SetText(OutputField.Text);
                        Clipboard.SetDataObject(data);
                    }));
                });
                thread.Start();

                // Дождаться завершения потока
                thread.Join();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
             */
        }
    }
}
