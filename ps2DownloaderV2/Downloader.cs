using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using SevenZip.Compression.LZMA;

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
                    stream.Close();
                    l.Items.Add("Start unpack. please wait");
                    decompress(@".\"+filename+".lzma",@".\"+filename);
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
        private void decompress(string target,string outFile)
        {
            Decoder decoder = new Decoder();
            FileStream input = new FileStream(target, FileMode.Open);
            FileStream output = new FileStream(outFile, FileMode.Create);

            byte[] properties = new byte[5];
            input.Read(properties, 0, 5);

            byte[] fileLengthBytes = new byte[8];
            input.Read(fileLengthBytes, 0, 8);
            long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

            decoder.SetDecoderProperties(properties);
            decoder.Code(input, output, input.Length, fileLength, null);
            output.Flush();
            output.Close();
            input.Close();
        }
    }
}
