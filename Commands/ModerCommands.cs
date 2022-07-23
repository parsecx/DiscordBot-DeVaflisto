using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBot.Commands
{
    public class ModerCommands :BaseCommandModule 
    {
        [Command("AddForbiddenWords")]
        [Description("Add all words that u want to ban for")]
        public async Task AddForbiddenWords(CommandContext ctx,[Description("Use coma as separator(no spaces)")]string par)
        {
            string[] arr = par.Split(',');
            var bot = new Bot();
            var jsonConfig = await bot.JsonGetter();
            foreach(string item in arr)
            {
                jsonConfig.Words.Append<string>(item);
            }
            string output = JsonConvert.SerializeObject(jsonConfig, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("jsconfig.json", output);
            await ctx.Channel.SendMessageAsync(jsonConfig.Data);
        }
        [Command("ChangeLine")]
        public async Task ChangeLine(CommandContext ctx, string line)
        {
            var bot = new Bot();
            var jsonConfig = await bot.JsonGetter();
            jsonConfig.Data = line;
            string output = JsonConvert.SerializeObject(jsonConfig, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("jsconfig.json", output);
            await ctx.Channel.SendMessageAsync(jsonConfig.Data);
        }
    }
}
