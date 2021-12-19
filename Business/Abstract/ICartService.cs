using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartService
    {
		IResult Add(Cart cart);

		IResult Delete(int id);

		IResult DecreaseAd(int userId, int productId);
		IResult IncreaseAd(int userId, int productId);
		IResult DecreaseKg(int userId, int productId);
		IResult IncreaseKg(int userId, int productId);

		IDataResult<List<Cart>> GetAllByUserId(int userId);

		IDataResult<CartDto> GetByUserIdTotalCartPrice(int userId);

		IDataResult<List<CartWithProductDto>> GetAllByUserIdAndCartStatusIsTrue(int userId);
		IDataResult<List<CartWithProductDto>> GetAllByUserIdAndCartStatusIsFalse(int userId);
	}
}
