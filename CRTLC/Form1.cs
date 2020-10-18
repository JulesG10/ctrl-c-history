using System;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using Gma.System.MouseKeyHook;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRTLC
{
    public partial class WindowI : Form
    {
        public WindowI()
        {
            InitializeComponent();
        }


        Timer timer = new Timer();

        string pathdir;

        private void GetDirLog()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathdir = fbd.SelectedPath;
                    LoadData(fbd.SelectedPath);
                    NewDay();
                }
            }
        }

        private void NewDay()
        {
            string date = "crtl@" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!File.Exists(Path.Combine(pathdir, date)))
            {
                CreateFile(Path.Combine(pathdir, date));
            }
            Subscribe();
        }

        private IKeyboardMouseEvents mouse;
        public void Subscribe()
        {
            mouse = Hook.GlobalEvents();
            mouse.KeyPress += KeyPress;
        }

        private int back = 0;

        private new void KeyPress(object sender, KeyPressEventArgs e) {
            string date = "crtl@" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if ((int)e.KeyChar == 22)
            {
                string text = Clipboard.GetText();
                text = text.Replace("\n", "").Replace("\r", "");
                string content = "" + DateTime.Now.ToString("HH-mm-ss") + " "+ text +"\n";
                AddToFile(Path.Combine(pathdir, date), content);
                dataLog.Items.Clear();
                LoadData(pathdir);
            }
            else if((int)e.KeyChar == 12)
            {
                if(back>= memory.Count - 1)
                {
                    back = 0;
                    if (memory[back] != null && memory[back] != String.Empty)
                    {
                        Clipboard.SetText(memory[back]);
                    }
                }
                else
                {
                    if (memory[back] != null && memory[back] != String.Empty)
                    {
                        Clipboard.SetText(memory[back]);
                    }
                }
                back++;
            }
        }
   
        private void CreateFile(string path)
        {
            File.AppendAllText(path,"");
        }

        private void AddToFile(string path,string content)
        {
            File.AppendAllText(path, content);
        }

        List<string> memory = new List<string>();

        private void LoadData(string path)
        {
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".log")
                    {
                        string[] lines = File.ReadAllLines(file);
                        Array.Reverse(lines);
                        CreateLine("[" + Path.GetFileName(file) + "]", "");
                        foreach (string line in lines)
                        {
                            if (Regex.Match(line, @"(([0-9:]+)\s*((.?)*))") != null)
                            {
                                string date = line.Split(' ')[0];
                                string content = line.Split(' ')[1];
                                CreateLine(date, content);
                                memory.Add(content);
                            }
                            
                        }
                    }
                }
            }
        }
        private void CreateLine(string date,string content)
        {
            dataLog.Alignment = ListViewAlignment.Left;
            if (date != String.Empty)
            {
                ListViewItem it = new ListViewItem();
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem();
                it.Text = date;
                sub.Text = content;
                it.SubItems.Add(sub);
                dataLog.Click += DataLog_Click;
                dataLog.SelectedIndexChanged += DataLog_Click;
                dataLog.Items.Add(it);
            }
        }

        private void DataLog_Click(object sender, EventArgs e)
        {
            if(dataLog.SelectedItems.Count > 0)
            {
                ListViewItem it = dataLog.SelectedItems[0];
                if (it.SubItems.Count >= 2)
                {
                    if (it.SubItems[1].Text != null && it.SubItems[1].Text != String.Empty)
                    {
                        Clipboard.SetText(it.SubItems[1].Text);
                    }
                }
            }   
        }

        private void Form_Load(object sender, EventArgs e)
        {
            GetDirLog();
        }

    }
}
