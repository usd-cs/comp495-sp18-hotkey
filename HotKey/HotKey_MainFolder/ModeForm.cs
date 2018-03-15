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
        List<HotKeyItem> hotKeyItemList = new List<HotKeyItem> { new HotKeyItem("Copy"), new HotKeyItem("Paste"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test"), new HotKeyItem("Test") };

        public ModeForm()
        {
            InitializeComponent();

            //TODO probably won't be calling Init here, but from Form that creates ModeForm
            Init("Testing Mode");
        }

        public void Init(string modeName)
        {
            InitializeHotKeyControls();

            modeLabel.Text = modeName;
        }

        private void InitializeHotKeyControls()
        {
            foreach (HotKeyItem hotKeyItem in hotKeyItemList)
            {
                hotKeyItemPanel.Controls.Add(new HotKeyControl(hotKeyItemList, hotKeyItem));
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddHotKeyButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
