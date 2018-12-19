using AsukaBot_2._0.Classes;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.CustomCommand
{
    public abstract class CustomCommandBase
    {
        public CCType myCCType;
        public string CommandName;
        public string Creator;

        public abstract void ExecuteCommand(ISocketMessageChannel channel);
        
    }

    public class CustomCommandText : CustomCommandBase
    {
        public string TextReturnCommand;

        public CustomCommandText(string command, string ReturnTextType, CCType _ccType, string _creator)
        {
            myCCType = _ccType;
            CommandName = command;
            TextReturnCommand = ReturnTextType;
            Creator = _creator;
        }

        public override void ExecuteCommand(ISocketMessageChannel channel)
        {
            channel.SendMessageAsync(TextReturnCommand);
        }
    }

    public enum CCType
    {
        Text, UserChange
    }
}
