using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    internal class CommandBuildInfoRegistry
    {
        public readonly static string[][] _parameters = new[]
        {
            new[] { "pId", "sId", "count" },
            new[] { "Id"},
            new[] { "name" },
            new[] {"phId" },
            new[] { "name", "adress", "phone" },
            new[] { "phId", "name" },
        };

        public readonly static IReadOnlyList<CommandBuildInfo> CommandBuildInfos = new List<CommandBuildInfo>
        {
            new CommandBuildInfo(_parameters[0], "cbtch", "\n\tСоздание партии\n\t\t-pId - идентификатор товара\n\t\t-sId - идентификатор склада\n\t\t-count - колличество товара"),
            new CommandBuildInfo(_parameters[1], "dbtch", "\n\tУдаление партии\n\t\t-Id - идентификатор партии"),
            new CommandBuildInfo(_parameters[2], "cprct", "\n\tСоздание товара\n\t\t-name - наименование товара"),
            new CommandBuildInfo(_parameters[1], "dprct", "\n\tУдаление товара\n\t\t-Id - идентификатор товара"),
            new CommandBuildInfo(_parameters[3], "gphcyprs","\n\tПолучение списка товаров в аптеке\n\t\t-phId - идентификатор аптеки"),
            new CommandBuildInfo(_parameters[4], "cphcy", "\n\tСоздание аптеки\n\t\t-name - название аптеки\n\t\t-adress - адрес аптеки\n\t\t-phone - телефон аптеки"),
            new CommandBuildInfo(_parameters[1], "dphcy", "\n\tУдаление аптеки\n\t\t-Id - идентификатор аптеки"),
            new CommandBuildInfo(_parameters[5], "cstrg", "\n\tСоздание склада\n\t\t-phId - идентификатор аптеки\n\t\t-name - наименование склада"),
            new CommandBuildInfo(_parameters[1], "dstrg", "\n\tУдаление склада\n\t\t-Id - идентификатор склада"),
            new CommandBuildInfo(Array.Empty<string>(), "gprcts", "\n\tПолучение списка товаров"),
            new CommandBuildInfo(Array.Empty<string>(), "gphces", "\n\tПолучение списка аптек"),
            new CommandBuildInfo(Array.Empty<string>(), "gstrgs", "\n\tПолучение списка складов"),
            new CommandBuildInfo(Array.Empty<string>(), "gbtchs", "\n\tПолучение списка партий"),
            new CommandBuildInfo(Array.Empty<string>(), "help", "\nПолучение списка доступных комманд")
        };


        public readonly static CommandBuildInfo CreateBatch = CommandBuildInfos[0];
        public readonly static CommandBuildInfo DeleteBatch = CommandBuildInfos[1];
        public readonly static CommandBuildInfo CreateProduct = CommandBuildInfos[2];
        public readonly static CommandBuildInfo DeleteProduct = CommandBuildInfos[3];
        public readonly static CommandBuildInfo GetProductsFromPharmacy = CommandBuildInfos[4];
        public readonly static CommandBuildInfo CreatePharmacy = CommandBuildInfos[5];
        public readonly static CommandBuildInfo DeletePharmacy = CommandBuildInfos[6];
        public readonly static CommandBuildInfo CreateStorage = CommandBuildInfos[7];
        public readonly static CommandBuildInfo DeleteStorage = CommandBuildInfos[8];
        public readonly static CommandBuildInfo GetProducts = CommandBuildInfos[9];
        public readonly static CommandBuildInfo GetPharmacies = CommandBuildInfos[10];
        public readonly static CommandBuildInfo GetStorages = CommandBuildInfos[11];
        public readonly static CommandBuildInfo GetBatches = CommandBuildInfos[12];
        public readonly static CommandBuildInfo Help = CommandBuildInfos[13];
    }
}
