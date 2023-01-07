using System.ComponentModel.DataAnnotations;

namespace ARS_OS.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserIP { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? UpdateUserId { get; set; }
        public string? UpdateUserIP { get; set; }
        public bool IsDeleted { get; set; }
    }
}
