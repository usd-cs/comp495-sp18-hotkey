using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotKey_MainFolder
{
    [Flags]
    public enum ModKeys : uint { None = 0, Alt = 1, Control = 2, Shift = 4 }
}
