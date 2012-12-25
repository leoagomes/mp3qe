using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HundredMilesSoftware.UltraID3Lib;

namespace mp3qe
{
    public partial class Processo : Form
    {
        public Processo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.mode == 1)
            {
                //Setting the progress bar value to 0 and then it sets it t the number of files that end with ".mp3" inside a folder (including subfolders)
                progressBar1.Value = 0;
                progressBar1.Maximum = Directory.GetFiles(Properties.Settings.Default.path, "*.mp3", SearchOption.AllDirectories).Length;

                foreach (string file in Directory.GetFiles(Properties.Settings.Default.path, "*.mp3", SearchOption.AllDirectories))
                {
                    //It uses Ultra ID3 Library to access ID3 tags
                    UltraID3 mp3 = new UltraID3();
                    mp3.Read(file);

                    string title = mp3.Title;

                    //If the title inside ID3 tags isn't empty
                    if (title.Trim() != "")
                    {
                        string[] a1 = file.Split('\\'); //splits the path
                        string final = file.Substring(0, file.Length - a1[a1.Length - 1].Length) + title + ".mp3"; 
                        if (!File.Exists(final))
                            File.Move(file, final);
                    }

                    progressBar1.Value++;
                }
            }
            if (Properties.Settings.Default.mode == 2)
            {
                //SAME
                progressBar1.Value = 0;
                progressBar1.Maximum = Directory.GetFiles(Properties.Settings.Default.path, "*.mp3", SearchOption.AllDirectories).Length;

                foreach (string file in Directory.GetFiles(Properties.Settings.Default.path, "*.mp3", SearchOption.AllDirectories))
                {
                    UltraID3 mp3 = new UltraID3();
                    mp3.Read(file);

                    string[] a1 = file.Split('\\'); 
                    string final = a1[a1.Length - 1].Substring(0, a1[a1.Length - 1].Length - 4);

                    mp3.Title = final;

                    mp3.Write();

                    progressBar1.Value++;
                }
            }
        }

        private void Processo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
