using AptekaTest.DAL;
using AptekaTest.DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands.Services
{
    public class CommandExecutorBuilder
    {
        public ICommandExecutor Build(string connection)
        {
            var dbConfiguration = new DbConfiguration(connection);
            var productGateway = new ProductsGateway(dbConfiguration);
            var pharmaciesGateway = new PharmaciesGateway(dbConfiguration);
            var storagesGateway = new StorageGateway(dbConfiguration);
            var batchesGateway = new BatchesGateway(dbConfiguration);
            var commands = new List<ConsoleCommand>
            {
                new CreateBatchCommand(batchesGateway),
                new CreatePharmacyCommand(pharmaciesGateway),
                new CreateProductCommand(productGateway),
                new CreateStorageCommand(storagesGateway),
                new DeleteBatchCommand(batchesGateway),
                new DeletePharmacyCommand(pharmaciesGateway),
                new DeleteProductCommand(productGateway),
                new DeleteStorageCommand(storagesGateway),
                new GetProductsFromPharmacyCommand(productGateway),
                new GetProductsCommand(productGateway),
                new GetPharmaciesCommand(pharmaciesGateway),
                new GetStoragesCommand(storagesGateway),
                new GetBatchesCommand(batchesGateway),
                new HelpCommand()
            };
            return new CommandExecutor(commands);
        }

    }
}
