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
    public partial class MainForm : Form
    {
        private Dictionary<Tuple<ModKeys, Keys>, Action> mainFormKeybindDictionary;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TestModeFormButton_Click(object sender, EventArgs e)
        {
            ModeForm modeForm = new ModeForm(this, "Test Mode");
            modeForm.Show();
            modeForm.Location = Location;

            Hide();
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void activeIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
