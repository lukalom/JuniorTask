using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuniorTask.Infrastructure.Entities
{
    public class User : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PersonalNumber { get; set; }
            
        [Required]
        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
