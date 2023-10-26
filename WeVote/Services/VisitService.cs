using WeVote.Dtos;
using WeVote.Entities;
using WeVote.Repositories;

namespace WeVote.Services
{
    public interface IVisitService
    {
        public Task<bool> CreateVisit(CreateVisitDto visitDto);
    }

    public class VisitService: IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly ICountryRepository _countryRepository;

        public VisitService(IVisitRepository visitRepository, ICountryRepository countryRepository)
        {
            _visitRepository = visitRepository;
            _countryRepository = countryRepository;
        }

        public async Task<bool> CreateVisit(CreateVisitDto visitDto)
        {
            if (!ReferenceEquals(await _visitRepository.GetVisitDetailByIp(visitDto.Ip), null)) {
                return true;
            }

            Guid visitId = Guid.NewGuid();
            CountryEntity? countryEntity = await _countryRepository.GetCountry(visitDto.CountryName);

            if (ReferenceEquals(countryEntity, null))
            {
                Guid countryId = Guid.NewGuid();
                await _countryRepository.CreateCountry(new CountryEntity
                {
                    Id = countryId,
                    CountryName = visitDto.CountryName,
                    CurrencyCode = visitDto.CurrencyCode,
                    CurrencyName = visitDto.CurrencyName,
                    CurrencySymbol = visitDto.CurrencySymbol,
                });
                
                return await _visitRepository.CreateVisit(new VisitEntity
                {
                    Id = visitId,
                    Ip = visitDto.Ip,
                    CountryId = countryId,
                });
            }

            return await _visitRepository.CreateVisit(new VisitEntity
            {
                Id = visitId,
                Ip = visitDto.Ip,
                CountryId = countryEntity.Id,
            });
        }
    }
}
