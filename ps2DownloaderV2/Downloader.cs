using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ps2DownloaderV2
{
    class Downloader
    {
        private string url;
        private string filename;
        private string sha;
        private ProgressBar p;
        private ListBox l;
        private Button b;
        public Downloader(string url,string sha,string filename,ProgressBar p,ListBox l,Button b)
        {
            this.url = url;
            this.filename = filename;
            this.sha = sha;
            this.p = p;
            this.l = l;
            this.b = b;
        }

        public void Download()
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            client.DownloadFileAsync(new Uri(url),filename+".lzma");
        }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            p.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            l.Items.Add("Download Complete. start validation. please wait");
            try
            {
                FileStream stream = File.OpenRead(filename + ".lzma");
                SHA1Managed s = new SHA1Managed();
                byte[] checksum = s.ComputeHash(stream);
                string sendCheckSum = BitConverter.ToString(checksum).Replace("-", string.Empty).ToLower();
                if (checkValid(sha, sendCheckSum))
                {
                    l.Items.Add("Start unpack. please wait");
                    Process p = Process.Start("7z.exe", "e " + filename + ".lzma");
                    p.WaitForExit();
                    stream.Close();
                    File.Delete(filename + ".lzma");
                    l.Items.Add("Unpack complete.");
                }
                else
                {
                    stream.Close();
                    l.Items.Add("File Validation FAIL.(error -1)");
                    File.Delete(filename + ".lzma");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                l.Items.Add("UNKNOWN ERROR. please report");
            }
            finally
            {
                b.Enabled = true;
            }
        }
        private bool checkValid(string sha,string dsha)
        {
            if (sha == dsha)
            {
                return true;
            }
            return false;
        }
    }
}
