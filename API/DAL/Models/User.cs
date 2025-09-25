using Microsoft.AspNetCore.Identity;

namespace API.DAL.Models
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        // from IBaseEntity
        public Guid Id { get; set; } // تأكد أن هذا لا يتعارض مع IdentityUser<Guid> (هو عنده Id بالفعل من النوع Guid)
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        // relations with other Tables
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<DishInCart> CartItems { get; set; } = new List<DishInCart>();
    }
}
