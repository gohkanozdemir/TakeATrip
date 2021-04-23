using Core.Entities;

namespace Entities.Concrete
{
    public class CarCategory: IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
