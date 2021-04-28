using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success, string message) : this(success)//böyle yapmamızdaki amaç her iki constructor da birlikte çalışsın
        {
            Message = message;
           // Success = success; //bunu siliyoruz
        }
        public Result(bool success)//mesaj göndermek istemiyorsak constructora overloading uyguladık
        {
            Success = success;
        }

        
    }
}
