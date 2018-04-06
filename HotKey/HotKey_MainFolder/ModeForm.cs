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
            modeFormKeybindDictionary[Tuple.Create(e.Modifier, e.Key)].Invoke();
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
            hotKeyItemList.Add(new HotKeyItem(hook, modeFormKeybindDictionary, Action_Copy, "Copy"));
            hotKeyItemList.Add(new HotKeyItem(hook, modeFormKeybindDictionary, Action_Paste, "Paste"));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            mainForm.Location = Location;

            Close();
        }

        private void AddHotKeyButton_Click(object sender, EventArgs e)
        {
            HotKeyItem hotKeyItem = new HotKeyItem(hook, modeFormKeybindDictionary, null, "Test");
            hotKeyItemList.Add(hotKeyItem);
            hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItem));
        }

        private void Action_Copy()
        {
            SendKeys.Send("^c");
        }

        private void Action_Paste()
        {
            SendKeys.Send("^v");
        }
    }
}
