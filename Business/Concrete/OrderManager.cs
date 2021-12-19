﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;
        ICartDal _cartDal;
        IOrderDetailDal _orderDetailDal;

        public OrderManager(IOrderDal orderDal, ICartDal cartDal, IOrderDetailDal orderDetailDal)
        {
            _orderDal = orderDal;
            _cartDal = cartDal;
            _orderDetailDal = orderDetailDal;
        }
        public IResult Add(Order order)
        {
            CartDto cart = _cartDal.getByUserIdTotalCartPrice(t => t.UserId == order.UserId);
            DateTime now = DateTime.Now;

            order.OrderDate = now;
            order.TotalPrice = cart.TotalCartPrice;
            order.IsDelivered = false;
            _orderDal.Add(order);

            var cartItems = _cartDal.GetAll(c => c.UserId == order.UserId && c.CartStatus == true);

            foreach (var item in cartItems)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = item.productId;
                orderDetail.OrderId = order.Id;
                orderDetail.Count = item.Count;
                _orderDetailDal.Add(orderDetail);
            }
            foreach (var item in cartItems)
            {
                item.CartStatus = false;
                _cartDal.Update(item);
            }
            return new SuccessResult("Siparişiniz alındı.");

        }

        public IResult WasDelivered(int id)
        {
            Order order = _orderDal.Get(o => o.Id == id);
            order.IsDelivered = true;
            _orderDal.Update(order);
            return new SuccessResult("Siparişin teslim edildiği kaydedildi.");
        }
    }
}
