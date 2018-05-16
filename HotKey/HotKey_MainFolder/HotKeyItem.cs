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
        private Dictionary<Tuple<ModKeys, Keys>, Action> keybindActionDictionary;
        private Action action;
        private string actionName;
        private ModKeys modKeys;
        private Keys key;
        public string cmd;
        private KeybindHook keybindHook;


        public HotKeyItem(string cmd, IntPtr formHandle, Dictionary<Tuple<ModKeys, Keys>, Action> keybindActionDictionary, Action action, string actionName, ModKeys modKeys, Keys key)
        {
            this.cmd = cmd;
            this.keybindActionDictionary = keybindActionDictionary;
            this.action = action;
            this.actionName = actionName;
            this.modKeys = modKeys;
            this.key = key;
            

            //create keybind hook and register keybind if it exists
            keybindHook = new KeybindHook(formHandle);
            RegisterKeybind();
        }

        public void UpdateKeybind(ModKeys modKeys, Keys key)
        {
            UnregisterKeybind();

            this.modKeys = modKeys;
            this.key = key;
            RegisterKeybind();
        }

        private void UnregisterKeybind()
        {
            if (key != Keys.None)
            {
                keybindActionDictionary.Remove(Tuple.Create(modKeys, key));
                keybindHook.UnregisterKeybind();
            }
        }

        private void RegisterKeybind()
        {
            if (key != Keys.None)
            {
                //try to register keybind, add to dictionary if successful, else set keys to none
                keybindHook.SetKeybind(modKeys, key);
                if (keybindHook.RegisterKeybind())
                    keybindActionDictionary.Add(Tuple.Create(modKeys, key), action);
                else
                {
                    modKeys = ModKeys.None;
                    key = Keys.None;
                }
            }
        }

        public Action Action
        {
            set
            {
                //updated dictionary entry if it exists
                if (keybindActionDictionary.ContainsKey(Tuple.Create(modKeys, key)))
                    keybindActionDictionary[Tuple.Create(modKeys, key)] = action;
            }
        }

        //getters used by HotKeyControl
        public string ActionName { get => actionName; }
        public ModKeys ModKeys { get => modKeys; }
        public Keys Key { get => key; }
    }
}
