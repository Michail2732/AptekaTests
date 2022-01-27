using AptekaTest.Commands;
using AptekaTest.Commands.Services;
using AptekaTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Необходимо указать строку подключения в кавычках");
                return;
            }
            CommandExecutorBuilder commandBuilder = new CommandExecutorBuilder();
            var commandExecutor = commandBuilder.Build(args.First());
            Console.WriteLine("Тестовое задание АО \"СПАРГО ТЕХНОЛОГИИ\"\n");
            Console.WriteLine("help - список команд\n");
            while (true)
            {
                Console.WriteLine("Введите команду\n");
                string input = Console.ReadLine();
                var parceResult = InputStringParcer.Parce(input);
                if (!parceResult.IsSuccess)
                { Console.WriteLine(parceResult.Error); continue; }
                var commandInfo = new CommandInfo(parceResult.Name, parceResult.Parameters);
                if (!commandExecutor.CanExecute(commandInfo, out var error))
                    Console.WriteLine(error);
                else
                    Console.WriteLine(await commandExecutor.ExecuteAsync(commandInfo));                
            }
        }
    }
}
