namespace PFCapture
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBoxFilePath = new System.Windows.Forms.ComboBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.labelImage = new System.Windows.Forms.Label();
            this.comboBoxImage = new System.Windows.Forms.ComboBox();
            this.labelText = new System.Windows.Forms.Label();
            this.comboBoxText = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelPreviewTime = new System.Windows.Forms.Label();
            this.numericUpDownPreviewTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewTime)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFilePath
            // 
            this.comboBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBoxFilePath.FormattingEnabled = true;
            this.comboBoxFilePath.Location = new System.Drawing.Point(14, 7);
            this.comboBoxFilePath.Name = "comboBoxFilePath";
            this.comboBoxFilePath.Size = new System.Drawing.Size(260, 20);
            this.comboBoxFilePath.TabIndex = 0;
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Location = new System.Drawing.Point(12, 35);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(55, 16);
            this.checkBoxSound.TabIndex = 1;
            this.checkBoxSound.Text = "&Sound";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            // 
            // labelImage
            // 
            this.labelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImage.AutoSize = true;
            this.labelImage.Location = new System.Drawing.Point(108, 36);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(37, 12);
            this.labelImage.TabIndex = 2;
            this.labelImage.Text = "&Image:";
            // 
            // comboBoxImage
            // 
            this.comboBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImage.FormattingEnabled = true;
            this.comboBoxImage.Location = new System.Drawing.Point(151, 33);
            this.comboBoxImage.Name = "comboBoxImage";
            this.comboBoxImage.Size = new System.Drawing.Size(121, 20);
            this.comboBoxImage.TabIndex = 3;
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(115, 92);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(30, 12);
            this.labelText.TabIndex = 6;
            this.labelText.Text = "&Text:";
            // 
            // comboBoxText
            // 
            this.comboBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxText.FormattingEnabled = true;
            this.comboBoxText.Location = new System.Drawing.Point(151, 89);
            this.comboBoxText.Name = "comboBoxText";
            this.comboBoxText.Size = new System.Drawing.Size(121, 20);
            this.comboBoxText.TabIndex = 7;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PF Capture";
            this.notifyIcon.Visible = true;
            // 
            // labelPreviewTime
            // 
            this.labelPreviewTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPreviewTime.AutoSize = true;
            this.labelPreviewTime.Location = new System.Drawing.Point(60, 66);
            this.labelPreviewTime.Name = "labelPreviewTime";
            this.labelPreviewTime.Size = new System.Drawing.Size(86, 12);
            this.labelPreviewTime.TabIndex = 4;
            this.labelPreviewTime.Text = "&Preview (msec):";
            // 
            // numericUpDownPreviewTime
            // 
            this.numericUpDownPreviewTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPreviewTime.Location = new System.Drawing.Point(152, 64);
            this.numericUpDownPreviewTime.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownPreviewTime.Name = "numericUpDownPreviewTime";
            this.numericUpDownPreviewTime.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownPreviewTime.TabIndex = 5;
            this.numericUpDownPreviewTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPreviewTime.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.comboBoxText);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.numericUpDownPreviewTime);
            this.Controls.Add(this.labelPreviewTime);
            this.Controls.Add(this.comboBoxImage);
            this.Controls.Add(this.labelImage);
            this.Controls.Add(this.checkBoxSound);
            this.Controls.Add(this.comboBoxFilePath);
            this.Name = "FormMain";
            this.Text = "PF Capture";
            this.Load += new System.EventHandler(this.load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFilePath;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.ComboBox comboBoxImage;
        private System.Windows.Forms.Label labelPreviewTime;
        private System.Windows.Forms.NumericUpDown numericUpDownPreviewTime;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.ComboBox comboBoxText;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

