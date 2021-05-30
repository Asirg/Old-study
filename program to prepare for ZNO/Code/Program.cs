using System.Windows.Forms;
using System;

namespace SofiaSpack
{
    static class Program
    {
        /// Головна точка входу у програму
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WindowLogin());
        }
    }
}
