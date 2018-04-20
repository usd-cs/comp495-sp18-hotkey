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
        static bool respondToInput = true;

        static string clipboardOne, clipboardTwo, clipboardThree;

        public static void Copy()
        {
            if (respondToInput)
                SendKeys.Send("^c");
        }

        public static void Paste()
        {
            if (respondToInput)
                SendKeys.Send("^v");
        }

        public static void AppendToClipboard()
        {
            if (respondToInput)
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

        public static bool RespondToInput { get { return respondToInput; } set { respondToInput = value; } }
    }
}
