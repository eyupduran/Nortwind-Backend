using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            ///oracle,sql server, posgres , mongoDb den geliyormuş gibi
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {    //LINQ- Language Integrated Query - dile gömülü sorgulama
            //liste bağlı sorguları sql gibi filreleriz
            // _products.Remove(product);//bu şekilde silinmez çünkü referanslar aynı olmuyor
            //linq olmadan ürün silme
            //Product productToDelete = null;
            /* foreach (var p in _products)//gönderilen produvctın ID  ile tüm ürünlerin ıdleri karşılaştırılacak 
             {
                 if (product.ProductId==p.ProductId) {
                     productToDelete = p;
                 }
             }*/
            //linq yardımıyla ürün silme
            //=> lambda
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//p tek tek dolaşırken verilen takma isim foreach gibi
                                                                                                   //foreach gibi
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {  //gönderidiğim ürün id sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
        public List<Product> GetAllByCategory(int categoryId) 
        {   //where komutu içinde bulunan şartı sağlayan bütün elemanları bir liste haline getirip onu döndürü
           return _products.Where(p=>p.CategoryId == categoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
