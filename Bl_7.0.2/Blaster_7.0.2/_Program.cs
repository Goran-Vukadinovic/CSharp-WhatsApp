#region using

using System;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Blaster
{
    internal class _Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                ApplicationManager.Run();        
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] Exception :\n" + ex);
            }
        }
    }
}