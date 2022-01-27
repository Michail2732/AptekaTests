using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand(): base(CommandBuildInfoRegistry.Help)
        {

        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            string commands = string.Join("\n", CommandBuildInfoRegistry.CommandBuildInfos.Select(a => $"\n\t{a.Name}: {a.Description}"));
            return new ExecuteResult(true, commands);
        }
    }
}
