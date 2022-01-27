using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekaTest.Commands
{
    public readonly struct ExecuteResult
    {
        public readonly bool IsSuccess;
        public readonly string Message;

        public ExecuteResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public static ExecuteResult Error(string error) => new ExecuteResult(false, error);
        public static ExecuteResult Success => new ExecuteResult(true, string.Empty);        

        public override string ToString()
        {            
            return string.Format("[Статус выполнения: {0}]\n{1}", IsSuccess ? "Удачно" : "Ошибка", Message);
        }
    }
}
