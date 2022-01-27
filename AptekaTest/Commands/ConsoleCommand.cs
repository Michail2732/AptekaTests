using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public abstract class ConsoleCommand
    {
        public string[] RequiredParameters { get; private set;}
        public string[] OptionalParameters { get; private set;}
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected ConsoleCommand(CommandBuildInfo buildInfo)
        {
            RequiredParameters = buildInfo.RequiredParameters;
            Name = buildInfo.Name;
            Description = buildInfo.Description;
            OptionalParameters = buildInfo.OptionalParameters;
        }

        public abstract Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters);        

        public virtual bool ValidateParameters(IDictionary<string, string> parameters, out string error)
        {            
            StringBuilder sb = new StringBuilder();
            foreach (var param in RequiredParameters)
                if (!parameters.ContainsKey(param))
                    sb.Append($"Отсутствует обязательный параметр: {param}\n");
            foreach (var param in parameters)            
                if (!RequiredParameters.Contains(param.Key) && !OptionalParameters.Contains(param.Key))
                    sb.Append($"Неизвестный параметр: {param.Key}\n");            
            error = sb.ToString(); 
            return sb.Length == 0; 

        }
    }
}
