using AptekaTest.DAL.Gateways;
using AptekaTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class GetProductsCommand : ConsoleCommand
    {
        private readonly IProductsGateway _productsGateway;

        public GetProductsCommand(IProductsGateway productsGateway): base(CommandBuildInfoRegistry.GetProducts)
        {
            _productsGateway = productsGateway ?? throw new ArgumentNullException(nameof(productsGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                var products = await _productsGateway.GetAllAsync();
                return new ExecuteResult(true, string.Join("\n", products.Select(a => a.ToFormatString())));
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }
    }
}
