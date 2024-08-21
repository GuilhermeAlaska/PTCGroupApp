namespace Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(-3);
        public DateTime? UpdatedAt { get; set; } = null;
    }
}