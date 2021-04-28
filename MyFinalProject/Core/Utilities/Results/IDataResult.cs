using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult//böyle yaptık çünkü döndüreceği tip haricinde mesaj ya da true false döndürebilsin
    {
        T Data { get; }
    }
}
