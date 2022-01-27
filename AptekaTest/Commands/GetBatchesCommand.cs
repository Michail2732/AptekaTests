using AptekaTest.DAL.Gateways;
using AptekaTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public class GetBatchesCommand : ConsoleCommand
    {
        private readonly IBatchesGateway _batches;

        public GetBatchesCommand(IBatchesGateway batches): base(CommandBuildInfoRegistry.GetBatches)
        {
            _batches = batches ?? throw new ArgumentNullException(nameof(batches));
        }

        public override async Task<ExecuteResult> ExecuteAsync(IDictionary<string, string> parameters)
        {
            try
            {
                var batches = await _batches.GetAllAsync();
                return new ExecuteResult(true, string.Join("\n", batches.Select(a => a.ToFormatString())));
            }
            catch (Exception ex) { return ExecuteResult.Error($"Неизвестная ошибка: {ex.Message}"); }
        }
    }
}
