using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey_MainFolder
{
    public partial class ModeForm : Form
    {
        //TODO see if can data bind hot key item list to panel controls
        private MainForm mainForm;
        private Dictionary<Tuple<ModKeys, Keys>, Action> modeFormKeybindDictionary = new Dictionary<Tuple<ModKeys, Keys>, Action>();
        private List<HotKeyItem> hotKeyItemList = new List<HotKeyItem>();
        private KeyboardHook hook = new KeyboardHook();

        public ModeForm(MainForm mainForm, string modeName)
        {
            InitializeComponent();

            hook.KeyPressed += new EventHandler<CustomHotKeyEvent>(Hook_OnKeybindPressed);

            this.mainForm = mainForm;
            modeLabel.Text = modeName;

            InitializeHotKeyItems();
            InitializeHotKeyControls();
        }

        private void Hook_OnKeybindPressed(object sender, CustomHotKeyEvent e)
        {
            //execute action from dictioanry
            //TODO can remove try/catch when UnregisterHotKey implemented
            try
            {
                modeFormKeybindDictionary[Tuple.Create(e.Modifier, e.Key)].Invoke();
            }
            catch (KeyNotFoundException) { }
        }

        private void InitializeHotKeyControls()
        {
            foreach (HotKeyItem hotKeyItem in hotKeyItemList)
            {
                hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItem));
            }
        }

        private void InitializeHotKeyItems()
        {
            hotKeyItemList.Add(new HotKeyItem(hook, modeFormKeybindDictionary, ActionBank.Copy, "Copy"));
            hotKeyItemList.Add(new HotKeyItem(hook, modeFormKeybindDictionary, ActionBank.Paste, "Paste"));
            hotKeyItemList.Add(new HotKeyItem(hook, modeFormKeybindDictionary, ActionBank.AppendToClipboard, "Append to Clipboard"));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            mainForm.Location = Location;

            Close();
        }

        private void AddHotKeyButton_Click(object sender, EventArgs e)
        {
            HotKeyItem hotKeyItem = new HotKeyItem(hook, modeFormKeybindDictionary, null, "Test (No Action)");
            hotKeyItemList.Add(hotKeyItem);
            hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItem));
        }
    }
}
