using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class CommandBuildInfo
    {
        public readonly string[] RequiredParameters;
        public readonly string[] OptionalParameters;
        public readonly string Name;
        public readonly string Description;

        public CommandBuildInfo(string[] requiredParameters, string name, string description, string[] optionalParameters = null)
        {
            RequiredParameters = requiredParameters ?? throw new ArgumentNullException(nameof(requiredParameters));
            OptionalParameters = optionalParameters ?? Array.Empty<string>();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }        
    }
}
