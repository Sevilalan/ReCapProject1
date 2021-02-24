using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{ 
    //temel voidler için başlangıç
  public   interface IResult
    {
        bool Success { get; }  //örneğin yapmaya çalıştığın ekleme işi başarılı/baiarısız (true/false) arkadaşım.
        string Message { get; } //örneğin yapmaya çalıştığın işlem başarılı kullanıcıya da 'ürün eklendi' gibi mesaj verir.

    }
}
