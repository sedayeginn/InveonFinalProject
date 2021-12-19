using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ImagePath : IEntity
    {
        public int Id { get; set; }
        public string ImageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int ProductId { get; set; }
    }
}
