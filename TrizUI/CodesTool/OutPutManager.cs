using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodesTool
{
    public class OutPutManager
    {
        public string DicName = "";
        public OutPutManager(string ObjName)
        {
            DicName = "f:\\" + System.DateTime.Now.ToString("yyyymmddhhmmss");
            Directory.CreateDirectory(DicName);
            Directory.CreateDirectory(DicName + "\\" + ObjName);
            Directory.CreateDirectory(DicName + "\\Controllers");
        }

        public void CreateCodeFile(string codes, string fileName)
        {
            FileStream fs1 = File.Create(@"" + DicName + "\\" + fileName);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(codes);//开始写入值
            sw.Close();
            fs1.Close();
        }

        public void CreateCodeFile(string codes, string subDirName, string fileName)
        {
            FileStream fs1 = File.Create(@"" + DicName + "\\"+ subDirName+"\\" + fileName);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(codes);//开始写入值
            sw.Close();
            fs1.Close();
        }
    }
}
