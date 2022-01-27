using AptekaTest.DAL.Gateways;
using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class CreatePharmacyCommand : ConsoleCommand
    {
        private readonly IPharmaciesGateway _pharmaciesGateway;

        public CreatePharmacyCommand(IPharmaciesGateway pharmaciesGateway) : base(CommandBuildInfoRegistry.CreatePharmacy)
        {
            _pharmaciesGateway = pharmaciesGateway ?? throw new ArgumentNullException(nameof(pharmaciesGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                string name = parameters["name"];
                string adress = parameters["adress"];
                string phone = parameters["phone"];
                await _pharmaciesGateway.AddAsync(new ShortPharmacy(0, name, adress, phone));
                return ExecuteResult.Success;
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }        
    }
}
