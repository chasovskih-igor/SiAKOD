using ClassLibrary3.SiAKOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Trie
    {
        Node first;

        public Trie()
        {
            first = new Node('\0', false, "");
        }
        public void Add(string str)
        {
            first.Add(str.ToLower());
        }
        public void AddChar(char el)
        {
            first.Add(el.ToString().ToLower().ToCharArray()[0]);
        }
        public void AddChar(char el, string parents)
        {
            first.Add((parents + el).ToLower(), false);
        }
        public bool IsWord(string str)
        {
            return first.IsWord(str.ToLower());
        }
        public List<string> GetWords()
        {
            List<string> listWords = new List<string>();
            List<Node> q = first.GetChildren();
            while (q.Count != 0)
            {
                if (q[0] != null && q[0].IsEdnCharOfWord)
                {
                    listWords.Add(q[0].GetWord().Substring(1));
                }
                q.AddRange(q[0].GetChildren());
                q.RemoveAt(0);
            }
            return listWords;
        }
        public List<Word> GetWordsCount()
        {
            return GetWordsCount("");
        }

        private static List<Node> Clone(List<Node> list)
        {
            Node[] t = new Node[list.Count];
            list.CopyTo(t);
            return new List<Node>(t);
        }
        public List<Word> GetWordsCount(string s)
        {
            List<Word> listWords = new List<Word>();
            List<Node> q = Clone(first.GetChildren(s));
            while (q.Count != 0)
            {
                if (q[0] != null && q[0].IsEdnCharOfWord)
                {
                    listWords.Add(q[0].GetWordCount());
                }
                q.AddRange(q[0].GetChildren());
                q.RemoveAt(0);
            }
            listWords.Sort();
            return listWords;
        }

        public void AddStrings(string[] words)
        {
            foreach (string s in words)
            {
                Add(s.ToLower());
            }
        }
    }
}
