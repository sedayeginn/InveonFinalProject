using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CartWithProductDto : IDto
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public int UserId { get; set; }
        public bool CartStatus { get; set; }
        public double LineTotal { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
       // public String Brand { get; set; }
        public string ImageUrl { get; set; }
    }
}
