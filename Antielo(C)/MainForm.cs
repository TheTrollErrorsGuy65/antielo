using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Antielo
{
    public partial class MainForm : Form
    {
        string xdd;
        string xdd1;
        string xdd2;
        string xdd3;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // setting all things
            this.Text = "Antielo";
            this.Icon = Properties.Resources.elo;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            button1.Text = "remove 'elo' from file";
            button2.Text = "remove 'elo' from webpage";
            textBox1.Enabled = false;
            button3.Enabled = false;
            textBox1.Text = "Webpage address";
            button3.Text = "remove";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            webBrowser1.ScriptErrorsSuppressed = false;
            webBrowser1.Visible = false;
            saveFileDialog2.FileName = "";
            saveFileDialog2.Filter = "HTML Files (*.html)|*.html";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            xdd = File.ReadAllText(openFileDialog1.FileName);
            xdd1 = xdd.Replace("elo", "");
            xdd2 = xdd1.Replace("ELO", "");
            xdd3 = xdd2.Replace("Elo", "");
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, xdd3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            xdd = webBrowser1.DocumentText;
            textBox1.Enabled = false;
            button3.Enabled = false;
            xdd1 = xdd.Replace("elo", "");
            xdd2 = xdd1.Replace("ELO", "");
            xdd3 = xdd2.Replace("Elo", "");
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog2.FileName, xdd3);
        }
    }
}