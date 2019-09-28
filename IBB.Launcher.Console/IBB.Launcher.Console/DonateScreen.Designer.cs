namespace IBB.Launcher.Console
{
    partial class DonateScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateScreen));
            this.picPopUp = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPopUp)).BeginInit();
            this.SuspendLayout();
            // 
            // picPopUp
            // 
            this.picPopUp.BackColor = System.Drawing.Color.Teal;
            this.picPopUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPopUp.Location = new System.Drawing.Point(12, 12);
            this.picPopUp.Name = "picPopUp";
            this.picPopUp.Size = new System.Drawing.Size(716, 393);
            this.picPopUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPopUp.TabIndex = 0;
            this.picPopUp.TabStop = false;
            this.picPopUp.Click += new System.EventHandler(this.picPopUp_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(8, 419);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(355, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Você poderá fechar esta janela em 5 segundos...";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Gray;
            this.CloseButton.Enabled = false;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(616, 412);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(112, 30);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Fechar";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // DonateScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 454);
            this.ControlBox = false;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picPopUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonateScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IBBCraft Launcher";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DonateScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPopUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPopUp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Timer MainTimer;
    }
}