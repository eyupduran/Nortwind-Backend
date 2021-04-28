using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) { //params ile metodun içine istediğimiz kadar IResult parametresi verebiliriz
            foreach (var logic in logics)
            {
                if (!logic.Success) {//başarısız olan kuralı businessa bildiriyoruz
                    return logic;
                }
            }
            return null;
        }
    }
}
