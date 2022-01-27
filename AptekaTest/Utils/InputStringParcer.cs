using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AptekaTest.Utils
{
    public class InputStringParcer
    {
        public static ParceResult Parce(string inputRow)
        {
            string commNameRegex = @"^\s*(?<name>[a-zA-Z0-9]+)";
            string parametersRegex = @"\-(?<paramName>[a-zA-Z]+)\s+((?<paramValue>[a-zA-Z0-9А-Яа-я]+)|"+"(?<paramValue>\"[^\"]+\"))";
            var commNameMatch = Regex.Match(inputRow, commNameRegex);
            var parametersMatch = Regex.Matches(inputRow, parametersRegex);
            if (!commNameMatch.Success)
                return new ParceResult($"Не распознанная команда: {inputRow}");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (parametersMatch.Count > 0)
                foreach (Match match in parametersMatch)
                    parameters[match.Groups["paramName"].Value] = match.Groups["paramValue"].Value.Trim('\"');
            return new ParceResult(commNameMatch.Value, parameters);
        }

    }
}
