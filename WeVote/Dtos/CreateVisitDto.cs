using System.ComponentModel.DataAnnotations;

namespace WeVote.Dtos
{
    public class CreateVisitDto
    {
        [Required]
        [MaxLength(45)]
        public string Ip { get; set; }

        [Required]
        [MaxLength(20)]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string CurrencyName { get; set; }

        [Required]
        [MaxLength(5)]
        public string CurrencySymbol { get; set; }
    }
}
