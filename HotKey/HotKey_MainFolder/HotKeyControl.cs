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
            SetKeybindText();
        }

        private void SetKeybindText()
        {
            if (hotKeyItem.Key == Keys.None)
                keybindButton.Text = "Not bound";
            else
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

                UpdateKeybind(key, (ModKeys) modKeysValue);
            }
            //undo/reset keybind if escape key pressed
            else if (key == Keys.Escape)
                UpdateKeybind(Keys.None, ModKeys.None);

            //remove focus from keybind button so as not to capture/override keybind just set
            Parent.Focus();
        }

        private void UpdateKeybind(Keys key, ModKeys modKeys)
        {
            hotKeyItem.UpdateKeybind(modKeys, key);
            SetKeybindText();
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
