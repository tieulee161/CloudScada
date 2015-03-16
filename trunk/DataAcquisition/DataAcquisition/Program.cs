using System;
using System.Linq;
using System.Windows.Forms;
using DataAcquisition.View;
using System.Threading;
using System.IO;

namespace DataAcquisition
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (!IsAlreadyRunning())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMain());
                }
                else
                {
                    MessageBox.Show("Chương trình đang hoạt động !");
                    Application.Exit();
                }
            }
            catch (Exception)
            {
            }
        }

        static Mutex mutex;

        private static bool IsAlreadyRunning()
        {
            string strLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;
            mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();
            return !bCreatedNew;
        }
    }
}