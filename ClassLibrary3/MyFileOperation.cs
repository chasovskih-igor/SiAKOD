using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class MyFileOperation
    {


        public static void WriteInFile(string path, string[] arr)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (string el in arr)
            {
                sw.WriteLine(el);
            }

            sw.Close();
        }
        public static string[] ReadFromFileInArray(string path)
        {
            return ReadFromFile(path).Split();
        }

        public static void WriteInFile(string path, string el)
        {
            WriteInFile(path, new string[] { el, });
        }

        public static string ReadFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string t = sr.ReadToEnd();
            sr.Close();
            return t;
        }
    }
}
