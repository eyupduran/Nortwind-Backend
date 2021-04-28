using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result//inheritance
    {                                           //ana clasın constructorunu çağırdık.Başarılı bir sonuç olduğu için böyle birşey yaptık
        public SuccessResult(string message) : base(true, message)
        {

        }

        public SuccessResult() : base(true)//parametre olmadığında default olarak true döndürecek olan yapı
        {

        }

    }
}
