using ClassLibrary3.SiAKOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    class Node
    {
        public int Count;
        char ch;
        public char Ch { get => ch; }
        public bool IsEdnCharOfWord { get => isEdnCharOfWord; set => isEdnCharOfWord = value; }
        public List<Node> nodes;
        string parents;

        bool isEdnCharOfWord;

        public Node(char el, bool isWord, string parents)
        {
            this.ch = el;
            this.isEdnCharOfWord = isWord;
            nodes = new List<Node>();
            this.parents = parents;
            Count = 0;
        }

        public void Add(Node t)
        {
            if (!InChildren(t.ch))
            {
                nodes.Add(t);
            }
            else
            {
                GetChild(t.ch).Count++;
            }
        }
        public void Add(char el, bool isWord)
        {
            Add(new Node(el, isWord, parents + ch));

        }
        public void Add(char el)
        {
            Add(el, false);
        }
        public void Add(string word)
        {
            Add(word, true);
        }
        public void Add(string word, bool isWord)
        {
            if (word.Length == 0)
            {
                this.isEdnCharOfWord = isWord;
                this.Count++;
                return;
            }
            char first = word.ToCharArray()[0];
            if (!InChildren(first))
            {
                Add(first);
            }
            GetChild(first).Add(word.Substring(1));
        }
        public Node GetChild(char el)
        {
            foreach (Node node in nodes)
            {
                if (node.Equals(el))
                {
                    return node;
                }
            }
            return null;
        }
        public Node GetChild(string word)
        {
            if (word.Length == 0)
            {
                return this;
            }
            else if (word.Length == 1)
            {
                return GetChild(word.ToCharArray()[0]);
            }
            else
            {
                return GetChild(word.ToCharArray()[0]).GetChild(word.Substring(1));
            }
        }
        public bool InChildren(char el)
        {
            foreach (Node node in nodes)
            {
                if (node.Equals(el))
                {
                    return true;
                }
            }

            return false;
        }
        public bool Equals(Node node)
        {
            return node.ch == ch && parents.Equals(node.parents);
        }
        public bool Equals(char el)
        {
            return el == ch;
        }
        public bool IsWord(string word)
        {
            if (word.Length == 0)
            {
                return isEdnCharOfWord;
            }
            char first = word.ToCharArray()[0];
            if (InChildren(first))
            {
                return GetChild(first).IsWord(word.Substring(1));
            }
            else
            {
                return false;
            }
        }
        public string GetWord()
        {
            return parents + ch;
        }
        public string GetWord(string word)
        {
            if (IsWord(word))
            {
                if (word.Length == 0)
                {
                    return GetWord();
                }
                else
                {
                    char first = word.ToCharArray()[0];
                    if (InChildren(first))
                    {
                        return GetChild(first).GetWord(word.Substring(1));
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        public Word GetWordCount()
        {
            return new Word(GetWord(), Count);
        }
        public Word GetWordCount(string word)
        {
            if (IsWord(word))
            {
                if (word.Length == 0)
                {
                    return GetWordCount();
                }
                else
                {
                    char first = word.ToCharArray()[0];
                    if (InChildren(first))
                    {
                        return GetChild(first).GetWordCount(word.Substring(1));
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        public List<Node> GetChildren()
        {
            return GetChildren("");
        }
        public List<Node> GetChildren(string word)
        {
            if (word.Length == 0)
            {
                return nodes;
            }
            char first = word.ToCharArray()[0];
            if (InChildren(first))
            {
                return GetChild(first).GetChildren(word.Substring(1));
            }
            else
            {
                return new List<Node>();
            }
        }

    }
}
