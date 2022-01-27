using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class CommandExecutor: ICommandExecutor
    {
        private readonly List<ConsoleCommand> _commands;        

        public CommandExecutor(List<ConsoleCommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }        

        public bool CanExecute(CommandInfo info, out string error)
        {
            error = null;
            var matchCommand = _commands.FirstOrDefault(a => a.Name == info.Name);
            if (matchCommand == null)
            {
                error = $"Нераспознанная команда: {info.Name}";
                return false;
            }
            return matchCommand.ValidateParameters(info.Parameters, out error);      
        }

        public async Task<ExecuteResult> ExecuteAsync(CommandInfo info)
        {
            var matchCommand = _commands.FirstOrDefault(a => a.Name == info.Name &&
                info.Parameters.All(b => a.RequiredParameters.Contains(b.Key))) ??
                throw new CommandException($"Не распознанная команда: {info.Name}");
            return await matchCommand.ExecuteAsync(info.Parameters);
        } 
        
    }
}
