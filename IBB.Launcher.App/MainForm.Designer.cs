namespace IBB.Launcher.App
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MinecraftFolderLabel = new System.Windows.Forms.Label();
            this.MinecraftFolderPath = new System.Windows.Forms.TextBox();
            this.StartupConfigPanel = new System.Windows.Forms.GroupBox();
            this.SearchMinecraftExeButton = new System.Windows.Forms.Button();
            this.MinecraftExePath = new System.Windows.Forms.TextBox();
            this.MinecraftExeLabel = new System.Windows.Forms.Label();
            this.SearchMinecraftFolderButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.IBBLink = new System.Windows.Forms.LinkLabel();
            this.ToolsPanel = new System.Windows.Forms.GroupBox();
            this.ToolsListMenu = new System.Windows.Forms.ListBox();
            this.StartupConfigPanel.SuspendLayout();
            this.ToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinecraftFolderLabel
            // 
            this.MinecraftFolderLabel.AutoSize = true;
            this.MinecraftFolderLabel.Location = new System.Drawing.Point(11, 28);
            this.MinecraftFolderLabel.Name = "MinecraftFolderLabel";
            this.MinecraftFolderLabel.Size = new System.Drawing.Size(83, 13);
            this.MinecraftFolderLabel.TabIndex = 0;
            this.MinecraftFolderLabel.Text = "Pasta .minecraft";
            // 
            // MinecraftFolderPath
            // 
            this.MinecraftFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinecraftFolderPath.Location = new System.Drawing.Point(100, 25);
            this.MinecraftFolderPath.Name = "MinecraftFolderPath";
            this.MinecraftFolderPath.Size = new System.Drawing.Size(229, 20);
            this.MinecraftFolderPath.TabIndex = 1;
            // 
            // StartupConfigPanel
            // 
            this.StartupConfigPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartupConfigPanel.Controls.Add(this.SearchMinecraftExeButton);
            this.StartupConfigPanel.Controls.Add(this.MinecraftExePath);
            this.StartupConfigPanel.Controls.Add(this.MinecraftExeLabel);
            this.StartupConfigPanel.Controls.Add(this.SearchMinecraftFolderButton);
            this.StartupConfigPanel.Controls.Add(this.MinecraftFolderLabel);
            this.StartupConfigPanel.Controls.Add(this.MinecraftFolderPath);
            this.StartupConfigPanel.Location = new System.Drawing.Point(12, 12);
            this.StartupConfigPanel.Name = "StartupConfigPanel";
            this.StartupConfigPanel.Padding = new System.Windows.Forms.Padding(15);
            this.StartupConfigPanel.Size = new System.Drawing.Size(417, 100);
            this.StartupConfigPanel.TabIndex = 2;
            this.StartupConfigPanel.TabStop = false;
            this.StartupConfigPanel.Text = "Configurações de Inicialização";
            // 
            // SearchMinecraftExeButton
            // 
            this.SearchMinecraftExeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchMinecraftExeButton.Location = new System.Drawing.Point(335, 56);
            this.SearchMinecraftExeButton.Name = "SearchMinecraftExeButton";
            this.SearchMinecraftExeButton.Size = new System.Drawing.Size(64, 23);
            this.SearchMinecraftExeButton.TabIndex = 5;
            this.SearchMinecraftExeButton.Text = "Procurar";
            this.SearchMinecraftExeButton.UseVisualStyleBackColor = true;
            this.SearchMinecraftExeButton.Click += new System.EventHandler(this.SearchMinecraftExeButton_Click);
            // 
            // MinecraftExePath
            // 
            this.MinecraftExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinecraftExePath.Location = new System.Drawing.Point(100, 58);
            this.MinecraftExePath.Name = "MinecraftExePath";
            this.MinecraftExePath.Size = new System.Drawing.Size(229, 20);
            this.MinecraftExePath.TabIndex = 4;
            // 
            // MinecraftExeLabel
            // 
            this.MinecraftExeLabel.AutoSize = true;
            this.MinecraftExeLabel.Location = new System.Drawing.Point(11, 61);
            this.MinecraftExeLabel.Name = "MinecraftExeLabel";
            this.MinecraftExeLabel.Size = new System.Drawing.Size(72, 13);
            this.MinecraftExeLabel.TabIndex = 3;
            this.MinecraftExeLabel.Text = ".EXE do Jogo";
            // 
            // SearchMinecraftFolderButton
            // 
            this.SearchMinecraftFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchMinecraftFolderButton.Location = new System.Drawing.Point(335, 23);
            this.SearchMinecraftFolderButton.Name = "SearchMinecraftFolderButton";
            this.SearchMinecraftFolderButton.Size = new System.Drawing.Size(64, 23);
            this.SearchMinecraftFolderButton.TabIndex = 2;
            this.SearchMinecraftFolderButton.Text = "Procurar";
            this.SearchMinecraftFolderButton.UseVisualStyleBackColor = true;
            this.SearchMinecraftFolderButton.Click += new System.EventHandler(this.SearchMinecraftFolderButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(313, 288);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(116, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Salvar e Fechar";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(236, 288);
            this.CloseButton.Name = "CancelButton";
            this.CloseButton.Size = new System.Drawing.Size(71, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Cancelar";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // IBBLink
            // 
            this.IBBLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IBBLink.AutoSize = true;
            this.IBBLink.Location = new System.Drawing.Point(9, 293);
            this.IBBLink.Name = "IBBLink";
            this.IBBLink.Size = new System.Drawing.Size(86, 13);
            this.IBBLink.TabIndex = 5;
            this.IBBLink.TabStop = true;
            this.IBBLink.Text = "Sobre o IBBCraft";
            this.IBBLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IBBLink_LinkClicked);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsPanel.Controls.Add(this.ToolsListMenu);
            this.ToolsPanel.Location = new System.Drawing.Point(12, 118);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(417, 151);
            this.ToolsPanel.TabIndex = 7;
            this.ToolsPanel.TabStop = false;
            this.ToolsPanel.Text = "Ferramentas";
            // 
            // ToolsListMenu
            // 
            this.ToolsListMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsListMenu.FormattingEnabled = true;
            this.ToolsListMenu.Items.AddRange(new object[] {
            "Apenas validar conexão com o servidor",
            "Verificar atualizações do launcher",
            "Verificar atualizações dos mods",
            "Forçar e baixar atualizações dos mods",
            "Deletar todos os logs",
            "Deletar todos os mods",
            "Checar e inverter pastas temporárias"});
            this.ToolsListMenu.Location = new System.Drawing.Point(6, 19);
            this.ToolsListMenu.Name = "ToolsListMenu";
            this.ToolsListMenu.Size = new System.Drawing.Size(405, 121);
            this.ToolsListMenu.TabIndex = 0;
            this.ToolsListMenu.DoubleClick += new System.EventHandler(this.ToolsListMenu_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 323);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.IBBLink);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartupConfigPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações do IBBCraft Launcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StartupConfigPanel.ResumeLayout(false);
            this.StartupConfigPanel.PerformLayout();
            this.ToolsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MinecraftFolderLabel;
        private System.Windows.Forms.TextBox MinecraftFolderPath;
        private System.Windows.Forms.GroupBox StartupConfigPanel;
        private System.Windows.Forms.Button SearchMinecraftExeButton;
        private System.Windows.Forms.TextBox MinecraftExePath;
        private System.Windows.Forms.Label MinecraftExeLabel;
        private System.Windows.Forms.Button SearchMinecraftFolderButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.LinkLabel IBBLink;
        private System.Windows.Forms.GroupBox ToolsPanel;
        private System.Windows.Forms.ListBox ToolsListMenu;
    }
}

