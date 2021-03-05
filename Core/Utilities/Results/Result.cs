using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {//voidler için
        public Result(bool success)
        {           
            Success = success;//getterlı yere set atabilir
        }
        // bu sayede buraya 2 parametre gönderilince this ile bu sınıfta tek parametreliyi consu da çağırmış oluruz
        public Result(bool success, string message) : this(success) 
        {
            Message = message; //getterlı yere set atabilir
        }

        public bool Success { get; }

        public string Message { get; } //read-only olsa da contructerlar set edebiliyor

    }
}
