using System;
using PluginAPI;
using PluginAPI.Enums;
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
            PlayerEvents.PlayerChat -= OnChat;
        }

        private void OnChat(PlayerChatEvent ev)
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
                    ev.Player.SendChatMessage(Config.HintMessage.Replace("%BANNEDWORD%", bannedWord.ToLower()));
                }
            }
        }
    }
}
