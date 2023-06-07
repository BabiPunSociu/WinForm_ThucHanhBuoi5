using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhBuoi5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fLogin = new frmLogin();
            Application.Run(fLogin);
            if(fLogin.IsLogined == true)
            {
                frmHang fHang = new frmHang(fLogin.user);
                Application.Run(fHang);
            }    
                
        }
    }
}
