using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ButtonForm
{
    public partial class Form1 : Form
    {
       private List<string> listofwords = new List<string>();
        static string GetExecPath()
        {
            string exeFileName= System.Reflection.Assembly.GetExecutingAssembly().Location;
            string Result = Path.GetDirectoryName(exeFileName);
            return Result;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Clear();
            listofwords.Clear();
            Stopwatch t = new Stopwatch();
            Stopwatch t1 = new Stopwatch();
            t.Start();
            string fileName = openFileDialog1.FileName;
            t.Stop();
            label3.Text = t.Elapsed.ToString();
            t1.Start();
            string ReadText= File.ReadAllText(fileName);
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] mas = ReadText.Split(delimiterChars);
            foreach (string word in mas)
            {
                string clearword = word.Trim();
                if(!listofwords.Contains(clearword))
                listofwords.Add(clearword);
            }
            t1.Stop();
            label4.Text = t1.Elapsed.ToString();
            foreach (string word in listofwords)
            {
                textBox1.Text+= word+" "; 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
     
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            string findWord = textBox3.Text;
            if (listofwords.Contains(findWord))
            {
                MessageBox.Show(
                    "Слово найдено"
                    );
                listBox1.BeginUpdate();
                listBox1.Items.Add(findWord);
                listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show(
                    "Слово не найдено"
                    );
            }
            t.Stop();
            label6.Text = t.Elapsed.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
