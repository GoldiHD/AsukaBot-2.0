using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Module.Maths
{
    public class MathsMain : ModuleBase<SocketCommandContext>
    {
        [Command("cal")]
        public async Task Calulate([Remainder] string content)
        {

        }
    }
}
