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
    internal class ModerCommands :BaseCommandModule 
    {
        [Command("AddForbiddenWords")]
        [Description("Add all words that u want to ban for")]
        public async Task AddForbiddenWords([Description("Use coma as separator(no spaces)")]string par)
        {
            string[] arr = par.Split(',');
            var jsonConfig = await Bot.JsonGetter();
            foreach(string item in arr)
            {
                Vocab v = new()
                {
                    Word = item
                };
                jsonConfig.Words.Append(v);
            }
            string output = JsonConvert.SerializeObject(jsonConfig, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("jsconfig.json", output);
            return Task.CompletedTask;
        }
        
    }
}
