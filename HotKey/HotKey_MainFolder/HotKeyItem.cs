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
        private KeyboardHook hook;
        private Dictionary<Tuple<ModKeys, Keys>, Action> modeFormKeybindDictionary;
        private Action action;
        private string actionName;
        private ModKeys modKeys;
        private Keys key;

        public HotKeyItem(KeyboardHook hook, Dictionary<Tuple<ModKeys, Keys>, Action> modeFormKeybindDictionary, Action action, string actionName, ModKeys modKeys, Keys key)
        {
            this.hook = hook;
            this.modeFormKeybindDictionary = modeFormKeybindDictionary;
            this.action = action;
            this.actionName = actionName;
            this.modKeys = modKeys;
            this.key = key;

            RegisterKeybind(true);
        }

        public HotKeyItem(KeyboardHook hook, Dictionary<Tuple<ModKeys, Keys>, Action> modeFormKeybindDictionary, Action action, string actionName)
        {
            this.hook = hook;
            this.modeFormKeybindDictionary = modeFormKeybindDictionary;
            this.action = action;
            this.actionName = actionName;

            //keybind not set, so no registering
        }

        public bool SetKeybind(ModKeys modKeys, Keys key)
        {
            UnregisterKeybind(true);

            this.modKeys = modKeys;
            this.key = key;

            bool successful = RegisterKeybind(true);
            if (!successful)
            {
                this.modKeys = ModKeys.None;
                this.key = Keys.None;
            }
            return successful;
        }

        //Field vars will contain old values when this is called
        private void UnregisterKeybind(bool unregisterHook)
        {
            if (action != null)
            {
                //remove previous keybind from dictionary
                modeFormKeybindDictionary.Remove(Tuple.Create(modKeys, key));
                if (unregisterHook) ;
                //TODO unregister keybind from hook
            }
        }

        //Field vars will contain updated values when this is called
        private bool RegisterKeybind(bool registerHook)
        {
            if (action != null)
            {
                //add keybind to dictionary
                modeFormKeybindDictionary[Tuple.Create(modKeys, key)] = action;
                if (registerHook)
                {
                    //register hot key with hook
                    try
                    {
                        hook.RegisterHotKey(modKeys, key);
                    }
                    catch (InvalidOperationException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Action Action
        {
            set
            {
                //if action updated, remove old dictionary entry and add updated dictionary entry
                UnregisterKeybind(false);
                action = value;
                RegisterKeybind(false);
            }
        }
        public string ActionName { get => actionName; }
        public ModKeys ModKeys { get => modKeys; }
        public Keys Key { get => key; }
    }
}
