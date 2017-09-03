using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLSourceUkr
{
    public partial class fMain : Form
    {
        string mPath = "";
        const string csDisplayName = "Half-Life: Source";
        const string csSubFolder = "\\hl1\\custom";
        const string csZipFileName = "mod.zip";
        const string csEmbeddedZip = "HLSourceUkr.LocalizationFiles." + csZipFileName;
        public fMain()
        {
            InitializeComponent();
            FindGamePath();
            mPath = PrepareGamePath(mPath);
        }

        void FindGamePath()
        {
            try
            {
                string DisplayName;

                string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
                if (key != null)
                {
                    foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                    {
                        DisplayName = subkey.GetValue("DisplayName") as string;
                        if (DisplayName != null && DisplayName.Contains(csDisplayName))
                        {
                            mPath = subkey.GetValue("InstallLocation") as string;
                            SetMessage("Тека гри знайдена.", false);
                            return;
                        }
                    }
                    key.Close();
                }

                registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
                key = Registry.LocalMachine.OpenSubKey(registryKey);
                if (key != null)
                {
                    foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                    {
                        DisplayName = subkey.GetValue("DisplayName") as string;
                        if (DisplayName != null && DisplayName.Contains(csDisplayName))
                        {
                            mPath = subkey.GetValue("InstallLocation") as string;
                            SetMessage("Тека гри знайдена.", false);
                            return;
                        }
                    }
                    key.Close();
                }

                SetMessage("Тека гри не знайдена.");
                btLocalize.Enabled = false;
                btOpenFolder.Enabled = false;
                btExit.Focus();
            }
            catch (Exception ex)
            {
                string Message = ComposeErrorMessage(ex);
                SetMessage("Помилка при читанні реєстру Windows.\r\n" + Message);
            }
        }

        string PrepareGamePath(string Path)
        {
            if (string.IsNullOrWhiteSpace(Path))
                return Path;

            Path = Path.TrimEnd(new char[] { '\\' });
            return Path;
        }

        void btLocalize_Click(object sender, EventArgs e)
        {
            btExit.Enabled = false;
            btLocalize.Enabled = false;
            btOpenFolder.Enabled = false;

            try
            {
                string FullPath = mPath + csSubFolder;
                Directory.CreateDirectory(FullPath);
                ExtractZip(FullPath);
                ZipFile.ExtractToDirectory(FullPath + "\\ " + csZipFileName, FullPath);
                SetMessage("Файли успішно скопійовані у теку \\hl1\\custom", false);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

            btExit.Enabled = true;
            btLocalize.Enabled = true;
            btOpenFolder.Enabled = true;
            btExit.Focus();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void btRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string FullPath = mPath + csSubFolder;
                if (!Directory.Exists(FullPath))
                    throw new Exception("Тека не існує");

                Directory.Delete(FullPath, true);

                SetMessage("Тека " + csSubFolder + " та весь її вміст успішно вилучено.", false);
            }
            catch (Exception ex)
            {
                SetMessage("Не вдалося вилучити теку " + csSubFolder + " та весь її вміст. Помилка: " + ex.Message);
            }
        }

        void btOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo { Arguments = mPath, FileName = "explorer.exe" };
                Process.Start(startInfo);
            }
            else
            {
                SetMessage("Тека гри не знайдена в реєстрі Windows. Тому її розташування відкрити неможливо.");
            }
        }

        void ExtractZip(string FullPath)
        {
            //write the resource zip file to the temp directory
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(csEmbeddedZip))
            {
                using (FileStream fs = File.Create(FullPath + "\\ " + csZipFileName))
                {
                    //read until we reach the end of the file
                    while (stream.Position < stream.Length)
                    {
                        //byte array to hold file bytes
                        byte[] bits = new byte[stream.Length];
                        //read in the bytes
                        stream.Read(bits, 0, (int)stream.Length);
                        //write out the bytes
                        fs.Write(bits, 0, (int)stream.Length);
                    }
                }
            }
        }

        void SetMessage(string Message, bool IsError = true)
        {
            tbMessage.Text = Message;
            if (IsError)
                tbMessage.ForeColor = Color.Red;
            else
                tbMessage.ForeColor = Color.Green;
        }

        string ComposeErrorMessage(Exception ex)
        {
            string Message = ex.Message.Replace("See the inner exception for details.", "");
            if (null != ex.InnerException)
            {
                Message += "\r\n";
                Message += ComposeErrorMessage(ex.InnerException);
            }
            return Message;
        }
    }
}
