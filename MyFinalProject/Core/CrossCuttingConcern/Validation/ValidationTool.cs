using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool //newlememek için
    {      //validation için genel bir yapı kurduk
        public static void Validate(IValidator validator,object entity) {
            var context = new ValidationContext<object>(entity);//product için doğrulama
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
