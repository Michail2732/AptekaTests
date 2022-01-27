using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Utils
{
    public readonly struct ParceResult
    {
        public readonly string Name;
        public readonly IDictionary<string, string> Parameters;
        public readonly bool IsSuccess;        
        public readonly string Error;

        public ParceResult(string name, IDictionary<string, string> parameters)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            IsSuccess = true;
            Error = null;
        }

        public ParceResult(string error)
        {
            Error = error;
            IsSuccess = false;
            Name = null;
            Parameters = null;
        }
    }
}
