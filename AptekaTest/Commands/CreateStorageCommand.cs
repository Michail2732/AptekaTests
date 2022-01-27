using AptekaTest.DAL.Gateways;
using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class CreateStorageCommand : ConsoleCommand
    {
        private readonly IStorageGateway _storagesGateway;

        public CreateStorageCommand(IStorageGateway storagesGateway): base(CommandBuildInfoRegistry.CreateStorage)
        {
            _storagesGateway = storagesGateway ?? throw new ArgumentNullException(nameof(storagesGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                int pharmacyId = int.Parse(parameters["phId"]);
                string name = parameters["name"];
                await _storagesGateway.AddAsync(new ShortStorage(0, pharmacyId, name));
                return ExecuteResult.Success;
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }

        public override bool ValidateParameters(IDictionary<string, string> parameters, out string error)
        {
            var baseRes = base.ValidateParameters(parameters, out error);
            if (!baseRes) return false;
            StringBuilder sb = new StringBuilder();
            if (!int.TryParse(parameters["phId"], out _))
                sb.Append($"Неверный формат значения параметра phId, ожидается Int32");
            error = sb.ToString();
            return sb.Length == 0;
        }
    }
}
