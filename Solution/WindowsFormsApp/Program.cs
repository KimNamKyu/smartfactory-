using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CAR);
            Application.Run(new Form2());
        }

        static Assembly CAR(object o, ResolveEventArgs a)
        {
            try
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp.Test.dll");
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                Assembly assembly = Assembly.Load(assemblyData);
                stream.Close();
                return assembly;
            }
            catch
            {
                return null;
            }
        }
    }
}
