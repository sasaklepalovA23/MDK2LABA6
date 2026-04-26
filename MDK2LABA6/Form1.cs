using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MDK2LABA6
{
    public partial class Form1 : Form
    {
        double firstNum = 0;
        string operation = "";
        bool isOperationPerformed = false;

        class Note
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public override string ToString() => Title;
        }
        public Form1()
        {
            InitializeComponent();
            SetupUI(); 
        }

        private void OnNumClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || isOperationPerformed)
                textBox1.Clear();

            isOperationPerformed = false;
            Button btn = (Button)sender;

            if (btn.Text == ".")
            {
                if (!textBox1.Text.Contains(".")) textBox1.Text += ".";
            }
            else
            {
                textBox1.Text += btn.Text;
            }
        }

        private void OnOpClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            firstNum = double.Parse(textBox1.Text);
            operation = btn.Text;
            isOperationPerformed = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            firstNum = 0;
            operation = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(textBox1.Text);
            double result = 0;

            switch (operation)
            {
                case "+": result = firstNum + secondNum; break;
                case "-": result = firstNum - secondNum; break;
                case "*": result = firstNum * secondNum; break;
                case "/":
                    if (secondNum != 0) result = firstNum / secondNum;
                    else { MessageBox.Show("Деление на ноль!"); return; }
                    break;
            }

            string historyEntry = $"{firstNum} {operation} {secondNum} = {result}";
            listBox1.Items.Add(historyEntry);
            textBox1.Text = result.ToString();
            isOperationPerformed = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listBox1.Visible = !listBox1.Visible;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Note newNote = new Note();
            newNote.Title = textBox2.Text;
            newNote.Content = textBox3.Text;
            listBox2.Items.Add(newNote);
            textBox2.Clear();
            textBox3.Clear();
        }
        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Note selectedNote = (Note)listBox2.SelectedItem;

                textBox2.Text = selectedNote.Title;   
                textBox3.Text = selectedNote.Content; 
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                ClearNoteFields();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex; 

            if (index != -1) 
            {
               
                Note updatedNote = new Note
                {
                    Title = textBox2.Text,
                    Content = textBox3.Text
                };

             
                listBox2.Items[index] = updatedNote;

                MessageBox.Show("Заметка обновлена!");
            }
            else
            {
                MessageBox.Show("Сначала выберите заметку из списка!");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ClearNoteFields();
        }

        private void ClearNoteFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            listBox2.ClearSelected();
        }
        private void SetupUI()
        {
            this.Text = "Многофункциональное приложение";
            this.Size = new System.Drawing.Size(450, 550);
        }
    }
}
