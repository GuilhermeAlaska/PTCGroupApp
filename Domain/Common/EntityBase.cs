namespace Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}