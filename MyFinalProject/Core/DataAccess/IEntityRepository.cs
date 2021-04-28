using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;   
using System.Text;
        //core katmanı diğer katmanları referans almaz ayrıca onlara bağımlı olmaz.
namespace Core.DataAccess //değiştirdik
{     //generic constraint--generic kısıt--> T yerine herşey yazılmasın sadece entities-concrete de bulunanlar yazılsın
      //IEntity : IEntity olabilir ya da IEntity implement eden bir nesne olabilir
      //IEntity newlenemediği için new yazıyoruz ki newlensin 
    public interface IEntityRepository<T> where T : class, IEntity, new()  //class dediğimiz referans tip demek yani int veremez
    {
        //category ve product için ayrı ayrı yapmaktansa generic tip ile çalışsak çok daha iyi olacaktır       
        //istediğimizde filterleme yapmak istediğimiz için böyle bir linq syntax ı yazdık
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);//burda filtre vermiyoruz.Bu yüzden tüm datayı getirir
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}