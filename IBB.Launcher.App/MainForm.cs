using IBB.Launcher.Console;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBB.Launcher.App
{
    public partial class MainForm : Form
    {
        IniFile configFile = new IniFile("Settings.ini");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MinecraftFolderPath.Text = configFile.Read("MinecraftFolder", "UserConfig");
            MinecraftExePath.Text = configFile.Read("MinecraftExe", "UserConfig");
            SaveButton.Focus();
        }

        private void SearchMinecraftFolderButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog getFolder = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Selecione a pasta"
            };

            if (getFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MinecraftFolderPath.Text = getFolder.FileName;
            }
        }

        private void SearchMinecraftExeButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog getExe = new OpenFileDialog())
            {
                getExe.Title = "Escolher Launcher de Minecraft";
                getExe.DefaultExt = "exe";
                getExe.Filter = "Arquivo Executável (*.exe)|*.exe|Arquivo do Java (*.jar)|*.jar";
                getExe.CheckFileExists = true;
                getExe.CheckPathExists = true;
                getExe.Multiselect = false;

                if (getExe.ShowDialog() == DialogResult.OK)
                {
                    MinecraftExePath.Text = getExe.FileName;
                }
            }
        }

        private void ToolsListMenu_DoubleClick(object sender, EventArgs e)
        {
            if (ToolsListMenu.SelectedItem != null)
            {
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = Application.StartupPath + @"\IBB.Launcher.Console.exe";

                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = false;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                pProcess.StartInfo.CreateNoWindow = false;

                switch (ToolsListMenu.SelectedIndex)
                {
                    // Apenas validar conexão com o servidor
                    case 0:
                        pProcess.StartInfo.Arguments = "-check-connection";
                        break;

                    // Verificar atualizações do launcher
                    case 1:
                        pProcess.StartInfo.Arguments = "-check-launcher-updates";
                        break;

                    // Verificar atualizações dos mods
                    case 2:
                        pProcess.StartInfo.Arguments = "-check-mod-updates";
                        break;

                    // Forçar e baixar atualizações dos mods
                    case 3:
                        pProcess.StartInfo.Arguments = "-force-game-update";
                        break;

                    // Deletar todos os logs
                    case 4:
                        pProcess.StartInfo.Arguments = "-clean-logs";
                        break;

                    // Deletar todos os mods
                    case 5:
                        pProcess.StartInfo.Arguments = "-delete-all-mods";
                        break;

                    // Checar e inverter pastas temporárias
                    case 6:
                        pProcess.StartInfo.Arguments = "-check-and-invert-temp-path";
                        break;
                }

                pProcess.Start();
                pProcess.WaitForExit();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            configFile.Write("MinecraftFolder", MinecraftFolderPath.Text, "UserConfig");
            configFile.Write("MinecraftExe", MinecraftExePath.Text, "UserConfig");
            Application.Exit();
        }

        private void IBBLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("IBBCraft v" + Application.ProductVersion + "\n" +
                "Desenvolvido por Gustavo Ribeiro\n\n" +
                "https://brasilball.com.br\n" +
                "https://plixcloud.com.br",
                "Sobre o IBBCraft",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
