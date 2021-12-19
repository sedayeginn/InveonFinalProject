using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
		IResult Add(Product product);

		IResult Delete(int id);

        IDataResult<List<Product>> GetCategory1Id(int cat1Id, int pageNo, int pageSize);

        IDataResult<Product> GetById(int id);

		IDataResult<List<Product>> GetAllCategory1Id(int cat1Id);

		IDataResult<List<Product>> GetByProductName(string productName);

        IDataResult<List<Product>> GetByProductNamePageable(string productName, int pageNo, int pageSize);
    }
}
