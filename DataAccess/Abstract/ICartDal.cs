using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        CartDto getByUserIdTotalCartPrice(Expression<Func<CartDto, bool>> filter = null);

        List<CartWithProductDto> GetAllByUserIdCartWithItemDto(Expression<Func<CartWithProductDto, bool>> filter = null);
    }
}

