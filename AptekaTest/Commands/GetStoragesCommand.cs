using AptekaTest.DAL.Gateways;
using AptekaTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class GetStoragesCommand : ConsoleCommand
    {
        private readonly IStorageGateway _storagesGateway;

        public GetStoragesCommand(IStorageGateway storagesGateway): base(CommandBuildInfoRegistry.GetStorages)
        {
            _storagesGateway = storagesGateway ?? throw new ArgumentNullException(nameof(storagesGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                var storages = await _storagesGateway.GetAllAsync();
                return new ExecuteResult(true, string.Join("\n", storages.Select(a => a.ToFormatString())));
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }
    }
}
