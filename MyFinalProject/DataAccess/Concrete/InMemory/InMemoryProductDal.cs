using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;//global değişken
        public InMemoryProductDal()
        {    //proje çalıştırıldığında listelenecek olan ürünler
            _products = new List<Product> {
                new Product{ ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
                new Product{ ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
                new Product{ ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
                new Product{ ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
                new Product{ ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitInStock=1}


            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product);//bu şekilde silinmez çünkü referansları aynı olmuyor.Ürünleri referans olarak newlemiştik
            //Linq kullanmadan silme
            Product productToDelete = null;
            /* 
             foreach (var p in _products)
             {
                 if (product.ProductId == p.ProductId) {
                     productToDelete = p;
                 }
             }
             _products.Remove(productToDelete);*/
            //LİNQ-Language Integreted Query(Dile gömülü sorgulama)
            //=>lambda                                  //p o an dolaştığım ürün,her p için referanla gönderdiğimiz productıd yi karşılaştır
            productToDelete = _products.SingleOrDefault(p=>product.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ıd sine sahip ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => product.ProductId == product.ProductId);
            product.ProductName = product.ProductName;
            product.CategoryId = product.CategoryId;
            product.UnitPrice = product.UnitPrice;
            product.UnitInStock = product.UnitInStock;   
        }

        public List<Product> GetAllByCategory(int categoryId) {
            //kategory idlere göre listeliyor
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
