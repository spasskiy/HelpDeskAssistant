using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskAssistant.Content.Classes;

namespace HelpDeskAssistant
{
    internal static class MailStringCreator
    {
        static string result;
        static string userId;
        public static string CreateString(Operator @operator, string TT, List<Example> examples, string OurIP, string TheirIP)
        {
            userId = SettingsManager.currentSettings.IsLiteraActive ? SettingsManager.currentSettings.PersonalLitera : "";
            result = @operator.Email + "\n\n";
            result += @operator.Theme + $"({TT}{userId})" + "\n\n";
            result += "Здравствуйте коллеги, пожалуйста проверьте. Клиент жалуется, что не проходят вызовы. \n\n";
            foreach(var example in examples)
            {
                result += "Номер А : " + example.ANumber + "\n";
                result += "Номер Б : " + example.BNumber + "\n";
                result += "Время звонка : " + example.Time + "\n\n";
            }
            result += $"\nIP с вашей стороны : {TheirIP}\n";
            result += $"IP с нашей стороны : {OurIP}\n";
            return result;
        }
    }
}
