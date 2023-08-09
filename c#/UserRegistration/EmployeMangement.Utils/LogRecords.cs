using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeMangement.Utils
{
    public class LogRecords
    {
        public static void LogRecord(Exception ex)
        {
            string message = ex.Message+ Environment.NewLine;
            while(ex.InnerException != null)
            {
                message += ex.InnerException.Message+ Environment.NewLine;
            }
            string date = DateTime.Now.ToString();
            string design = "==============================================================";
            string pathName = Path.Combine("D:\\Projects\\Assignments\\test\\test2.txt");
            if (File.Exists(pathName))
            {
                File.AppendAllText(pathName,date + Environment.NewLine+design + Environment.NewLine + message + Environment.NewLine+design);
            }
            else
            {
                File.WriteAllText(pathName, message + Environment.NewLine);
            }
        }
    }
}
