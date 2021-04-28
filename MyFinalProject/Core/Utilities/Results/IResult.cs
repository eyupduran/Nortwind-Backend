using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult
    { 
        //işlemin başarılı olup olmadığını ayrıca bir mesaj döndüren özellikler
        bool Success { get; } //sadece okunmak için
        string Message { get; }
    }
}
