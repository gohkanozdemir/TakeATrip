using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int CarCategoryId { get; set; }
        public short Doors { get; set; }
        public short Seats { get; set; }
        public string Description { get; set; }
    }
}
