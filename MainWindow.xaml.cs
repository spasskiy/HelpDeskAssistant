using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Whois.NET;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using HelpDeskAssistant.Content.Classes;
using HelpDeskAssistant.Content.AdditionalWinows;



namespace HelpDeskAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isInitiaalized = false;
        
        public MainWindow()
        {
            
            InitializeComponent();
            Initialize();
            
        }

        private void Initialize()
        {
            isInitiaalized = true;
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            OutputField.Text = MailStringCreator.CreateString(OperatorComboBox.SelectedItem as Operator, TTName.Text, GenerateExample(), TbOurIP.Text, TbThemIP.Text);
            
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
        }

        private List<Example> GenerateExample()
        {
            List<Example> examples = new();

            if (Tb1A.Text != "" && Tb1B.Text != "" && Tb1P.Text != "")
            {                
                examples.Add(new Example(Tb1A.Text, Tb1B.Text, Tb1P.Text));
            }
            if (Tb2A.Text != "" && Tb2B.Text != "" && Tb2P.Text != "")
            {
                examples.Add(new Example(Tb2A.Text, Tb2B.Text, Tb2P.Text));
            }
            if (Tb3A.Text != "" && Tb3B.Text != "" && Tb3P.Text != "")
            {
                examples.Add(new Example(Tb3A.Text, Tb3B.Text, Tb3P.Text));
            }
            if (Tb4A.Text != "" && Tb4B.Text != "" && Tb4P.Text != "")
            {
                examples.Add(new Example(Tb4A.Text, Tb4B.Text, Tb4P.Text));
            }
            if (Tb5A.Text != "" && Tb5B.Text != "" && Tb5P.Text != "")
            {
                examples.Add(new Example(Tb5A.Text, Tb5B.Text, Tb5P.Text));
            }
            return examples;
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes(MainPanel);
        }

        private void ClearTextBoxes(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is TextBox)
                {
                    ((TextBox)child).Text = string.Empty;
                }
                else
                {
                    ClearTextBoxes(child);
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text.Contains(Environment.NewLine))
                {
                    textBox.Text = textBox.Text.Replace(Environment.NewLine, " ");
                }
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Operator @operator = ((sender as ComboBox).SelectedItem as Operator);

            if (isInitiaalized)
            {
                TbThemIP.Text = @operator.TheirIP;
                TbOurIP.Text = @operator.OurIP;
            }
        }
        private async void ip_Button_Click(object sender, RoutedEventArgs e)
        {
            
              string domainName = TbThemIP.Text;
              var info = await WhoisClient.QueryAsync(TbThemIP.Text);

              string result = "";
              result += string.Format("{0} - {1}", info.AddressRange.Begin, info.AddressRange.End);
              result += "\n" + string.Format("{0}", info.OrganizationName);

              OutputField.Text = result;
            
            
            WhoisClient whois = new WhoisClient();
            WhoisResponse response = info;
            string ipAddress = response.AddressRange.Begin.ToString();
            string url = "https://ipinfo.io/" + ipAddress + "/json";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            JObject obj = JObject.Parse(json);
            string org = (string)obj["org"];
            string country = (string)obj["country"];            
            string city = (string)obj["city"];
            
            string info2 = "Org: " + org + "\nCountry: " + country + "\nCity: " + city;
            OutputField.Text = result + "\n" + info2;


        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(new InfoClass().GetInfo(), 
            "Информация о программе", 
            MessageBoxButton.OK,
            MessageBoxImage.Information);
            
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new();
            settingsWindow.Show();
        }

        private void Button_Calgear(object sender, RoutedEventArgs e)
        {
            OutputField.Text = TopMenuModel.CalgearOutput();
        }
    }
}
