using System;
using System.IO;
using System.Windows.Forms;

namespace CBW
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string executableDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string cemuPath = Path.Combine(executableDirectory, "Cemu.exe");

            if (!File.Exists(cemuPath))
            {
                MessageBox.Show("Cemu.exe was not found.", "Cemu Borderless Window");
                Application.Exit();
                return;
            }
            else
            {
                bool borderlessWindow = false;
                bool showMenuStrip = false;

                string configPath = Path.Combine(executableDirectory, "config.json");

                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    var config = JsonHelper.DeserializeObject(json);

                    borderlessWindow = config.borderlessWindow;
                    showMenuStrip = config.showMenuStrip;
                }
                else
                {
                    var objetoJson = new
                    {
                        borderlessWindow = false,
                        showMenuStrip = false
                    };

                    string json = JsonHelper.SerializeObject(objetoJson);
                    File.WriteAllText(configPath, json);
                }

                Application.Run(new frmMain(borderlessWindow, showMenuStrip, cemuPath, configPath));
            }
        }
    }
}
