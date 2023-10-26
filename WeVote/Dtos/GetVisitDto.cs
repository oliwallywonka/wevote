using System.ComponentModel.DataAnnotations;
using WeVote.Entities;

namespace WeVote.Dtos
{
    public class GetVisitDto
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
