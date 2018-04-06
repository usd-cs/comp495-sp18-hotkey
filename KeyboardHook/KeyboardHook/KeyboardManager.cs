﻿using System;
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

        [DllImport("user32")]
        public static extern int SendInput(int cInputs, ref INPUT pInputs, int cbSize);

        public static void HoldKey(Keys vk)
        {
            INPUT input = new INPUT();
            input.type = INPUT_KEYBOARD;
            input.ki.dwFlags = 0;
            input.ki.wVk = (Int16)vk;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void ReleaseKey(Keys vk)
        {
            INPUT input = new INPUT();
            input.type = INPUT_KEYBOARD;
            input.ki.dwFlags = KEYEVENTF_KEYUP;
            input.ki.wVk = (Int16)vk;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void PressKey(Keys vk)
        {
            HoldKey(vk);
            ReleaseKey(vk);
        }
    }
}