using grayzen.HotkeyHandling;
using grayzen.State;
using System;
using System.Windows.Forms;

namespace grayzen
{
    

    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon trayIcon;

        public TrayApplicationContext()
        {
            // Initialize Tray Icon
            MenuItem menuItem = new MenuItem("Disable for one minute", DisableForOneMinute);
            menuItem.Checked = false;
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.grayzen,
                ContextMenu = new ContextMenu(new MenuItem[] {
                menuItem,
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            AppState.InitApp();
        }


        // Menu items
        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        void DisableForOneMinute(object sender, EventArgs e) => AppState.EnableColourModeForTimeInterval(60_000);
    }
}
