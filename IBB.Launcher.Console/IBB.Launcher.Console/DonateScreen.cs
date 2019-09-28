using System;
using System.Net;
using System.Windows.Forms;

namespace IBB.Launcher.Console
{
    public partial class DonateScreen : Form
    {
        int count = 5;

        public DonateScreen()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DonateScreen_Load(object sender, EventArgs e)
        {
            picPopUp.Load("https://ibbcraft.brasilball.com.br/popup/live.png");
            MainTimer.Enabled = true;
            MainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            count--;
            lblStatus.Text = "Você poderá fechar esta janela em " + count + " segundos...";

            if(count <= 0)
            {
                CloseButton.BackColor = System.Drawing.Color.Maroon;
                CloseButton.Enabled = true;
                MainTimer.Enabled = false;
            }
        }

        private void picPopUp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new WebClient().DownloadString(new Uri("https://ibbcraft.brasilball.com.br/popup/link.url")));
        }
    }
}
