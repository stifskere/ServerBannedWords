using PluginAPI.Interfaces;

namespace ServerBannedWords
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string HintMessage { get; set; } = "<color=#FF0000>This word is not allowed in this server</color>";
        public string[] BannedWords { get; set; } = { "Fuck", "Shit" };
    }
}