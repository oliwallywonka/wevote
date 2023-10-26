using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;
using WeVote.Entities;
using WeVote.Exceptions;
using WeVote.Providers;

namespace WeVote.Repositories
{
    public interface ICountryRepository
    {
        Task<bool> CreateCountry(CountryEntity country);
        Task<CountryEntity?> GetCountry(string countryName);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly EFContext _context;
        public CountryRepository(EFContext context) 
        {
            _context = context;
        }

        public async Task<bool> CreateCountry(CountryEntity country)
        {
            try
            {
                EntityEntry<CountryEntity> insertedCountry = await _context.Country.AddAsync(country);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DBException(ex.Message);
            }
        }

        public async Task<CountryEntity?> GetCountry(string countryName)
        {
            return await _context
                .Country
                .Where(c => c.CountryName == countryName)
                .FirstOrDefaultAsync();
        }
    }
}
