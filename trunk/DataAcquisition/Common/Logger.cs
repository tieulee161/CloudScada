using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;

namespace Common
{
    public class Logger
    {
        private static string _Path
        {
            get
            {
                string res = string.Format("{0}\\Log", Application.StartupPath);
                if (!Directory.Exists(res))
                {
                    Directory.CreateDirectory(res);
                }
                return res;
            }
        }

        public static void Log(string messeage)
        {
            try
            {
                string fileName = string.Format("{0}\\{1}_{2}_{3}.txt", _Path, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
                if (!File.Exists(fileName))
                {
                    StreamWriter sw = File.CreateText(fileName);
                    sw.Close();
                }
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(string.Format("{0} : {1}", DateTime.Now, messeage));
                }
            }
            catch(Exception ex)
            { }
           
        }

        public static void LogRequest(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
