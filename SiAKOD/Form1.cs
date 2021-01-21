using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;
using ClassLibrary3.SiAKOD;

namespace SiAKOD
{
    public partial class Form1 : Form
    {
        Trie trie = new Trie();
        public Form1()
        {

            InitializeComponent();
            trie.AddStrings(MyFileOperation.ReadFromFileInArray("C:\\Users\\user\\source\\repos\\SiAKOD\\Dic_Big1.dic"));
            richTextBox2.Text += Join(trie.GetWordsCount().ToArray());
        }

        private string Join(Word[] arr)
        {            
            string txt = "";
            for (int i = 0; i< arr.Length; i++)
            {
                string k = arr[i].ToString();
                txt += k + "\n";
            }
            return txt;
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            trie.Add(textBox1.Text.ToLower());
            richTextBox2.Text += Join(trie.GetWordsCount().ToArray());
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += Join(trie.GetWordsCount(textBox1.Text).ToArray());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            trie.AddStrings(MyFileOperation.ReadFromFileInArray("C:\\Users\\user\\source\\repos\\SiAKOD\\Dic_Big2.dic"));
            richTextBox2.Text += Join(trie.GetWordsCount().ToArray());
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
