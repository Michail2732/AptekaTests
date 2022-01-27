using AptekaTest.DAL.Gateways;
using AptekaTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class GetPharmaciesCommand : ConsoleCommand
    {
        private readonly IPharmaciesGateway _pharmaciesGateway;

        public GetPharmaciesCommand(IPharmaciesGateway pharmaciesGateway) : base(CommandBuildInfoRegistry.GetPharmacies)
        {
            _pharmaciesGateway = pharmaciesGateway ?? throw new ArgumentNullException(nameof(pharmaciesGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                var pharmacies = await _pharmaciesGateway.GetAllAsync();
                return new ExecuteResult(true, string.Join("\n", pharmacies.Select(a => a.ToFormatString())));
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }
    }
}
