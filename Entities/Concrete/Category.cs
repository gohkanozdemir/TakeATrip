using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public byte Doors { get; set; }
        public byte Seats { get; set; }
        public string Description { get; set; }
    }
}
