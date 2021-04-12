using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public short Doors { get; set; }
        public short Seats { get; set; }
        public string Description { get; set; }
    }
}
