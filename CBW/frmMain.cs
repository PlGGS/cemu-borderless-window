using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CBW
{
    public partial class frmMain : Form
    {
        //Import window changing function
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Import find window finding function
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        //Import force window draw function
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        //Import window placement function
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        private const int gwlStyle = -16;
        private const int wsBorder = 0x00800000;
        private const int wsCaption = 0x00C00000;
        private const int wsSysMenu = 0x00080000;
        private const int wsMinimizeBox = 0x00020000;
        private const int wsMenuStrip = 19;
        Screen[] screens = Screen.AllScreens;
        private IntPtr window;
        bool borderlessWindow;
        bool showMenuStrip;
        string cemuDir;
        string gameDir;

        public frmMain(bool bw = false, bool sms = false, string cemu = "", string game = "")
        {
            borderlessWindow = bw;
            showMenuStrip = sms;
            cemuDir = cemu;
            gameDir = game;

            InitializeComponent();
        }

        public static bool checkIfProcessIsRunning(string nameSubstring)
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Contains(nameSubstring));
        }

        public void SetWindow()
        {
            if (chkCBW.CheckState == CheckState.Checked)
            {
                if (chkShowMenuStrip.CheckState == CheckState.Checked)
                {
                    try
                    {
                        SetWindowLong(window, gwlStyle, wsSysMenu);
                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width, screens[0].Bounds.Height + wsMenuStrip, 0x0040);
                        DrawMenuBar(window);
                        Taskbar.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to properly place Cemu into borderless window mode.", "Cemu Borderless Window");
                    }
                }
                else
                {
                    try
                    {
                        SetWindowLong(window, gwlStyle, wsSysMenu);
                        SetWindowPos(window, 0, screens[0].Bounds.X, screens[0].Bounds.Y - wsMenuStrip, screens[0].Bounds.Width, screens[0].Bounds.Height + wsMenuStrip, 0x0040);
                        DrawMenuBar(window);
                        Taskbar.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to properly place Cemu into borderless window mode.", "Cemu Borderless Window");
                    }
                }

            }
            else
            {
                try
                {
                    SetWindowLong(window, gwlStyle, wsCaption | wsBorder | wsSysMenu | wsMinimizeBox);
                    SetWindowPos(window, 0, -6, 0, 1280, 770, 0x0040);
                    DrawMenuBar(window);
                    Taskbar.Show();
                }
                catch
                {
                    MessageBox.Show("Failed to properly place Cemu into windowed mode.", "Cemu Borderless Window");
                }
            }
        }

        private void chkCBW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIfProcessIsRunning("Cemu"))
            {
                SetWindow();
            }
            else
            {
                if (chkCBW.CheckState == CheckState.Checked)
                {
                    MessageBox.Show("Please make sure Cemu is running before attempting to enable or disable borderless window mode.", "Cemu Borderless Window");
                }
                else
                {
                    MessageBox.Show("Please make sure Cemu is running before attempting to enable or disable borderless window mode.", "Cemu Borderless Window");
                }
            }
            
        }

        private void chkShowMenuStrip_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIfProcessIsRunning("Cemu"))
            {
                SetWindow();
            }
            else
            {
                if (chkCBW.CheckState == CheckState.Checked)
                {
                    MessageBox.Show("Please make sure Cemu is running before attempting to enable or disable borderless window mode.", "Cemu Borderless Window");
                }
                else
                {
                    MessageBox.Show("Please make sure Cemu is running before attempting to enable or disable borderless window mode.", "Cemu Borderless Window");
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.CBW;
            Taskbar.Show();

            if (checkIfProcessIsRunning("Cemu"))
            {
                window = Process.GetProcessesByName("Cemu")[0].MainWindowHandle;
            }
            else
            {
                if (cemuDir != "")
                {
                    Process.Start(cemuDir, "-g " + gameDir); //TODO fix gameDir bug
                    System.Threading.Thread.Sleep(1000);
                }
                if (checkIfProcessIsRunning("Cemu"))
                {
                    window = Process.GetProcessesByName("Cemu")[0].MainWindowHandle;
                }
                else
                {
                    MessageBox.Show("Failed to start Cemu from specified locations. Please either make sure Cemu is already running or set its executable location as a command line parameter before attempting to run CBW.", "Cemu Borderless Window");
                    Application.Exit();
                }
            }

            if (borderlessWindow)
            {
                chkCBW.CheckState = CheckState.Checked;
            }

            if (showMenuStrip)
            {
                chkShowMenuStrip.CheckState = CheckState.Checked;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Taskbar.Show();
        }
    }
}
