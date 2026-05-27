using _3.zadaca___VarazdinTourManager;
using DBLayer;
using System;
using System.Windows.Forms;

namespace VarazdinTourManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DB.SetConfiguration(
                "PI2526_bmilicevi24_DB",
                "PI2526_bmilicevi24",
                "u8xxM.r949oPzmBK"
            );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}