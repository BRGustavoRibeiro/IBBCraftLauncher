using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBB.Launcher.Console
{
    public static class Constants
    {
        public static IniFile ConfigFile = new IniFile("Settings.ini");
        public static string GameFolder = @ConfigFile.Read("MinecraftFolder", "UserConfig");
        public static string GameRun = @ConfigFile.Read("MinecraftExe", "UserConfig");

        public static List<string> IBBMods = new List<string>
        {
            @"\IBB_mods",
            @"\IBB_Flan"
        };
    }
}
