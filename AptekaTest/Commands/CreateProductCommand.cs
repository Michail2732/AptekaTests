using AptekaTest.DAL.Gateways;
using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class CreateProductCommand : ConsoleCommand
    {
        private readonly IProductsGateway _productGateway;

        public CreateProductCommand(IProductsGateway productGateway): base(CommandBuildInfoRegistry.CreateProduct)
        {
            _productGateway = productGateway ?? throw new ArgumentNullException(nameof(productGateway));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                string name = parameters["name"];
                await _productGateway.AddAsync(new ShortProduct(0, name));
                return ExecuteResult.Success;
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }        
    }
}
