using Microsoft.Win32;
using PFCapture.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatAndExtensions = System.Collections.Generic.KeyValuePair<System.Drawing.Imaging.ImageFormat, string>;

namespace PFCapture
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private bool dialogShowing = false;
        private Dictionary<string, Encoding> encodings = new Dictionary<string, Encoding>();
        private FormPreview formPreview;
        private Dictionary<string, FormatAndExtensions> imageFormats = new Dictionary<string, FormatAndExtensions>();

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = Size;
            MaximumSize = new System.Drawing.Size(int.MaxValue, Size.Height);
            notifyIcon.Icon = Resources.Small;
            imageFormats.Add("PNG", new FormatAndExtensions(ImageFormat.Png, ".png"));
            imageFormats.Add("BMP", new FormatAndExtensions(ImageFormat.Bmp, ".bmp"));
            imageFormats.Add("EMF", new FormatAndExtensions(ImageFormat.Emf, ".emf"));
            imageFormats.Add("EXIF", new FormatAndExtensions(ImageFormat.Exif, ".exif"));
            imageFormats.Add("GIF", new FormatAndExtensions(ImageFormat.Gif, ".gif"));
            imageFormats.Add("ICON", new FormatAndExtensions(ImageFormat.Icon, ".ico"));
            imageFormats.Add("JPEG", new FormatAndExtensions(ImageFormat.Jpeg, ".jpg"));
            imageFormats.Add("TIFF", new FormatAndExtensions(ImageFormat.Tiff, ".tiff"));
            imageFormats.Add("WMF", new FormatAndExtensions(ImageFormat.Wmf, ".wmf"));
            encodings.Add(Encoding.Unicode.EncodingName, Encoding.Unicode);
            encodings.Add(Encoding.Default.EncodingName, Encoding.Default);
            encodings.Add(Encoding.UTF7.EncodingName, Encoding.UTF7);
            encodings.Add(Encoding.UTF8.EncodingName, Encoding.UTF8);
            encodings.Add(Encoding.ASCII.EncodingName, Encoding.ASCII);
            encodings.Add(Encoding.BigEndianUnicode.EncodingName, Encoding.BigEndianUnicode);
            encodings.Add(Encoding.UTF32.EncodingName, Encoding.UTF32);
            formPreview = new FormPreview();
        }

        #endregion

        #region Private Methods

        void crateDirectory(string directoryName)
        {
            try
            {
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
            catch
            {
                throw;
            }
        }

        void notifyFatalError()
        {
            showErrorMessage("致命的なエラーが発生しました。");
        }

        void notifyFileSaveCompleted(string fileName)
        {
            showBalloonTip(string.Format("ファイルを保存しました。\r\n{0}", fileName));
        }

        bool saveClipboardImage(string directoryName, string fileName, FormatAndExtensions formatAndExtensions, out string fileFullName)
        {
            fileFullName = string.Format("{0}{1}{2}{3}", directoryName, Path.DirectorySeparatorChar, fileName, formatAndExtensions.Value);

            try
            {
                Image image = Clipboard.GetImage();

                if (image == null)
                {
                    return false;
                }

                crateDirectory(directoryName);
                image.Save(fileFullName, formatAndExtensions.Key);

                int previewTime = (int)numericUpDownPreviewTime.Value;

                if (previewTime > 0)
                {
                    formPreview.Show(this, image, previewTime);
                }
                else
                {
                    image.Dispose();
                }

                return true;
            }
            catch (Exception exception)
            {
                showErrorMessage(exception.Message);
            }

            return false;
        }

        bool saveClipboardText(string directoryName, string fileName, Encoding encoding, out string fileFullName)
        {
            fileFullName = string.Format("{0}{1}{2}.txt", directoryName, Path.DirectorySeparatorChar, fileName);

            try
            {
                string text = Clipboard.GetText();

                if (string.IsNullOrEmpty(text))
                {
                    return false;
                }

                crateDirectory(directoryName);
                File.WriteAllText(fileFullName, text, encoding);
                return true;
            }
            catch (Exception exception)
            {
                showErrorMessage(exception.Message);
            }

            return false;
        }

        void showBalloonTip(string message)
        {
            notifyIcon.ShowBalloonTip(2000, Text, message, ToolTipIcon.Info);

            if (checkBoxSound.Checked)
            {
                try
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
                catch
                {
                }
            }
        }

        void showErrorMessage(string message)
        {
            showMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void showMessage(string message, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            if (dialogShowing)
            {
                return;
            }

            if (checkBoxSound.Checked)
            {
                try
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                catch
                {
                }

                return;
            }

            dialogShowing = true;
            MessageBox.Show(this, message, Text, messageBoxButtons, messageBoxIcon);
            dialogShowing = false;
        }

        #endregion

        // Designer Methods

        private void checkBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = checkBoxEnable.Checked;
            clipboardViewer.Enabled = enabled;

            if (enabled)
            {
                notifyIcon.Icon = Resources.Small;
            }
            else
            {
                notifyIcon.Icon = Resources.Gray;
            }
        }

        private void clipboardViewer_DrawClipBoard(object sender, ClipboardEventArgs e)
        {
            if (!checkBoxEnable.Checked)
            {
                return;
            }

            if (dialogShowing)
            {
                return;
            }

            string encodingName = comboBoxText.Text;
            string formatName = comboBoxImage.Text;
            bool imageFormatExists = imageFormats.ContainsKey(formatName);
            bool encodingFormatExists = encodings.ContainsKey(encodingName);

            if (!(imageFormatExists || encodingFormatExists))
            {
                return;
            }

            string fileName;

            try
            {
                DateTime currentTime = DateTime.Now;
                fileName = string.Format("{0:d4}{1:d2}{2:d2}{3:d2}{4:d2}{5:d2}",
                    currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, currentTime.Second);
            }
            catch (Exception exception)
            {
                showErrorMessage(exception.Message);
                return;
            }

            string directoryName = comboBoxFilePath.Text;
            string savedFileName = string.Empty;
            bool saved = false;

            if (encodingFormatExists)
            {
                Encoding encoding;

                if (encodings.TryGetValue(comboBoxText.Text, out encoding))
                {
                    if (saveClipboardText(directoryName, fileName, encoding, out savedFileName))
                    {
                        saved = true;
                        notifyFileSaveCompleted(savedFileName);
                    }
                }
                else
                {
                    notifyFatalError();
                }
            }

            if (imageFormatExists)
            {
                FormatAndExtensions formatAndExtensions;

                if (imageFormats.TryGetValue(comboBoxImage.Text, out formatAndExtensions))
                {
                    savedFileName = string.Empty;

                    if (saveClipboardImage(directoryName, fileName, formatAndExtensions, out savedFileName))
                    {
                        saved = true;
                        notifyFileSaveCompleted(savedFileName);
                    }
                }
                else
                {
                    notifyFatalError();
                }
            }

            if (saved)
            {
                IEnumerable<object> items = comboBoxFilePath.Items.OfType<object>();
                bool exist = items.Any(n => string.Compare(n.ToString(), directoryName, true) == 0);

                if (!exist)
                {
                    comboBoxFilePath.Items.Add(directoryName);
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool enable = checkBoxEnable.Checked;
            toolStripMenuItemEnable.Checked = enable;
            toolStripMenuItemDisable.Checked = !enable;
        }

        private void load(object sender, EventArgs e)
        {
            comboBoxFilePath.Items.Add(Application.StartupPath);

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Resources.UserShellFolder))
                {

                    try
                    {
                        comboBoxFilePath.Items.Add(key.GetValue(Resources.ShellFolderPersonal));
                    }
                    catch
                    {
                    }

                    try
                    {
                        comboBoxFilePath.Items.Add(key.GetValue(Resources.ShellFolderMyPictures));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            comboBoxFilePath.SelectedIndex = 0;
            comboBoxText.Items.Add("-");

            foreach (KeyValuePair<string, Encoding> pair in encodings)
            {
                comboBoxText.Items.Add(pair.Key);
            }

            comboBoxText.SelectedIndex = 0;
            comboBoxImage.Items.Add("-");

            foreach (KeyValuePair<string, FormatAndExtensions> pair in imageFormats)
            {
                comboBoxImage.Items.Add(pair.Key);
            }

            comboBoxImage.SelectedIndex = 0;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    checkBoxEnable.Checked = !checkBoxEnable.Checked;
                    break;
            }
        }

        private void toolStripMenuItemDisable_Click(object sender, EventArgs e)
        {
            checkBoxEnable.Checked = false;
        }

        private void toolStripMenuItemEnable_Click(object sender, EventArgs e)
        {
            checkBoxEnable.Checked = true;
        }
    }
}
