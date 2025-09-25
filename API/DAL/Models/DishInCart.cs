namespace API.DAL.Models
{
    public class DishInCart : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Count { get; set; }

        // IBaseEntity
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        // Realtions
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }

        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
      

    }
}
