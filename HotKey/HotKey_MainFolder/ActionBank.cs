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

        static List<Tuple<string, object>> clipboardList = new List<Tuple<string, object>>(),
            clipboardOneList = new List<Tuple<string, object>>(),
            clipboardTwoList = new List<Tuple<string, object>>();


        private static void Copy(int index)
        {
            if (respondToInput)
            {
                List<Tuple<string, object>> list = GetCorrectClipboard(index);

                list.Clear();

                SendKeys.Send("^c");
                CaptureClipboard(index);
            }
        }
        public static void CopyPrimary()
        {
            Copy(0);
        }
        public static void CopyOne()
        {
            Copy(1);
        }
        public static void CopyTwo()
        {
            Copy(2);
        }

        private static void Paste(int index)
        {
            if (respondToInput)
            {
                List<Tuple<string, object>> list = GetCorrectClipboard(index);

                foreach (Tuple<string, object> clipboardItem in list)
                {
                    Clipboard.SetData(clipboardItem.Item1, clipboardItem.Item2);
                    SendKeys.Send("^v");
                }
            }
        }
        public static void PastePrimary()
        {
            Paste(0);
        }
        public static void PasteOne()
        {
            Paste(1);
        }
        public static void PasteTwo()
        {
            Paste(2);
        }

        private static void AppendToClipboard(int index)
        {
            if (respondToInput)
            {
                SendKeys.Send("^c");
                CaptureClipboard(index);
            }
        }
        public static void AppendToClipboardPrimary()
        {
            AppendToClipboard(0);
        }
        public static void AppendToClipboardOne()
        {
            AppendToClipboard(1);
        }
        public static void AppendToClipboardTwo()
        {
            AppendToClipboard(2);
        }

        private static void CaptureClipboard(int index)
        {
            List<Tuple<string, object>> list = GetCorrectClipboard(index);

            if (Clipboard.ContainsText())
            {
                list.Add(Tuple.Create(DataFormats.Text, (object)Clipboard.GetText()));
            }
            else if (Clipboard.ContainsImage())
            {
                list.Add(Tuple.Create(DataFormats.Bitmap, (object)Clipboard.GetImage()));
            }
            else if (Clipboard.ContainsAudio())
            {
                list.Add(Tuple.Create(DataFormats.WaveAudio, (object)Clipboard.GetAudioStream()));
            }
            else if (Clipboard.ContainsFileDropList())
            {
                list.Add(Tuple.Create(DataFormats.FileDrop, (object)Clipboard.GetFileDropList()));
            }
        }

        private static ref List<Tuple<string, object>> GetCorrectClipboard(int index)
        {
            switch (index)
            {
                case 0:
                    return ref clipboardList;
                case 1:
                    return ref clipboardOneList;
                case 2:
                    return ref clipboardTwoList;
                default:
                    return ref clipboardList;
            }
        }

        public static bool RespondToInput { get { return respondToInput; } set { respondToInput = value; } }
    }
}
