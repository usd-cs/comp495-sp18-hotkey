using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HotKey_MainFolder
{
    //DISPLAYS DATA OF HOTKEYITEM
    public partial class HotKeyControl : UserControl
    {
        private HotKeyItem hotKeyItem;

        public HotKeyControl()
        {
            InitializeComponent();
        }

        public HotKeyControl(HotKeyItem hotKeyItem)
        {
            InitializeComponent();

            this.hotKeyItem = hotKeyItem;
            actionLabel.Text = hotKeyItem.ActionName;
            if (hotKeyItem.Key == Keys.None)
                keybindButton.Text = "Not bound";
            else
                SetKeybindText(hotKeyItem);
        }

        private void SetKeybindText(HotKeyItem hotKeyItem)
        {
            keybindButton.Text = string.Format("{0}+{1}", hotKeyItem.ModKeys, hotKeyItem.Key).Replace(" ", "").Replace(",", "+").Replace("Control", "CTRL").ToUpper() ;
        }

        private void KeybindButton_KeyUp(object sender, KeyEventArgs e)
        {
            //ignore if only modifier pressed or no modifiers pressed
            Keys key = e.KeyCode;
            if (!(key == Keys.ControlKey || key == Keys.Menu || key == Keys.ShiftKey) && e.Modifiers!=0 )
            {
                uint modKeysValue = 0;
                if (e.Control)
                    modKeysValue += 2;
                if (e.Alt)
                    modKeysValue += 1;
                if (e.Shift)
                    modKeysValue += 4;

                if (hotKeyItem.SetKeybind((ModKeys)modKeysValue, key))
                    SetKeybindText(hotKeyItem);
                else
                    keybindButton.Text = "Not Bound";
            }

            //remove focus from keybind button so as not to capture/override keybind just set
            Parent.Focus();
        }

        private void KeybindButton_Enter(object sender, EventArgs e)
        {
            ActionBank.RespondToInput = false;
        }

        private void KeybindButton_Leave(object sender, EventArgs e)
        {
            ActionBank.RespondToInput = true;
        }
    }
}
