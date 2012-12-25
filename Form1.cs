using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp3qe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Selecione a pasta com as músicas";

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.path = textBox1.Text;

            if (!radioButton1.Checked && !radioButton2.Checked)
                MessageBox.Show("Please, select one of the two modes");
            else
            {
                if (radioButton1.Checked)
                    Properties.Settings.Default.mode = 1;
                if (radioButton2.Checked)
                    Properties.Settings.Default.mode = 2;
                
                Processo p = new Processo();
                p.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
