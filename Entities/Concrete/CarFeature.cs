using Core.Entities;

namespace Entities.Concrete
{
    public class CarFeature : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public short Doors { get; set; }
        public short Seats { get; set; }
        public string Description { get; set; }
    }
}
