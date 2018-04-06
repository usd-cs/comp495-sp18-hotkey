using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            newHook.Register(); // registering globally that A will call a method
        }

        protected override void WndProc(ref Message cmd)
        {
            if (cmd.Msg == 0x0312)
                HandleHotkey(); // A, which was registered before, was pressed
            base.WndProc(ref cmd);
        }

        private void HandleHotkey()
        {
            // instead of A send Q
            KeyboardManager.PressKey(Keys.Q);
        }
    }
}
