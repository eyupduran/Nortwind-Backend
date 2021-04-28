using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //claim
        
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]//validation
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product) //IResult döndürmek istediğim halde result döndürmemde sıkıntı çıkmadı çünkü Iresult Resultın referansını tutuyor
        {      //business codes
               //Aynı isimde ürün eklenemez
               //eğer mevcut kategori sayısı 15 i geçtiyse sisiteme yeni ürün eklenemez
            var result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                 CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceed());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 25)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);//bakım zamanı
            }
            //iş kodları ifler
            //bir iş sınıfı başka sınıflasrı newlemez
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); ;//filtreleme
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //iki fiyat aralığında olan datayı getirir
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products  where categoryıd=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceed() {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15) {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }
        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            return null;
        }
    }
}
