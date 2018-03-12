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

namespace HotKey
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control +  F12
            hook.RegisterHotKey((ModifierKeys)2, Keys.F12);
            hook.RegisterHotKey((ModifierKeys)2, Keys.F11);

        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            if (e.Key == Keys.F11)
            {
                SendKeys.Send("^v");
            }else if(e.Key == Keys.F12)
            {
                SendKeys.Send("^c");
            }
            label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
