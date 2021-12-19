using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto:IDto
    {
        
        public int Id { get; set; }
        public double Count { get; set; }
        public int OrderId { get; set; }
        public DateTime Date_ { get; set; }
        public double TotalPrice { get; set; }
        public bool IsDelivered { get; set; }
        
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        //public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public int AddressId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int TownId { get; set; }

        public int DistrictId { get; set; }

        public string PostalCode { get; set; }

        public string AddressText { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
