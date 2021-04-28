using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;


public static class KeyConverter
{
    #region solution one
    /*
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int ToUnicode(
uint virtualKeyCode,
uint scanCode,
byte[] keyboardState,
StringBuilder receivingBuffer,
int bufferSize,
uint flags
);




    public static string GetCharsFromKeys(Key keys, bool shift)
    {
        var buf = new StringBuilder(256);
        var keyboardState = new byte[256];
        if (shift)
        {
            keyboardState[(int)Key.LeftShift] = 0xff;
        }
        ToUnicode((uint)keys, 0, keyboardState, buf, 256, 0);
        return buf.ToString();
    }
    */
    #endregion


    #region solution two
    [DllImport("user32.dll")] static extern bool GetKeyboardState(byte[] lpKeyState);

    [DllImport("user32.dll")] static extern uint MapVirtualKey(uint uCode, uint uMapType);

    [DllImport("user32.dll")] static extern IntPtr GetKeyboardLayout(uint idThread);

    [DllImport("user32.dll")] static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);


    public static string KeyCodeToUnicode(Keys key)
    {
        byte[] keyboardState = new byte[255];
        bool keyboardStateStatus = GetKeyboardState(keyboardState);

        if (!keyboardStateStatus)
        {
            return String.Empty;
        }

        uint virtualKeyCode = (uint)key;
        uint scanCode = MapVirtualKey(virtualKeyCode, 0);
        IntPtr inputLocaleIdentifier = GetKeyboardLayout(0);

        StringBuilder result = new StringBuilder();
        ToUnicodeEx(virtualKeyCode, scanCode, keyboardState, result, (int)5, (uint)0, inputLocaleIdentifier);

        return result.ToString();
    }

    #endregion


    #region dumb switch extension
    public static string GetChar(this Key e)
    {
        string name;
        switch (e)
        {
            case Key.OemComma:
                name = ",";
                break;
            case Key.OemPeriod:
                name = ".";
                break;

            case Key.OemMinus:
                name = "-";
                break;
            case Key.D2:
                name = "@";


                break;
            default:
                name = (new KeysConverter()).ConvertToString(e);
                break;


        }
        return name;


    }

    #endregion
}
