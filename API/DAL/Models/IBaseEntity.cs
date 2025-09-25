namespace API.DAL.Models
{
    public interface IBaseEntity
    {
        DateTime CreateDateTime { get; set; }
        DateTime ModifyDateTime { get; set; }
        DateTime? DeleteDateTime { get; set; }
    }
}
