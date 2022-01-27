using AptekaTest.DAL.Gateways;
using AptekaTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public sealed class CreateBatchCommand : ConsoleCommand
    {        
        private readonly IBatchesGateway _batchesGateway;

        public CreateBatchCommand(IBatchesGateway batchesGateway) : base(CommandBuildInfoRegistry.CreateBatch)
        {
            _batchesGateway = batchesGateway ?? throw new ArgumentNullException(nameof(batchesGateway));            
        }        

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {                
                int productId = int.Parse(parameters["pId"]);
                int storageId = int.Parse(parameters["sId"]);                
                uint count = uint.Parse(parameters["count"]);
                await _batchesGateway.AddAsync(new ShortBatch(0, productId, storageId, count));
                return ExecuteResult.Success;
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }            
        }

        public override bool ValidateParameters(IDictionary<string, string> parameters, out string error)
        {
            var baseValidRes = base.ValidateParameters(parameters, out error);
            if (!baseValidRes) return false;
            StringBuilder sb = new StringBuilder();                       
            if (!int.TryParse(parameters["pId"], out _))
                sb.Append($"Неверный формат значения параметра pId, ожидается Int32");
            if (!int.TryParse(parameters["sId"], out _))
                sb.Append($"Неверный формат значения параметра sId, ожидается Int32");
            if (!int.TryParse(parameters["count"], out _))
                sb.Append($"Неверный формат значения параметра count, ожидается UInt");
            error = sb.ToString();
            return sb.Length == 0;
        }
    }
}
