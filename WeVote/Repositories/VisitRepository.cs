using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Metrics;
using WeVote.Entities;
using WeVote.Exceptions;
using WeVote.Providers;

namespace WeVote.Repositories
{
    public interface IVisitRepository
    {
        public Task<bool> CreateVisit(VisitEntity visit);
        public Task<VisitEntity?> GetVisitDetailByIp(string ip);
    }
    public class VisitRepository : IVisitRepository
    {

        private readonly EFContext _context;
        public VisitRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVisit(VisitEntity visit)
        {
            try
            {
                EntityEntry<VisitEntity> InertedVisit = await _context.Visit.AddAsync(visit);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DBException(ex.Message);
            }
        }

        public async Task<VisitEntity?> GetVisitDetailByIp(string ip)
        {
            return await _context
                .Visit
                .Include(v => v.Country)
                .Where(v => v.Ip == ip)
                .FirstOrDefaultAsync();
        }
    }
}
