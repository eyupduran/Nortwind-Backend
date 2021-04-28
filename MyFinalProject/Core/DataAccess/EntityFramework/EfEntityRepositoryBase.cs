using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace Core.DataAccess.EntityFramework
{                                                                          //tabloyu zaten vermiştik
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
    where TEntity:class,IEntity,new() //genericlere kısıtlama yaptık
    where TContext: DbContext,new()
    {
        //NuGet
        public void Add(TEntity entity)
        {    //using yazmamızın sebebi northwind context ile işimiz bitince bellekten direk silinecek ve boşuna yer kaplamayacak
             //IDisponsaple pattern implemantation of c#
            using (TContext context = new TContext())
            {
                //entity northwind contexte bağla
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); //bu işlemleri yapar
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //entity northwind contexte bağla
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges(); //bu işlemleri yapar
            }
        }
        //tek bir data getirecek
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {    // DbContext deki tablolara bu filteri uyguluyor
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filtre null ise tüm elemanları listeye döndür: select* from products oluyor aslında
                //filtre varsa filtreleyip ver
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //entity northwind contexte bağla
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges(); //bu işlemleri yapar
            }
        }
    }
}
