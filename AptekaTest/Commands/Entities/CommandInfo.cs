using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public readonly struct CommandInfo
    {
        public readonly string Name;
        public readonly IDictionary<string, string> Parameters;

        public CommandInfo(string name, IDictionary<string, string> parameters)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
    }
}
