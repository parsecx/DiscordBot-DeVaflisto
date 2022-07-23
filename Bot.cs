using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using AdminBot.Commands;

namespace AdminBot
{
    public class Bot
    {
        public DiscordClient? Client { get; private set; }
        public CommandsNextExtension? Commands { get; private set; }

        public async Task RunAsync()
        {

            ConfigJson configJson = await JsonGetter();
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands(typeof(ModerCommands));
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private Task OnClientReady(DiscordClient c, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
        public async Task<ConfigJson> JsonGetter()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("jsconfig.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            {
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            return configJson;
        }
    }
}
