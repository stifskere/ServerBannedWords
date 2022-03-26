using System;
using PluginAPI;
using PluginAPI.Enums;
using PluginAPI.Interfaces;
using PluginAPI.Events;
using PluginAPI.Events.EventArgs;

namespace ServerBannedWords
{
    public class ServerBannedWords : Plugin<PluginConfig>
    {
        public override string Author => "Memw#6969";
        public override string Name => "ServerBannedWords";
        public override PluginType Type => PluginType.Moderation;
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Log.Info("Add the banned words in the config file for the plugin");
            PlayerEvents.PlayerChat += OnChat;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Log.Info("The plugin is disabled, enable it in the config file for the plugin");
            PlayerEvents.PlayerChat -= OnChat;
        }

        public void OnChat(PlayerChatEvent ev)
        {
            if (ev.Finalized)
            {
                return;
            }

            foreach (string bannedWord in Config.BannedWords)
            {
                if (ev.Message.ToLower().Contains(bannedWord.ToLower()))
                {
                    ev.Disallow();
                    ev.Player.SendPlayerChatMessage(Config.HintMessage);
                }
            }
        }
    }

    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string HintMessage { get; set; } = "<color=#FF0000>This word is not allowed in this server</color>";
        public string[] BannedWords { get; set; } = { "Fuck", "Shit" };
    }
}