namespace API.DAL.Models
{
    public class Order: IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime OrderTime {  get; set; }
        public DateTime DeliveryTime{ get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }

        // enum Status
        public Status Status { get; set; }

        // IBaseEntity
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        // Relations
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<DishInCart> DishInCarts { get; set; } = new List<DishInCart>();
    }
    public enum Status
    {
        InProcess,
        Delivered
    }
}
