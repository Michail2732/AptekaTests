using AptekaTest.DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class DeleteStorageCommand : ConsoleCommand
    {
        private readonly IStorageGateway _storagesGateway;

        public DeleteStorageCommand(IStorageGateway storagesGateway): base(CommandBuildInfoRegistry.DeleteStorage)
        {
            _storagesGateway = storagesGateway ?? throw new ArgumentNullException(nameof(storagesGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                int id = int.Parse(parameters["Id"]);
                await _storagesGateway.DeleteAsync(id);
                return ExecuteResult.Success;
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }

        public override bool ValidateParameters(IDictionary<string, string> parameters, out string error)
        {
            var baseRes = base.ValidateParameters(parameters, out error);
            if (!baseRes) return false;
            if (!int.TryParse(parameters["Id"], out _))
            {
                error = $"Неверный формат значения параметра Id, ожидается Int32";
                return false;
            }
            return true;
        }

    }
}
