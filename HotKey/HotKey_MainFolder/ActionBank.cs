using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace HotKey_MainFolder
{
    
    public static class ActionBank
    {
        static bool respondToInput = true;

        static string clipboardOne, clipboardTwo, clipboardThree;

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_APPCOMMAND = 0x319;
        private const int WM_GETTEXT = 0x000D;
        private const int WM_GETTEXTLENGTH = 0x000E;
        


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr lparam, IntPtr wparam);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string lpString);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)] 
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

      

        public static void Copy()
        {

            ModeForm.USER_ENTRY_CATCH = false;
            if (respondToInput)
                SendKeys.Send("^c");

        }

        public static void Paste()
        {
            ModeForm.USER_ENTRY_CATCH = false;
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

        public static void OpenToDirectory()
        {
            string filePath = Path.GetFullPath(@Clipboard.GetText());
            
            Console.WriteLine(filePath);
            if (!Directory.Exists(filePath))
            {
                filePath = Path.GetDirectoryName(Clipboard.GetText());
                if (!Directory.Exists(filePath))
                {
                    Console.WriteLine("this is not a directory bruh");
                    return;
                }
            }

            // combine the arguments together
            // it doesn't matter if there is a space after ','
            string argument = "/select, \"" + filePath + "\"";
            Console.WriteLine(argument);
            Process.Start(@filePath);

        }

        public static void OpenSpecifiedWebPage()
        {
            Process p = null;
            try
            {
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.stackoverflow.com");
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void ClipboardSearch()
        {
            Process p = null;
            try
            {
                string search = Clipboard.GetText();
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                search = search.Replace(" ", "%20");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.google.com/search?q=" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Going to need a lot more time on this one
        public static void SetVolume()
        {
            for(int i = 0; i < 50; i ++)
                SendMessageW(GetForegroundWindow(), WM_APPCOMMAND,IntPtr.Zero,(IntPtr)APPCOMMAND_VOLUME_DOWN);
            for(int i = 0; i < 10;  i++)
                SendMessageW(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_UP);
        }



        public static bool RespondToInput { get { return respondToInput; } set { respondToInput = value; } }

        
    }
}
