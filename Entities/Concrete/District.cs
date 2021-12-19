using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public int TownId { get; set; }
        public string DistrictName { get; set; }
    }
}
