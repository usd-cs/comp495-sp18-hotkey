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
        private Dictionary<Tuple<ModKeys, Keys>, Action> keybindActionDictionary = new Dictionary<Tuple<ModKeys, Keys>, Action>();
        private List<HotKeyItem> hotKeyItemList = new List<HotKeyItem>();
        public bool ourKeys = false;
        public ModeForm(MainForm mainForm, string modeName)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            modeLabel.Text = modeName;

            InitializeHotKeyItems();
            InitializeHotKeyControls();
        }

        protected override void WndProc(ref Message m)
        {


            //if hot key message
            if (m.Msg == 0x0312 && m.WParam.ToInt32() != -1 && m.WParam.ToInt32() != -2)
            {

                keybindActionDictionary[Tuple.Create((ModKeys)(m.LParam.ToInt32() & 0xFFFF), (Keys)(m.LParam.ToInt32() >> 16))]?.Invoke();

                //TODO should run base or return here (would this stop OS from executing Hot Key?)
            }

            base.WndProc(ref m);
        }

        private void InitializeHotKeyItems()
        {
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.Define, "Define Search", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.RandomYouTube, "Random YouTube", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.CommandBoot, "Command Prompt", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.Screenshot, "Screenshot", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.AmazonSearch, "Amazon Search", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.TaskMngr, "Task Manager", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.Calculator, "Calculate", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.CloseCurrentProcess, "Close Focused Window", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.HighlightSearch, "Highlight Search", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.YouTubeSearch, "YouTube Search", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.OpenClosedTab, "Open Last Closed Tab", ModKeys.None, Keys.None));
            //stuff above is new
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.CopyPrimary, "Copy Primary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.PastePrimary, "Paste Primary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.AppendToClipboardPrimary, "Append to Primary Clipboard", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.CopyOne, "Copy Secondary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.PasteOne, "Paste Secondary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.AppendToClipboardOne, "Append to Secondary Clipboard", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.CopyTwo, "Copy Tertiary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.PasteTwo, "Paste Tertiary", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.AppendToClipboardTwo, "Append to Tertiary Clipboard", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.OpenToDirectory, "Open To File Directory", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.OpenSpecifiedWebPage, "Open StackOverFlow", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.ClipboardSearch, "Search Current Clipboard", ModKeys.None, Keys.None));
            hotKeyItemList.Add(new HotKeyItem(Handle, keybindActionDictionary, ActionBank.SetVolume, "Set Volume", ModKeys.None, Keys.None));

        }

        private void InitializeHotKeyControls()
        {
            foreach (HotKeyItem hotKeyItem in hotKeyItemList)
            {
                hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItem));
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            mainForm.Location = Location;

            Close();
        }

        private void AddHotKeyButton_Click(object sender, EventArgs e)
        {
            HotKeyItem hotKeyItem = new HotKeyItem(Handle, keybindActionDictionary, null, "Test (No Action)", ModKeys.None, Keys.None);
            hotKeyItemList.Add(hotKeyItem);
            hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItem));
        }


        private void ModeForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
