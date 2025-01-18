namespace FinTrack.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity(DateTime createdAt)
        {
            CreatedAt = createdAt;
            IsActive= true;
            IsDeleted= false;
        }

        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public void setAsDeleted()
        {
            IsDeleted = true;
            IsActive = false;
        }
        public void setAsInactive()
        {
            IsActive = false;
        }
        public void setAsUpdated()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
