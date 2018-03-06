using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool borderlessWindow = false;
            bool showMenuStrip = false;
            string cemuDir = "";

            if (args.Length % 2 == 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-bw":
                            borderlessWindow = Convert.ToBoolean(args[++i]);
                            break;
                        case "-sms":
                            showMenuStrip = Convert.ToBoolean(args[++i]);
                            break;
                        case "-cemu":
                            cemuDir = args[++i];
                            break;
                        case "-c":
                            cemuDir = args[++i];
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure all command line parameters have proper values after their references. Please surround executable locations with quotation marks if they contain spaces.", "Cemu Borderless Window");
                Application.Exit();
            }

            Application.Run(new frmMain(borderlessWindow, showMenuStrip, cemuDir));
        }
    }
}
