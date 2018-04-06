using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KeyboardHook newHook = new KeyboardHook((int)KeyboardHook.Modifiers.None, Keys.A, this);

            newHook.Register();
        }

        //Captures all inputs directted towards our window. However, since we are handling all global hotkeys it
        //will then capture every keyinput made by the user
        protected override void WndProc(ref Message cmd)
        {
            //Message is just the actual key input in this case we are listening in for 'a'
            //the 0x0312 is handle for hotkeys (see this link https://msdn.microsoft.com/en-us/library/windows/desktop/ms646279(v=vs.85).aspx)
            //We then handle this hotkey we registed with the handlehotkey
            if (cmd.Msg == 0x0312)
                HandleHotkey();
            base.WndProc(ref cmd);
        }

        private void HandleHotkey()
        {
            // instead of A send Q
            //We defaulted this but in the future we will need to make a delegate for each hotkey
            // KeyboardManager.PressKey(Keys.Q);
            Process p = null;
            try
            {
                ProcessStartInfo si = new ProcessStartInfo("IExplore.exe", "www.reddit.com");
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
