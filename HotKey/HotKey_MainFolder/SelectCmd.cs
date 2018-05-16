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
    public partial class SelectCmd : Form
    {
        public SelectCmd()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        public string returnVal { get; set; }
        public string returnVal2 { get; set; }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(comboBox1.Text);
            this.returnVal = comboBox1.Text;
            if (returnVal.Contains("Specified"))
            {
                textBox1.ReadOnly = false;
                
            }
            else
            {
                textBox1.ReadOnly = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnVal2 = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
