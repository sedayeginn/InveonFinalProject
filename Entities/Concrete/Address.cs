using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Address : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }
        public int DistrictId { get; set; }
        public string PostalCode { get; set; }
        public string AddressText { get; set; }
    }
}
