using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace HotKey_MainFolder
{

    public static class ActionBank
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetOpenClipboardWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);
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
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_APPCOMMAND = 0x319;
        private const int WM_GETTEXT = 0x000D;
        private const int WM_GETTEXTLENGTH = 0x000E;
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;

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

                ClaimClipboard();

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
                    ClaimClipboard();

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
                ClaimClipboard();

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
            ClaimClipboard();

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

        private static void ClaimClipboard()
        {
            //TODO should not keep trying infinetely
            while (GetOpenClipboardWindow() != IntPtr.Zero)
            {
                Thread.Sleep(100);
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
            for (int i = 0; i < 50; i++)
                SendMessageW(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            for (int i = 0; i < 10; i++)
                SendMessageW(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_UP);
        }


        public static void Define()
        {
            Process p = null;
            try
            {
                SendKeys.Send("^c");
                string search = Clipboard.GetText();
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                search = search.Replace(" ", "%20");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.google.com/search?q=define%20" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void HighlightSearch()
        {
            Process p = null;
            try
            {
                SendKeys.Send("^c");
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

        public static void OpenClosedTab()
        {
            SendKeys.Send("^+t");
        }

        public static void YouTubeSearch()
        {
            Process p = null;
            try
            {
                SendKeys.Send("^c");
                string search = Clipboard.GetText();
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                search = search.Replace(" ", "+");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.youtube.com/results?search_query=" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CloseCurrentProcess()
        {
            IntPtr a = GetForegroundWindow();

            Process[] pr = Process.GetProcesses();

            foreach (Process p in pr)
            {
                if (p.MainWindowHandle == a)
                {
                    p.CloseMainWindow();
                    p.Close();
                    break;
                }
            }

        }

        public static void TaskMngr()
        {
            Process p = new Process();
            p.StartInfo.FileName = "taskmgr";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        public static void Calculator()
        {
            Process p = null;
            try
            {
                SendKeys.Send("^c");
                string search = Clipboard.GetText();
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                search = search.Replace(" ", "%20");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.google.com/search?q=google%20calculator%20" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AmazonSearch()
        {
            Process p = null;
            try
            {
                SendKeys.Send("^c");
                string search = Clipboard.GetText();
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                //search = search.Replace(" ", "%20");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Screenshot()
        {
            SendKeys.Send("{PRTSC}");
        }


        public static void CommandBoot()
        {
            Process p = null;
            try
            {
                ProcessStartInfo si = new ProcessStartInfo("cmd.exe");
                si.WindowStyle = ProcessWindowStyle.Normal;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static Random random = new Random();
        public static void RandomYouTube()
        {

            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string search = "";
            for (int j = 0; j < 11; j++)
            {
                int i = random.Next(0, chars.Length);
                search += chars[i];
            }

            Process p = null;
            try
            {
                //Have to put %20 for all spaces for a chrome search... need to look into other browsers but this works for time being
                search = search.Replace(" ", "+");
                ProcessStartInfo si = new ProcessStartInfo("chrome.exe", "www.youtube.com/results?search_query=" + search);
                si.WindowStyle = ProcessWindowStyle.Maximized;
                p = Process.Start(si);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static bool RespondToInput { get { return respondToInput; } set { respondToInput = value; } }
    }


}
