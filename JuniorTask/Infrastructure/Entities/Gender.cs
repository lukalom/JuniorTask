using System.ComponentModel.DataAnnotations;

namespace JuniorTask.Infrastructure.Entities
{
    public class Gender : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
