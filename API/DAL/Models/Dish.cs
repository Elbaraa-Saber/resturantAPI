namespace API.DAL.Models
{
    public class Dish : IBaseEntity
    {
       public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsVegetarian { get; set; }
        public string Photo {  get; set; }

        // for <<enum>> Category
        public Category Category { get; set; }
        
        // IBaseEntity
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        // Relations 
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<DishInCart> DishInCarts { get; set; } = new List<DishInCart>();

    }
    public enum Category
    {
        Wok,
        Pizza,
        Desert,
        Drink
    }
}
