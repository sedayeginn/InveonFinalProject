using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(product.Id.ToString());
        }

        public IResult Delete(int id)
        {
            Product product = _productDal.Get(i => i.Id == id);
            _productDal.Delete(product);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IDataResult<List<Product>> GetAllCategory1Id(int cat1Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.Category1 == cat1Id));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(i => i.Id == id));
        }

        public IDataResult<List<Product>> GetByProductName(string productName)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.ProductName.Contains(productName)));
        }

        public IDataResult<List<Product>> GetByProductNamePageable(string productName, int pageNo, int pageSize)
        {
            int skipRows = (pageNo - 1) * pageSize;
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.ProductName.Contains(productName)).Skip(skipRows).Take(pageSize).ToList());
        }

        public IDataResult<List<Product>> GetCategory1Id(int cat1Id, int pageNo, int pageSize)
        {

            int skipRows = (pageNo - 1) * pageSize;

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.Category1 == cat1Id).Skip(skipRows).Take(pageSize).ToList());
        }
    }
}
