using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeVote.Entities
{
    public class VisitEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        [Required]
        [MaxLength(45)]
        public string Ip { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity? Country { get; set; }
    }
}
