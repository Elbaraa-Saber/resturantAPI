namespace API.DAL.Models
{
    public class Rating: IBaseEntity
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        // IBaseEntity
        public DateTime CreateDateTime  { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    
        // Relations
        public Guid UserId { get; set; }
        public User User { get; set; }
        

        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
        
    }
}
