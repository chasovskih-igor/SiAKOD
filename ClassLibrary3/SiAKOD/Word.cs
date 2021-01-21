using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3.SiAKOD
{
    public class Word : IComparable
    {
        public string Stroka;

        public int Count;
        public Word(string stroka, int count)
        {
            Count = count;
            Stroka = stroka;
            Fix();
        }
        public override string ToString() => GetStringWithCount();
        public string GetStringWithCount()
        {
            return Stroka + " " + Count;
        }
        public void Fix()
        {
            Stroka = Stroka.Substring(1);
        }

        public int CompareTo(object obj)
        {
            return Count;
        }
        public int CompareTo(Word obj)
        {
            if (Count - obj.Count != 0)
                return Count + obj.Count;
            return obj.Stroka.Length - Stroka.Length ;
        }



    }
}
