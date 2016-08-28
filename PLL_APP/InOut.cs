using System;
using System.Drawing;
using System.Windows.Forms;

using Multicad.Runtime;

namespace PLL_APP
{
    public class InOut
    {
        [CommandMethod("Pll_Work", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public void StartApp()
        {
         GlobalForm startform = new GlobalForm();
         HostMgd.ApplicationServices.Application.ShowModelessDialog(startform);
        }        
    }
}
