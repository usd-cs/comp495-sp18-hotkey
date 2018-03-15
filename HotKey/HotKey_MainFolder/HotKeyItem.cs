using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey_MainFolder
{
    public class HotKeyItem
    {
        private string actionName;
        private ModKeys modKeys;
        private Keys keys;

        public HotKeyItem() { }

        public HotKeyItem(string actionName, ModKeys modKeys, Keys keys)
        {
            this.actionName = actionName;
            this.modKeys = modKeys;
            this.keys = keys;
        }

        public HotKeyItem(string actionName)
        {
            this.actionName = actionName;
        }

        public string ActionName { get => actionName; set => actionName = value; }
        public ModKeys ModKeys { get => modKeys; set => modKeys = value; }
        public Keys Keys { get => keys; set => keys = value; }
    }
}
