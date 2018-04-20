using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey_MainFolder
{
    public class KeybindHook
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        int modifiers;
        int key;
        IntPtr hWnd;
        int id;

        public KeybindHook(IntPtr formHandle)
        {
            hWnd = formHandle;
        }

        public void SetKeybind(ModKeys modifiers, Keys key)
        {
            this.modifiers = (int)modifiers;
            this.key = (int)key;

            id = GetHashCode();
        }

        public override int GetHashCode()
        {
            //unique id of Hot Key
            return modifiers ^ key ^ hWnd.ToInt32();
        }

        public bool RegisterKeybind()
        {
            return RegisterHotKey(hWnd, id, modifiers, key);
        }

        public bool UnregisterKeybind()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
