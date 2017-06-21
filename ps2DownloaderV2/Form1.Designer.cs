namespace ps2DownloaderV2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.filename_txtbox = new System.Windows.Forms.TextBox();
            this.tmp1_btn = new System.Windows.Forms.Button();
            this.log_list = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.server_list = new System.Windows.Forms.ComboBox();
            this.download_btn = new System.Windows.Forms.Button();
            this.credit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filename_txtbox
            // 
            this.filename_txtbox.Location = new System.Drawing.Point(12, 42);
            this.filename_txtbox.Name = "filename_txtbox";
            this.filename_txtbox.Size = new System.Drawing.Size(308, 25);
            this.filename_txtbox.TabIndex = 0;
            // 
            // tmp1_btn
            // 
            this.tmp1_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tmp1_btn.Location = new System.Drawing.Point(13, 12);
            this.tmp1_btn.Name = "tmp1_btn";
            this.tmp1_btn.Size = new System.Drawing.Size(307, 25);
            this.tmp1_btn.TabIndex = 1;
            this.tmp1_btn.Text = "Input File name";
            this.tmp1_btn.UseVisualStyleBackColor = false;
            // 
            // log_list
            // 
            this.log_list.FormattingEnabled = true;
            this.log_list.ItemHeight = 15;
            this.log_list.Location = new System.Drawing.Point(13, 87);
            this.log_list.Name = "log_list";
            this.log_list.Size = new System.Drawing.Size(452, 229);
            this.log_list.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 337);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(307, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // server_list
            // 
            this.server_list.FormattingEnabled = true;
            this.server_list.Location = new System.Drawing.Point(344, 12);
            this.server_list.Name = "server_list";
            this.server_list.Size = new System.Drawing.Size(121, 23);
            this.server_list.TabIndex = 4;
            // 
            // download_btn
            // 
            this.download_btn.Location = new System.Drawing.Point(344, 43);
            this.download_btn.Name = "download_btn";
            this.download_btn.Size = new System.Drawing.Size(121, 23);
            this.download_btn.TabIndex = 5;
            this.download_btn.Text = "Download";
            this.download_btn.UseVisualStyleBackColor = true;
            this.download_btn.Click += new System.EventHandler(this.download_btn_Click);
            // 
            // credit_btn
            // 
            this.credit_btn.Location = new System.Drawing.Point(344, 337);
            this.credit_btn.Name = "credit_btn";
            this.credit_btn.Size = new System.Drawing.Size(121, 23);
            this.credit_btn.TabIndex = 6;
            this.credit_btn.Text = "credit";
            this.credit_btn.UseVisualStyleBackColor = true;
            this.credit_btn.Click += new System.EventHandler(this.credit_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 380);
            this.Controls.Add(this.credit_btn);
            this.Controls.Add(this.download_btn);
            this.Controls.Add(this.server_list);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.log_list);
            this.Controls.Add(this.tmp1_btn);
            this.Controls.Add(this.filename_txtbox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ps2 Downloader v2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filename_txtbox;
        private System.Windows.Forms.Button tmp1_btn;
        private System.Windows.Forms.ListBox log_list;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox server_list;
        private System.Windows.Forms.Button download_btn;
        private System.Windows.Forms.Button credit_btn;
    }
}

