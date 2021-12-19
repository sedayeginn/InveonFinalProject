using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        IProductDal _productDal;

        public CartManager(ICartDal cartDal, IProductDal productDal)
        {
            _cartDal = cartDal;
            _productDal = productDal;
        }
        public IResult Add(Cart cart)
        {
            var cartItem = _cartDal.Get(c => c.UserId == cart.UserId && c.productId == cart.productId && c.CartStatus == true);
            var findItem = _productDal.Get(i => i.Id == cart.productId);
            if (cartItem != null)
            {
                var newCount = cartItem.Count + cart.Count;
                var newLineTotal = newCount * findItem.UnitPrice;
                cartItem.Count = newCount;
                cartItem.LineTotal = newLineTotal;
                _cartDal.Update(cartItem);
                return new SuccessResult("Sepet günellendi");
            }
            var newLineTotal2 = cart.Count * findItem.UnitPrice;
            cart.CartStatus = true;
            cart.LineTotal = newLineTotal2;
            cart.UnitPrice = findItem.UnitPrice;
            _cartDal.Add(cart);
            return new SuccessResult("Sepepe eklendi");
        }

        public IResult DecreaseAd(int userId, int productId)
        {
            var product = _cartDal.Get(c => c.UserId == userId && c.productId == productId && c.CartStatus == true);
            var newCount = product.Count - 1;
            var unitPrice = _productDal.Get(i => i.Id == productId).UnitPrice;

            product.Count = newCount;
            product.LineTotal = newCount * unitPrice;
            _cartDal.Update(product);
            return new SuccessResult("Miktar güncellendi");
        }

        public IResult DecreaseKg(int userId, int productId)
        {
            var item = _cartDal.Get(c => c.UserId == userId && c.productId == productId && c.CartStatus == true);
            var newCount = item.Count - 0.5;
            var unitPrice = _productDal.Get(i => i.Id == productId).UnitPrice;

            item.Count = newCount;
            item.LineTotal = newCount * unitPrice;
            _cartDal.Update(item);
            return new SuccessResult("Miktar güncellendi");
        }

        public IResult Delete(int id)
        {
            Cart cart = _cartDal.Get(c => c.Id == id);
            _cartDal.Delete(cart);
            return new SuccessResult("Sepetten çıkarma işlemi başarılı");
        }

        public IDataResult<List<Cart>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll(c => c.UserId == userId));
        }

        public IDataResult<List<CartWithProductDto>> GetAllByUserIdAndCartStatusIsFalse(int userId)
        {
            return new SuccessDataResult<List<CartWithProductDto>>(_cartDal.GetAllByUserIdCartWithItemDto(c => c.UserId == userId && c.CartStatus == false), "Kullanıcı numarasına göre aktif ürünler getirildi");
        }

        public IDataResult<List<CartWithProductDto>> GetAllByUserIdAndCartStatusIsTrue(int userId)
        {
            return new SuccessDataResult<List<CartWithProductDto>>(_cartDal.GetAllByUserIdCartWithItemDto(c => c.UserId == userId && c.CartStatus == true ), "Kullanıcı numarasına göre aktif ürünler getirildi");
        }

        public IDataResult<CartDto> GetByUserIdTotalCartPrice(int userId)
        {
            return new SuccessDataResult<CartDto>(_cartDal.getByUserIdTotalCartPrice(c => c.UserId == userId));
        }

        public IResult IncreaseAd(int userId, int productId)
        {
            var product = _cartDal.Get(c => c.UserId == userId && c.productId == productId && c.CartStatus == true);
            var newCount = product.Count + 1;
            var unitPrice = _productDal.Get(i => i.Id == productId).UnitPrice;

            product.Count = newCount;
            product.LineTotal = newCount * unitPrice;
            _cartDal.Update(product);
            return new SuccessResult("Miktar güncellendi");
        }

        public IResult IncreaseKg(int userId, int productId)
        {
            var product = _cartDal.Get(c => c.UserId == userId && c.productId == productId && c.CartStatus == true);
            var newCount = product.Count + 0.5;
            var unitPrice = _productDal.Get(i => i.Id == productId).UnitPrice;

            product.Count = newCount;
            product.LineTotal = newCount * unitPrice;
            _cartDal.Update(product);
            return new SuccessResult("Miktar güncellendi");
        }
    }
}
