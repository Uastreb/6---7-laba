using ConsoleApp9;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;

namespace _6_laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        Vector vector;


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                StreamWriter streamWriter = new StreamWriter(openFileDialog.FileName);
                for (int i= vector.LowRange; i< vector.HighRange; i++)
                {
                    streamWriter.WriteLine(vector[i] + "%{0}", i);
                }
                streamWriter.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                vector = new Vector(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                for (var i = vector.LowRange; i <= vector.HighRange; i++)
                    vector[i] = rand.Next(-99, 100);
                
                richTextBox1.Text += string.Format("Исходный вектор v1 = {0} \n", vector);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += string.Format("Исходный вектор v1 = {0} \n", vector);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += string.Format("Результат умножения вектора на 5, v1*5 = {0} \n", vector = vector.multiplication(5));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += string.Format("Результат деления вектора на 5, v1/5  = {0} \n", vector = vector.division(5));
        }

        private void button6_Click(object sender, EventArgs e)
        {
                int count = 0;
                richTextBox1.Text += string.Format("\nЗаменяем все числа вектора v1 больше 5, на 5 = {0} \nЗамен было произведено: {1}\n", vector = vector.Change(5, ref count), count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();


            //FileStream fileStream = new FileStream()
            if (openFileDialog.FileName != null)
            {
                Vector a = new Vector(3, 7);
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                List<string> list = new List<string>();


                List<string> id = new List<string>();
                List<string> value = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    list.Add(streamReader.ReadLine());
                }


                Vector vect = new Vector(Convert.ToInt32(list[0].Split(new char[] { '%', ' ' })[1]), Convert.ToInt32(list[list.Count - 1].Split(new char[] { '%', ' ' })[1]));
                int h = 0;
                for (int i=vect.LowRange; i<=vect.HighRange; i++)
                { 
                    vect[i] = Convert.ToInt32(list[h].Split(new char[] { '%', ' ' })[0]);
                    h++;
                }

                streamReader.Close();

                vector = vect;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar1.Panels[1].ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
            statusBar1.Panels[1].Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            statusBar1.Panels[1].AutoSize = StatusBarPanelAutoSize.Contents;
        }
    }
}
    