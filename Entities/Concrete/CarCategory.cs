using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarCategory: IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
