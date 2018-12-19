using AsukaBot_2._0.Classes;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.CustomCommand
{
    public class CustomCommandModule : ModuleBase<SocketCommandContext>
    {
        public static List<CustomCommandBase> customCommands;

        [Command("CC")]
        public async Task CustomCommandMethod([Remainder] string commandPara)
        {
            if (customCommands == null)
            {
                customCommands = new List<CustomCommandBase>();
            }
            string CommandWord = commandPara.Split(' ')[0];
            foreach(CustomCommandBase element in customCommands)
            {
                if(CommandWord == element.CommandName)
                {
                    element.ExecuteCommand(Context.Channel);
                }
            }
        }

        [Command("DCC")]
        public async Task DeleteCustomCommand([Remainder] string commandPara)
        {
            if (customCommands == null)
            {
                customCommands = new List<CustomCommandBase>();
            }

            string CommandWord = commandPara.Split(' ')[0];
            foreach (CustomCommandBase element in customCommands)
            {
                if (CommandWord == element.CommandName)
                {
                    customCommands.Remove(element);
                    await ReplyAsync("The command was deleted");
                    return;
                }
            }

        }

        [Command("CCC")]
        public async Task CreateCustomCommand([Remainder] string commandPara)
        {
            if (customCommands == null)
            {
                customCommands = new List<CustomCommandBase>();
            }

            string CommandWord = commandPara.Split(' ')[0];
            foreach (CustomCommandBase element in customCommands)
            {
                if (CommandWord == element.CommandName)
                {
                    await ReplyAsync("This command is already created, All custom commands are currently only temp");
                    return;
                }
            }

            //test command
            
            customCommands.Add(new CustomCommandText(CommandWord, commandPara.Replace(CommandWord, ""), CCType.Text, Context.Message.Author.Username));
            await ReplyAsync("The command " + CommandWord + " has created");
            CustomCommandSaveLoadere Save = new CustomCommandSaveLoadere();
            Save.SaveCCToFile(customCommands);
            //write code to make a new code
        }
    }
}
