using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public interface ICommandExecutor
    {
        bool CanExecute(CommandInfo info, out string error);
        Task<ExecuteResult> ExecuteAsync(CommandInfo info);
    }
}
