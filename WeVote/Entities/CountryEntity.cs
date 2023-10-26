using System.ComponentModel.DataAnnotations;

namespace WeVote.Entities
{
    public class CountryEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string CountryName { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string CurrencyName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(5)]
        public string CurrencySymbol { get; set; }

        public virtual ICollection<VisitEntity>? Visit { get; set; }
    }
}
