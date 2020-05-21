using grayzen.HotkeyHandling;
using grayzen.State;
using System;
using System.Windows.Forms;

namespace grayzen
{
    using static NativeMethods;

    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon trayIcon;

        public TrayApplicationContext()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.Cube,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit),
                new MenuItem("Grey", Gray),
                new MenuItem("Color", Color)
            }),
                Visible = true
            };

            MagInitialize();

            KeyboardHook hook = new KeyboardHook();
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(HotkeyModifierKeys.Control | HotkeyModifierKeys.Alt,
                Keys.Space);

            AppActions.GoGrey();
        }


        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            AppActions.ColorFor1Min();
        }

        // Menu items
        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        void Gray(object sender, EventArgs e) => AppActions.GoGrey();

        void Color(object sender, EventArgs e) => AppActions.GoNormal();
    }
}
