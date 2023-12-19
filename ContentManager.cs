using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNotepad
{
    public class ContentManager
    {
        private static ContentManager _instance;

        public static ContentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContentManager();
                }
                return _instance;
            }
        }

        public ContentManager()
        {
            SetNewFile();
        }

        public bool isNewFile;
        public bool hasEdit;
        public bool hasSave;
        public int caretPosition;
        public string fileName;
        public string filePath;
        public Encoding currCodeType;
        public FileAccess currFileAccess = FileAccess.ReadWrite;
        public FileAttributes currFileAttr = 0;

        public void SetNewFile()
        {
            isNewFile = true;
            hasEdit = false;
            hasSave = false;
            //allContent = string.Empty;
            //histroyContent = string.Empty;
            fileName = "无标题";
            filePath = string.Empty;
            currCodeType = Encoding.UTF8;
            currFileAttr = 0;
            currFileAccess = FileAccess.ReadWrite;
            caretPosition = 0;
        }
        /// <summary>
        /// 获取文件的编码格式
        /// </summary>
        public Encoding GetEncoding(string file_name)
        {
            FileStream fs = new FileStream(file_name, FileMode.Open, FileAccess.Read);
            Encoding r = GetEncoding(fs);
            fs.Close();
            return r;
        }

        /// <summary>
        /// 通过给定的文件流，判断文件的编码类型
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
        public Encoding GetEncoding(FileStream fs)
        {
            //文件的字符集在Windows下有两种，一种是ANSI，一种Unicode。
            //对于Unicode，Windows支持了它的三种编码方式，一种是小尾编码（Unicode)，一种是大尾编码(BigEndianUnicode)，一种是UTF - 8编码。
            //byte[] Unicode = new byte[] { 0xFF, 0xFE };
            //byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF };
            //byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //BOM头

            if (fs.Length < 3)
                return Encoding.Default;

            byte[] bytes = new byte[3];
            fs.Read(bytes, 0, 3);

            Encoding reVal = Encoding.GetEncoding("GB2312");

            if (bytes[0] == 0xFE && bytes[1] == 0xFF)
            {
                reVal = Encoding.BigEndianUnicode;
            }
            else if (bytes[0] == 0xFF && bytes[1] == 0xFE)
            {
                reVal = Encoding.Unicode;
            }
            else
            {
                if (!(bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF))
                {
                    fs.Position = 0;
                }
                if (IsUTF8Bytes(fs))
                {
                    if (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                        reVal = new UTF8Encoding(false);
                    else
                        reVal = Encoding.UTF8;
                }
            }
            fs.Position = 0;
            return reVal;
        }

        private static byte UTF8_BYTE_MASK = 0b1100_0000;
        private static byte UTF8_BYTE_VALID = 0b1000_0000;
        private bool IsUTF8Bytes(FileStream fs)
        {
            //BinaryReader r = new BinaryReader(fs);
            byte[] bytes = new byte[1];
            fs.Read(bytes, 0, 1);

            //1字节 0xxxxxxx
            //2字节 110xxxxx 10xxxxxx
            //3字节 1110xxxx 10xxxxxx 10xxxxxx
            //4字节 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
            //5字节 111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
            //6字节 1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx
            while (fs.Read(bytes, 0, 1) > 0)
            {
                if (bytes[0] < 0x80)
                    continue;

                int cnt = 0;
                byte b = bytes[0];
                while ((b & 0b1000_0000) != 0)
                {
                    cnt++;
                    b <<= 1;
                }
                cnt -= 1;

                for (int i = 0; i < cnt; i++)
                {
                    if (fs.Read(bytes, 0, 1) <= 0)
                        return false;
                    if ((bytes[0] & UTF8_BYTE_MASK) != UTF8_BYTE_VALID)
                        return false;
                }
            }

            return true;
        }

        public string ReadFile(string filePath)
        {
            byte[] buffer;
            StringBuilder contentBuilder = new StringBuilder();
            currFileAttr = File.GetAttributes(filePath);
            //如果文件有只读属性 打开文件的权限就只有读 不能写
            if ((currFileAttr & FileAttributes.ReadOnly) != 0)
            {
                currFileAccess = FileAccess.Read;
            }
            else
            {
                currFileAccess = FileAccess.ReadWrite;
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open, currFileAccess))
            {
                int bytesRead = 0;
                switch ((EncodingTypeWhenOpen)Misc.selectEncodingIndex)
                {
                    case EncodingTypeWhenOpen.Auto:
                        currCodeType = GetEncoding(fs);
                        
                        if (currCodeType.EncodingName == Encoding.Default.EncodingName)
                        {
                            Misc.selectEncodingIndex = (int)EncodingTypeWhenSave.ANSI;
                        }
                        else if (currCodeType.EncodingName == Encoding.UTF8.EncodingName)
                        {
                            Misc.selectEncodingIndex = (int)EncodingTypeWhenSave.UTF8;
                        }
                        else
                        {
                            Misc.selectEncodingIndex = (int)EncodingTypeWhenSave.Unicode;
                        }
                        break;
                    case EncodingTypeWhenOpen.ANSI:
                        currCodeType = Encoding.Default;
                        break;
                    case EncodingTypeWhenOpen.Unicode:
                        currCodeType = Encoding.Unicode;
                        break;
                    case EncodingTypeWhenOpen.UTF8:
                        currCodeType = Encoding.UTF8;
                        break;
                    default:
                        break;
                }
                //从文件中读取数据，返回读取的字节数
                while (true)
                {
                    buffer = new byte[1024];
                    bytesRead = fs.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    else
                    {
                        contentBuilder.Append(currCodeType.GetString(buffer, 0, bytesRead));
                    }
                }
                contentBuilder.Replace('\0', (char)0x20);
            }
            isNewFile = true;
            hasEdit = false;
            hasSave = true;
            return contentBuilder.ToString();
        }

        public void SetFileName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                this.fileName = fileName;
            }
        }

        public void SetFilePath(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                this.filePath = filePath;
            }
        }

        public void SaveFile(string path, string content)
        {
            ToSave(path, content);
        }

        public void SaveFileContinue(string content)
        {
            ToSave(this.filePath, content);
        }

        private void ToSave(string path, string content)
        {
            if (content == null)
                return;
            bool hasHiddenAttr = false;
            FileInfo info = null;
            if (File.Exists(path))
            {
                info = new FileInfo(path);
                //如果文件有隐藏属性 先把隐藏属性去掉才能写
                if (info.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    info.Attributes &= ~FileAttributes.Hidden;
                    hasHiddenAttr = true;
                }
            }
            try
            {
                switch ((EncodingTypeWhenSave)Misc.selectEncodingIndex)
                {
                    case EncodingTypeWhenSave.ANSI:
                        currCodeType = Encoding.Default;
                        break;
                    case EncodingTypeWhenSave.Unicode:
                        currCodeType = Encoding.Unicode;
                        break;
                    case EncodingTypeWhenSave.UTF8:
                        currCodeType = Encoding.UTF8;
                        break;
                    default:
                        break;
                }
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = currCodeType.GetBytes(content);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //记得最后把隐藏属性加回去
                if (info != null && hasHiddenAttr)
                {
                    info.Attributes |= FileAttributes.Hidden;
                }
            }
            hasSave = true;
        }
    }
}
