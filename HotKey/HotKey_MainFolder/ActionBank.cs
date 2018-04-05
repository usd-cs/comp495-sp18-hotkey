using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey_MainFolder
{
    public static class ActionBank
    {
        public static void Copy()
        {
            SendKeys.Send("^c");
        }

        public static void Paste()
        {
            SendKeys.Send("^v");
        }

        public static void AppendToClipboard()
        {
            //NOTE: currently only works if appending text to text
            string existingText = string.Empty;
            if (Clipboard.ContainsText())
            {
                existingText = Clipboard.GetText();
            }
            SendKeys.Send("^c");
            if (Clipboard.ContainsText())
            {
                Clipboard.SetData(DataFormats.Text, string.Format("{0}{1}", existingText, Clipboard.GetText()));
            }
        }
    }
}
