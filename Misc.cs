using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace WinNotepad
{
    enum ReplaceState
    {
        Find,
        Replace,
        ReplaceAll
    }

    enum EncodingTypeWhenOpen
    {
        Auto,
        ANSI,
        Unicode,
        [Description("UTF-8")] UTF8
    }

    enum EncodingTypeWhenSave
    {
        ANSI,
        Unicode,
        [Description("UTF-8")] UTF8
    }
    static class Misc
    {
        public static int currFoundKeyWordPos = -1;
        public static string searchKeyWord = string.Empty;
        public static string replaceWord = string.Empty;
        public static string oldContent = string.Empty;
        public static int lineCount = 1;
        public static RichTextBoxFinds currFindOption = RichTextBoxFinds.None;
        public static bool cycleFind = false;
        public static ReplaceState currReplaceState = ReplaceState.Find;
        public static bool speciallUndo = false;
        public static int scaleFactor = 0;
        public static int selectEncodingIndex = 0;
        public static int charsetIndex = 0;

        public static void SetRegisterKV<T>(string key, T value)
        {
            RegistryKey regKey = Registry.CurrentConfig;
            RegistryKey software = regKey.CreateSubKey("Software\\WinNotePad");
            if (value is string)
            {
                software.SetValue(key, value, RegistryValueKind.String);
            }
            else
            {
                software.SetValue(key, value, RegistryValueKind.DWord);
            }
            regKey.Close();
        }

        public static void SetRegisterFromStream(string key,MemoryStream ms)
        {
            RegistryKey regKey = Registry.CurrentConfig;
            RegistryKey software = regKey.CreateSubKey("Software\\WinNotePad");
            software.SetValue(key, ms.GetBuffer(), RegistryValueKind.Binary);
        }

        public static MemoryStream GetRegisterToStream(string key)
        {
            RegistryKey regKey = Registry.CurrentConfig;
            regKey = regKey.OpenSubKey("Software\\WinNotePad");
            object valObj = regKey.GetValue(key);
           
            MemoryStream ms = new MemoryStream(valObj as byte[]);
            return ms;
        }

        public static object GetRegisterValue(string key)
        {
            RegistryKey regKey = Registry.CurrentConfig;
            regKey = regKey.OpenSubKey("Software\\WinNotePad");
            object v = regKey.GetValue(key);
            regKey.Close();
            return v;
        }

        public static Font GetFontFromRegister()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            MemoryStream ms = GetRegisterToStream("FontData");
            object dsObj = binFormat.Deserialize(ms);
            Font ft = dsObj as Font;
            return ft;
        }

        //设置新打开窗体的显示位置
        public static Point GetFormShowPosition(Form parentForm, Form childFormForm)
        {
            int locX = parentForm.Location.X + parentForm.Width / 8;
            int locY = parentForm.Location.Y + parentForm.Height / 2;
            //防止窗体位置超出屏幕边界
            if (locX >= (Screen.GetBounds(parentForm.Location).Right - childFormForm.Width))
            {
                locX = (Screen.PrimaryScreen.Bounds.Right - childFormForm.Width) - 10;
            }
            else if (locX <= Screen.GetBounds(parentForm.Location).Left)
            {
                locX = Screen.PrimaryScreen.Bounds.Left + 10;
            }
            if (locY >= (Screen.GetWorkingArea(parentForm.Location).Bottom - childFormForm.Height))
            {
                locY = Screen.GetWorkingArea(parentForm.Location).Bottom - childFormForm.Height - 10;
            }
            return new Point(locX, locY);
        }

        public static string GetFileAttrName()
        {
            if ((ContentManager.Instance.currFileAttr & System.IO.FileAttributes.ReadOnly) != 0)
            {
                return "只读文件";
            }
            else if ((ContentManager.Instance.currFileAttr & System.IO.FileAttributes.Hidden) != 0)
            {
                return "隐藏文件";
            }
            else if ((ContentManager.Instance.currFileAttr & System.IO.FileAttributes.System) != 0)
            {
                return "系统文件";
            }
            else
            {
                return "普通文件";
            }
        }
        
    }
}
