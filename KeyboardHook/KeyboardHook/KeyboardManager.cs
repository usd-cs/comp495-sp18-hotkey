using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardHook
{
    public class KeyboardManager
    {
        public const int INPUT_KEYBOARD = 1;
        public const int KEYEVENTF_KEYUP = 0x0002;

        public struct KEYDBINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public Int32 dwExtraInfo;
            public Int32 __filler1;
            public Int32 __filler2;
        }

        public struct INPUT
        {
            public Int32 type;
            public KEYDBINPUT ki;
        }

        //This is what overrides the OS and sends out input instead
        [DllImport("user32")]
        public static extern int SendInput(int cInputs, ref INPUT pInputs, int cbSize);
        //This is used for if someone holds down the 'a' button it will repeatedly run until the press up
        public static void HoldKey(Keys vk)
        {
            //This takes some reading
            //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646270(v=vs.85).aspx
            //Basically the glag setup is saying
            //Get from the keyboard input
            //ki = Keyboard input
            //dwflag = what the key is doing 0 is the default which we need to refresh each time so it = 0
            //wVk = the keyboard input value (something from 1-254)
            //Then we send all this info along
            INPUT input = new INPUT();
            input.type = INPUT_KEYBOARD;
            input.ki.dwFlags = 0;
            input.ki.wVk = (Int16)vk;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void ReleaseKey(Keys vk)
        {
            //Similar to the above function, big difference in the dwFlag is for keyboard up which means
            //The input is over send last signal
            INPUT input = new INPUT();
            input.type = INPUT_KEYBOARD;
            input.ki.dwFlags = KEYEVENTF_KEYUP;
            input.ki.wVk = (Int16)vk;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void PressKey(Keys vk)
        {
            //This will stay in holdkey until it is over
            HoldKey(vk);
            ReleaseKey(vk);
        }
    }
}