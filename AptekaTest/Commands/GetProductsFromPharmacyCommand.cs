using AptekaTest.DAL.Gateways;
using AptekaTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class GetProductsFromPharmacyCommand : ConsoleCommand
    {
        private readonly IProductsGateway _productsGateway;

        public GetProductsFromPharmacyCommand(IProductsGateway productsGateway): base(CommandBuildInfoRegistry.GetProductsFromPharmacy)
        {
            _productsGateway = productsGateway ?? throw new ArgumentNullException(nameof(productsGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                int pharmacyId = int.Parse(parameters["phId"]);
                var result = await _productsGateway.GetAll(pharmacyId);
                return new ExecuteResult(true, string.Join("\n", result.Select(a => a.ToFormatString())));
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }

        public override bool ValidateParameters(IDictionary<string, string> parameters, out string error)
        {
            var baseValidRes = base.ValidateParameters(parameters, out error);
            if (!baseValidRes) return false;
            StringBuilder sb = new StringBuilder();
            if (!int.TryParse(parameters["phId"], out _))
            {
                error = $"Неверный формат значения параметра phId, ожидается Int32";
                return false;
            }
            return true;
        }
    }
}
