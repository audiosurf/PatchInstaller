using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PatchInstallerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void autoFindBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2"))
            {
                locationTextBox.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2";
                installBtn.Enabled = true;
            }
            else
            {
                try
                {
                    //GameID: 235800
                    object steamPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null) ?? throw new KeyNotFoundException("Steam installation not found");
                    var vdfText = File.ReadAllLines(Path.Combine(steamPath.ToString() ?? throw new InvalidOperationException("Invalid Steam install path"), "config\\libraryfolders.vdf"));
                    var gameLineText = vdfText.FirstOrDefault(x => x.Contains("\"235800\"")) ?? throw new DirectoryNotFoundException("Game isn't listed as installed in Steam");
                    var lineIndex = Array.IndexOf(vdfText, gameLineText);
                    for (int i = lineIndex - 1; i >= 0; i--)
                    {
                        if (vdfText[i].Contains("\"path\""))
                        {
                            vdfText[i] = vdfText[i].Replace("\"path\"", "");
                            var libraryPath = vdfText[i].Substring(vdfText[i].IndexOf('\"') + 1, vdfText[i].LastIndexOf('\"'));
                            libraryPath = libraryPath.Replace("\\\\", "\\");
                            locationTextBox.Text = Path.Combine(libraryPath, "steamapps\\common\\Audiosurf 2");
                            installBtn.Enabled = true;
                            break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(locationTextBox.Text))
                        statusLabel.Text = "Couldn't find game installation";
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "Unable to find game location:\n" + ex.Message;
                }
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            var fb = new FolderBrowserDialog();
            var dialogResult = fb.ShowDialog();
            if (dialogResult == DialogResult.OK && Directory.Exists(fb.SelectedPath))
            {
                if(Directory.GetFiles(fb.SelectedPath).Any(x => x.Contains("Audiosurf2.exe")))
                {
                    locationTextBox.Text = fb.SelectedPath;
                    installBtn.Enabled = true;
                }
                else
                {
                    statusLabel.Text = "Couldn't find Audiosurf2.exe in selected folder";
                    locationTextBox.Text = "";
                }
            }
            else
            {
                statusLabel.Text = "Couldn't find Audiosurf 2 location";
                locationTextBox.Text = "";
            }
        }

        private async void installBtn_Click(object sender, EventArgs e)
        {
            locationGroupBox.Enabled = false;
            installBtn.Enabled = false;
            //Stages: 0 = Running Check, 1 = Downloading, 2 = Validating, 3 = Installing, 4 = Done
            #region Game Running Check
            statusLabel.Text = "Stage 1/5 - Checking if game is running...\n";
            var procs = Process.GetProcessesByName("Audiosurf2");
            if (procs.Length != 0)
            {
                statusLabel.Text += "Audiosurf 2 is running, closing it";
                foreach (var process in procs)
                {
                    process.Kill();
                }
            }
            #endregion
            await Task.Delay(2500);
            
            #region Downloading
            statusLabel.Text = "Stage 2/5 - Downloading...\n";
            var client = new HttpClient();
            Stream data = default;
            try
            {
                var response = await client.GetAsync("https://files.audiosurf2.info/newpatch/audiosurf2_community_patch.zip", HttpCompletionOption.ResponseHeadersRead);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var resultStream = new MemoryStream();
                    long bytesReceived = 0;
                    byte[] buffer = new byte[8192];
                    int read;
                    while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await resultStream.WriteAsync(buffer, 0, read);
                        var totalBytes = response.Content.Headers.ContentLength;
                        bytesReceived += (long)read;
                        var percentComplete = ((double)bytesReceived / totalBytes) * 100;
                        statusLabel.Text = "Stage 2/5 - Downloading...\n" +
                            $"{percentComplete.Value.ToString("#.##")}% complete";
                        statusProgressBar.Value = (int)percentComplete * 100;
                    }
                    resultStream.Position = 0;
                    data = resultStream;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Stage 2/5 - Downloading...\n" +
                    "Error downloading patch:\n" + ex.Message;
                return;
            }
            #endregion
            await Task.Delay(2500);
            
            #region Validating
            statusLabel.Text = "Stage 3/5 - Validating...\n";
            statusProgressBar.Value = 0;
            try
            {
                var serverHash = await client.GetStringAsync("https://files.audiosurf2.info/newpatch/updater/hash.txt");
                statusProgressBar.Value = 5000;
                var dataShaBytes = SHA256.Create().ComputeHash(data);
                var dataSHA = BitConverter.ToString(dataShaBytes).Replace("-", "").ToLower();
                if (serverHash != dataSHA)
                {
                    statusLabel.Text = "Stage 3/5 - Validating...\n" +
                        "Patch archive is invalid, please try again";
                    return;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Stage 3/5 - Validating...\n" +
                    "Error validating patch archive:\n" + ex.Message;
                return;
            }
            statusProgressBar.Value = 10000;
            #endregion
            await Task.Delay(2500);
            
            #region Installing
            statusLabel.Text = "Stage 4/5 - Installing...\n";
            statusProgressBar.Value = 0;
            try
            {
                var zip = new ZipArchive(data);
                var entriesCount = zip.Entries.Count;
                statusProgressBar.Maximum = entriesCount;
                var entriesCompleted = 0;
                var ordered = zip.Entries.OrderByDescending(x => x.FullName.EndsWith("\\"));
                foreach (var item in ordered)
                {
                    var winPath = item.FullName.Replace("/", "\\");
                    if (winPath.EndsWith("\\"))
                    {
                        if (!Directory.Exists(Path.Combine(locationTextBox.Text, winPath)))
                        {
                            Directory.CreateDirectory(Path.Combine(locationTextBox.Text, winPath));
                        }
                    }
                    else
                    {
                        var itemStream = item.Open();
                        var file = Path.Combine(locationTextBox.Text, winPath);
                        using (var fileStream = File.Create(file))
                        {
                            await itemStream.CopyToAsync(fileStream);
                        }
                    }
                    entriesCompleted++;
                    statusProgressBar.Value = entriesCompleted;
                }
            }
            catch (Exception ex)    
            {
                statusLabel.Text = "Stage 4/5 - Installing...\n" +
                    "Error installing patch:\n" + ex.Message;
            }
            #endregion
            await Task.Delay(2500);

            #region Done
            statusLabel.Text = "Stage 5/5 - Done!\n";            
            #endregion
            locationGroupBox.Enabled = true;
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(locationTextBox.Text))
                return;
            if (!Directory.GetFiles(locationTextBox.Text).Any(x => x.Contains("Audiosurf2.exe")))
                return;
            locationTextBox.Text = locationTextBox.Text;
            installBtn.Enabled = true;
        }
    }
}
