using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ps2DownloaderV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            server_list.Items.Add("server1");
            server_list.Items.Add("server2");
            server_list.Items.Add("server3");
            server_list.Items.Add("server4");
            server_list.SelectedIndex = 0;
            filename_txtbox.Text = "Assets_000.pack";
            log_list.Items.Add("Logs");
        }

        private void download_btn_Click(object sender, EventArgs e)
        {
            string filename = filename_txtbox.Text;
            if (filename.Length == 0)
            {
                MessageBox.Show("PLEASE INPUT FILENAME");
                return;
            }
            download_btn.Enabled = false;
            int server_code = 1;
            if (server_list.SelectedText == "server1")
            {
                server_code = 1;
            }
            else if (server_list.SelectedText == "server2")
            {
                server_code = 2;
            }
            else if (server_list.SelectedText == "server3")
            {
                server_code = 3;
            }
            else if (server_list.SelectedText == "server4")
            {
                server_code = 4;
            }
            Thread t = new Thread(()=>run(filename,server_code));
            t.Start();
            log_list.Items.Add("Find File at DBG Server. please wait...");
        }
        private void run(string filename,int server_code)
        {
            string sha = "";
            string url = "";
            sha = findFile.findsha(filename);
            if (sha.Length == 0)
            {
                MessageBox.Show("NO FILE. PLEASE CHECK FILE NAME","ALERT");
                log_list.Items.Add("NO FILE");
                download_btn.Enabled = true;
                return;
            }
            url = findFile.makeUrl(sha, server_code);
            Downloader d = new Downloader(url,sha, filename,progressBar1,log_list,download_btn);
            d.Download();
        }
        void UpdateProgressBar(int value)
        {
            this.progressBar1.Value = value;
        }

        public delegate void UpdateProgressDelegate(int value);

        private void credit_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By fkesb1");
        }
    }
}
