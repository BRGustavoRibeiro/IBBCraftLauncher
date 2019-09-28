using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net.Http;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace IBB.Launcher.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Verifica se já existe um launcher sendo executado no momento
            var processRunning = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1;

            if (processRunning)
            {
                Speak("Já existe uma outra instância do IBBCraft Launcher sendo executada. Por favor, fuzile-a antes de executar uma nova.", SpeakType.Error);
                Environment.Exit(0); // Só pra garantir que o app vai ser fechado
            }

            System.Console.Title = "IBBCraft Launcher";
            
            Speak("-----------------------------------------------", ConsoleColor.Cyan);
            Speak("IBBCraft Launcher - v" + Assembly.GetExecutingAssembly().GetName().Version, ConsoleColor.Cyan);
            Speak("brasilball.com.br / " + DateTime.Now.Year + " © Gustavo Ribeiro", ConsoleColor.Cyan);
            Speak("-----------------------------------------------\n", ConsoleColor.Cyan);

            // Verifica se é uma inicialização de manutenção
            if (args.Count() <= 0)
            {
                RunNormalLaunch();
            }
            else
            {
                foreach (String str in args)
                {
                    switch (str)
                    {
                        case "-run-verbose":
                            ShowWindow(GetConsoleWindow(), SW_SHOW);
                            RunNormalLaunch();
                            break;

                        case "-check-connection":
                            CheckConnection();
                            break;

                        case "-force-game-update":
                            UpdateGame();
                            break;

                        case "-check-launcher-updates":
                            CheckLauncherUpdates();
                            break;

                        case "-check-mod-updates":
                            CheckModUpdates();
                            break;

                        case "-clean-logs":
                            DeleteGameLogs();
                            break;

                        case "-delete-all-mods":
                            DeleteAllMods();
                            break;

                        case "-check-and-invert-temp-path":
                            CheckAndInvertTempPath();
                            break;
                    }
                }

                AskToQuit();
            }
        }

        public static void RunNormalLaunch()
        {
            // Se não for, verifica se tem conexão com a internet
            if (CheckConnection())
            {
                Speak("Verificando se a pasta .minecraft existe...", SpeakType.Info);
                // Verifica se no .ini não tem nenhuma pasta definida
                if (Constants.GameFolder == "")
                {
                    Speak("Pasta inativa, procurando por instalações do Minecraft...", SpeakType.Info);

                    // Verifica se a pasta do .minecraft existe
                    string supposedMinecraftFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft";
                    if (Directory.Exists(supposedMinecraftFolder))
                    {
                        ConsoleKey option;
                        do
                        {
                            Speak("Pasta .minecraft existente em " + supposedMinecraftFolder + ". Deseja confirmar? S/N", SpeakType.Warning);
                            option = System.Console.ReadKey().Key;
                            System.Console.WriteLine();
                            if (option == ConsoleKey.S)
                            {
                                Constants.ConfigFile.Write("MinecraftFolder", supposedMinecraftFolder, "UserConfig");
                                Speak("Configuração salva com sucesso!", SpeakType.Done);
                                RestartLauncher();
                                break;
                            }
                            else if (option == ConsoleKey.N)
                            {
                                Speak("A pasta de execução está em branco. Para configurar, por favor use o Configurador do IBBCraft.", SpeakType.Error);
                                break; // Nunca vai entrar aqui
                            }
                        }
                        while (option != ConsoleKey.S || option != ConsoleKey.N);
                    }
                }
                else
                {
                    Speak("Pasta .minecraft definida nas configurações!", SpeakType.Done);

                    Speak("Verificando se a pasta é válida...", SpeakType.Info);
                    // Verifica se a pasta realmente existe
                    if (!Directory.Exists(Constants.GameFolder))
                    {
                        Speak("A pasta informada não existe. Por favor, use o Configurador do IBBCraft e escolha um diretório válido.", SpeakType.Error);
                    }
                    else
                    {
                        Speak("Pasta validada com sucesso!", SpeakType.Done);
                    }
                }

                Speak("Verificando se o executável do launcher existe...", SpeakType.Info);
                // Verifica se no .ini não tem nenhum executável definido
                if (Constants.GameRun == "")
                {
                    Speak("Executável não definido, procurando Minecraft original...", SpeakType.Info);

                    // Verifica se a pasta do launcher original existe
                    string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    List<string> supposedMinecraftRunnable = new List<string>
                        {
                            programFiles + @"\Minecraft\MinecraftLauncher.exe",
                            programFiles + @"\Minecraft Launcher\MinecraftLauncher.exe"
                        };

                    foreach (string path in supposedMinecraftRunnable)
                    {
                        if (File.Exists(path))
                        {
                            ConsoleKey option;
                            do
                            {
                                Speak("Executável " + path + " encontrado. Deseja confirmar? S/N", SpeakType.Warning);
                                option = System.Console.ReadKey().Key;
                                System.Console.WriteLine();
                                if (option == ConsoleKey.S)
                                {
                                    Constants.ConfigFile.Write("MinecraftExe", path, "UserConfig");
                                    Speak("Configuração salva com sucesso!", SpeakType.Done);
                                    RestartLauncher();
                                    break;
                                }
                                else if (option == ConsoleKey.N)
                                {
                                    Speak("O executável está em branco. Para configurar, por favor use o Configurador do IBBCraft.", SpeakType.Error);
                                    break; // Nunca vai entrar aqui
                                }
                            }
                            while (option != ConsoleKey.S || option != ConsoleKey.N);
                        }
                    }
                }
                else
                {
                    Speak("Executável do Minecraft definido nas configurações!", SpeakType.Done);

                    Speak("Verificando se o executável é válido...", SpeakType.Info);
                    // Verifica se o executável realmente existe
                    if(!File.Exists(Constants.GameRun))
                    {
                        Speak("O executável informado não existe. Por favor, use o Configurador do IBBCraft e escolha um executável válido.", SpeakType.Error);
                    }
                    else
                    {
                        Speak("Executável validado com sucesso!", SpeakType.Done);
                    }
                }

                // Verifica se há atualizações do launcher, e se tiver manda atualizar
                if (CheckLauncherUpdates())
                {
                    AskToQuit();
                }
                else
                {
                    // Verifica se existe pasta temporária em aberto no programa
                    CheckAndInvertTempPath();

                    // Verifica se o forge está instalado
                    InstallForge();

                    // Caso não tenham atualizações ou a pasta não exista, verifica updates no modpack
                    if (CheckModUpdates() || !Directory.Exists(Constants.GameFolder))
                    {
                        UpdateGame();
                    }

                    // Caso não tenha as pastas, baixa o game de novo
                    foreach (string path in Constants.IBBMods)
                    {
                        if (!Directory.Exists(Constants.GameFolder + @"\" + path))
                        {
                            UpdateGame();
                            break;
                        }
                    }

                    Speak("Tudo certo! Iniciando jogo!", SpeakType.Done);
                    try
                    {
                        foreach (string path in Constants.IBBMods)
                        {
                            string dirMod = Constants.GameFolder + @"\" + path.Substring(5);

                            if (Directory.Exists(dirMod))
                            {
                                // Move a PASTA DE MODS ATUAIS para a PASTA DE MODS TEMPORÁRIOS
                                Directory.Move(@dirMod, @Constants.GameFolder + @"\temp_old_" + @path.Substring(5));
                            }

                            // Move a PASTA DE MODS DA IBB para a PASTA DE MODS ATUAIS
                            Directory.Move(@Constants.GameFolder + @"\" + @path, @Constants.GameFolder + @"\" + @path.Substring(5));
                        }

                        ShowWindow(GetConsoleWindow(), SW_HIDE);

                        DonateScreen popupScreen = new DonateScreen();
                        popupScreen.ShowDialog();

                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = Constants.GameRun,
                                RedirectStandardOutput = false,
                                UseShellExecute = false,
                                CreateNoWindow = false
                            }
                        };

                        process.Start();
                        process.WaitForExit();

                        CheckAndInvertTempPath();
                        Environment.Exit(0);
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        Speak("O procedimento foi cancelado pelo usuário. O executável não pode ser iniciado.", SpeakType.Error);
                    }
                    catch (Exception ex)
                    {
                        Speak("Houve um erro enquanto tentávamos abrir o jogo. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
                    }

                    System.Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.ForegroundColor = ConsoleColor.Gray;
                    Environment.Exit(0);
                }
            }
            else
            {
                // Se não tiver conexão com a internet, manda fechar
                AskToQuit();
            }
        }

        public static void InstallForge()
        {
            try
            {
                string downloadedString = new WebClient().@DownloadString("https://ibbcraft.brasilball.com.br/download/forgelatest.txt");
                string versionOnServer = Constants.GameFolder + @"\versions\1.12.2-forge" + downloadedString;

                Speak("Verificando instalação do Forge (versão da IBB)", SpeakType.Info);
                if (!Directory.Exists(versionOnServer))
                {
                    Speak("Forge não instalado! Baixando versão da IBB...", SpeakType.Info);
                    new WebClient().DownloadFile("https://files.minecraftforge.net/maven/net/minecraftforge/forge/" + downloadedString + "/forge-" + downloadedString + "-installer-win.exe", Constants.GameFolder + @"\forge-" + downloadedString + "-installer-win.exe");
                    Speak("Forge baixado com sucesso! Instalador sendo executado...", SpeakType.Done);

                    System.Windows.Forms.MessageBox.Show("Atenção! Você precisará instalar o Forge Mod Loader. O instalador será aberto agora.\nClique em 'INSTALL CLIENT' e dê OK.", "Instalar Forge Mod Loader");
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = Constants.GameFolder + @"\forge-" + downloadedString + "-installer-win.exe",
                            RedirectStandardOutput = false,
                            UseShellExecute = false,
                            CreateNoWindow = false
                        }
                    };

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Speak("Houve um erro enquanto tentávamos verificar (e instalar) o Forge. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
            }
        }

        public static void CheckAndInvertTempPath()
        {
            Speak("Verificando existência de pastas temporárias abertas...", SpeakType.Info);
            try
            {
                foreach (string path in Constants.IBBMods)
                {
                    if (Directory.Exists(Constants.GameFolder + @"\temp_old_" + path.Substring(5)))
                    {
                        Speak("Pasta temporária de " + path.Substring(5) + " encontrada. Alterando para o estado normal...", SpeakType.Info);
                        RevertRename(path.Substring(5));
                        Speak("Pasta de " + path.Substring(5) + " alterada com sucesso!", SpeakType.Done);
                    }
                }
            }
            catch (Exception ex)
            {
                Speak("Houve um erro enquanto tentávamos verificar e fechar pastas temporárias abertas. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
            }
            Speak("Verificação finalizada!", SpeakType.Done);
        }

        public static void RestartLauncher()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        public static void DeleteGameLogs()
        {
            try
            {
                DeleteAndRecreateDirectory("logs");
            }
            catch (Exception ex)
            {
                Speak("Houve um erro ao tentar deletar os logs. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
            }
        }

        public static void DeleteAllMods()
        {
            try
            {
                foreach(string path in Constants.IBBMods)
                {
                    DeleteAndRecreateDirectory(path.Substring(0));
                }
                Speak("Arquivos deletados!", SpeakType.Done);
            }
            catch(Exception ex)
            {
                Speak("Houve um erro ao tentar deletar os mods. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
            }
        }

        public static bool CheckConnection()
        {
            try
            {
                Speak("Conectando a https://brasilball.com.br", SpeakType.Info);

                // Obriga o software a usar conexão TLS 1.2
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                HttpClient Client = new HttpClient();
                int StatusCode = (int)Client.GetAsync("https://brasilball.com.br").Result.StatusCode;

                if (StatusCode != 200)
                {
                    Speak("O launcher não recebeu um retorno 200 do servidor.", SpeakType.Error);
                    return false;
                }
                else
                {
                    Speak("Endereço recebido como 200. Servidor conectado.", SpeakType.Done);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Speak("Houve uma falha ao tentar se conectar ao servidor. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
                return false; // Nunca vai entrar aqui
            }
        }

        public static void UpdateGame()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string zipPath = Constants.GameFolder + @"\_IBBCraft_latest.zip";

                    // Verifica se o arquivo já existe e o remove
                    if (File.Exists(zipPath))
                    {
                        Speak("Arquivo já existente, sobrescrevendo...", SpeakType.Info);
                        File.Delete(zipPath);
                        Speak("Arquivo removido", SpeakType.Done);
                    }

                    DeleteAllMods();

                    Speak("Fazendo download da última versão...", SpeakType.Info);
                    client.DownloadFile(new Uri("http://ibbcraft.brasilball.com.br/download/latest.zip"), Constants.GameFolder + @"\_IBBCraft_latest.zip");
                    Speak("Última versão baixada!", SpeakType.Done);

                    Speak("Extraindo arquivos...", SpeakType.Info);
                    ZipFile.ExtractToDirectory(zipPath, Constants.GameFolder);
                    Speak("Arquivos extraídos com sucesso!", SpeakType.Done);

                    Speak("Deletando arquivos temporários...", SpeakType.Info);
                    File.Delete(zipPath);
                    Speak("Arquivos deletados com sucesso!", SpeakType.Done);

                    Speak("Alterando versão do modpack...", SpeakType.Info);
                    Constants.ConfigFile.Write("Modpack", new WebClient().DownloadString(new Uri("http://ibbcraft.brasilball.com.br/download/launcherlatest.txt")), "Software");
                    Speak("Versão alterada!", SpeakType.Done);
                }
            }
            catch (System.IO.IOException)
            {
                Speak("Existem arquivos a serem sobrescritos. Por favor, execute com o parâmetro -delete-all-mods.", SpeakType.Error);
            }
            catch (Exception ex)
            {
                Speak("Houve uma falha ao tentar realizar a atualização dos arquivos. Envie isso para a equipe da IBB.\n" + ex, SpeakType.Error);
            }
        }

        public static bool CheckLauncherUpdates()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    Speak("Verificando atualizações do launcher...", SpeakType.Info);
                    string latestVersion = client.DownloadString(new Uri("http://ibbcraft.brasilball.com.br/download/launcherlatest.txt"));

                    if (latestVersion == Assembly.GetExecutingAssembly().GetName().Version.ToString())
                    {
                        Speak("Última versão baixada!", SpeakType.Done);
                        return false;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Speak("Há uma nova versão disponível!", SpeakType.Warning);
                        Speak("Entre no site https://brasilball.com.br e baixe a versão " + latestVersion + " do IBBCraft Launcher.", SpeakType.Warning);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Speak("Houve um erro enquanto tentávamos verificar as atualizações do launcher. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
                return false; // Nunca vai entrar aqui
            }
        }

        public static bool CheckModUpdates()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    Speak("Verificando atualizações de mods...", SpeakType.Info);
                    string latestVersion = client.DownloadString(new Uri("http://ibbcraft.brasilball.com.br/download/modlatest.txt"));

                    if (latestVersion == Constants.ConfigFile.Read("Modpack", "Software"))
                    {
                        Speak("Última versão baixada!", SpeakType.Done);
                        return false;
                    }
                    else
                    {
                        Speak("Há uma nova versão disponível!", SpeakType.Info);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                Speak("Houve um erro enquanto tentávamos verificar novas atualizações de mods. Envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
                return false; // Nunca vai entrar aqui
            }
        }

        public enum SpeakType
        {
            Info,
            Done,
            Error,
            Warning,
            Default
        }

        public static void Speak(string message, SpeakType type = SpeakType.Default, ConsoleColor color = ConsoleColor.Black)
        {
            String toSay = "| > ";
            switch (type)
            {
                case SpeakType.Info:
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                    toSay += "INFORMAÇÃO";
                    break;

                case SpeakType.Done:
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    toSay += "SUCESSO";
                    break;

                case SpeakType.Error:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    toSay += "ERRO";
                    break;

                case SpeakType.Warning:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    toSay += "ATENÇÃO";
                    System.Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;

                case SpeakType.Default:
                default:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    toSay = "";
                    break;
            }

            if(color != ConsoleColor.Black)
            {
                System.Console.ForegroundColor = color;
            }

            toSay += " > " + message;

            System.Console.WriteLine(toSay);
            System.Console.BackgroundColor = ConsoleColor.Black;

            if(type == SpeakType.Error)
            {
                ShowWindow(GetConsoleWindow(), SW_SHOW);
                AskToQuit();
                Environment.Exit(0);
            }
        }

        public static void Speak(string message, ConsoleColor color = ConsoleColor.White)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
        }

        public static void DeleteAndRecreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(Constants.GameFolder + @"\" + @path))
                {
                    Speak("Pasta /" + path + " inexistente, pulando.", SpeakType.Info);
                }
                else
                {
                    Speak("Deletando pasta /" + path + "...", SpeakType.Info);
                    Directory.Delete(Constants.GameFolder + @"\" + @path, true);
                    Speak("Pasta /" + path + " deletada com sucesso!", SpeakType.Done);
                }

                Speak("Criando pasta /" + path + " novamente...", SpeakType.Info);
                Directory.CreateDirectory(Constants.GameFolder + @"\" + @path);
                Speak("Pasta /" + path + " criada com sucesso!", SpeakType.Done);
            }
            catch (Exception ex)
            {
                Speak("Houve um erro enquanto tentávamos deletar e recriar os respectivos diretórios. Por favor, envie isso para a equipe da IBB:\n" + ex, SpeakType.Error);
            }
        }

        // mods
        public static void RevertRename(string path)
        {
            if (!Directory.Exists(Constants.GameFolder + @"\" + @path))
            {
                Speak("Pasta /" + path + " inexistente, pulando.", SpeakType.Info);
            }
            else
            {
                // Move a PASTA DE MODS DA IBB para a PASTA DE MODS ATUAIS
                Directory.Move(@Constants.GameFolder + @"\" + @path, @Constants.GameFolder + @"\IBB_" + @path);

                // Move a PASTA DE MODS ATUAIS para a PASTA DE MODS TEMPORÁRIOS
                if(Directory.Exists(@Constants.GameFolder + @"\temp_old_" + @path))
                {
                    Directory.Move(@Constants.GameFolder + @"\temp_old_" + @path, @Constants.GameFolder + @"\" + @path);
                }
            }
        }

        public static void AskToQuit()
        {
            System.Console.WriteLine();
            Speak("Pressione qualquer tecla para fechar.", SpeakType.Info, ConsoleColor.Cyan);
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.ReadKey();
        }

        // Esconder tela do console
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
    }
}
