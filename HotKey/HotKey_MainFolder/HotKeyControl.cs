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
    public partial class HotKeyControl : UserControl
    {
        public HotKeyControl()
        {
            InitializeComponent();
        }

        public HotKeyControl(List<HotKeyItem> hotKeyItemList, HotKeyItem hotKeyItem)
        {
            //TODO the global Map/Dict should be passed in or be accessible so we can add new binds. Also the delegate/method corresponding to the action should be passed in.
            InitializeComponent();

            actionLabel.Text = hotKeyItem.ActionName;

            if (hotKeyItem.Keys == Keys.None)
                keybindButton.Text = "Not bound";
            else
                keybindButton.Text = string.Format("{0}+{1}", hotKeyItem.ModKeys, hotKeyItem.Keys).Replace(" ","").Replace(",","+");
        }

        private void KeybindButton_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO Here we want to register the hotkey and add a new HotKeyItem to the list for current form. I think we should also add to a Map/Dict that has the keybind (modkeys+keys -> action delegate) map to a action so that our hook can easily run the desired delegate/method

            //ignore if the primary key code is a modifier
            if (!(e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ShiftKey))
            {
                //TODO instead of using KeyData, check for modifiers with bit operations and add KeyCode at the end of the modifiers, this will also make it easy to construct HotKeyItem and add to Map/Dict
                keybindButton.Text = e.KeyData.ToString().Replace(" ", "").Replace(",", "+");
            }

            //remove focus from keybind button so as not to capture/override keybind just set
            Parent.Focus();
        }
    }
}
