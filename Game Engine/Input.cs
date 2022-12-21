using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sodium
{
    public class Input
    {
        public static bool GetKey(Key key)
        {
            bool isDown = Keyboard.IsKeyDown(key);
            return isDown;
        }
        public static bool GetKeyUp(Key key)
        {
            bool isUp = Keyboard.IsKeyUp(key);
            return isUp;
        }
    }
}
