using Microsoft.EntityFrameworkCore;
using TS_Tool.DataLayer;
using TS_Tool.Models;

namespace TS_Tool.Service.Repository
{
    public interface IGetOSBetInfoByMixParlayBetRepository
    {
        List<Betdetail> GetOSBetInfoDataByMixParlay(String WebId, String RefNo);
    }
    public class GetOSBetInfoByMixParlayBetRepository : IGetOSBetInfoByMixParlayBetRepository
    {
        private readonly ThirdDbContext _CasMainWLDbContext;

        public GetOSBetInfoByMixParlayBetRepository(ThirdDbContext casMainWLDbContext)
        {
            _CasMainWLDbContext = casMainWLDbContext;
        }
        List<Betdetail> IGetOSBetInfoByMixParlayBetRepository.GetOSBetInfoDataByMixParlay(String WebId, String RefNo)
        {
            var betdetailList = _CasMainWLDbContext.OSBetInformation
    .FromSqlRaw($"EXEC GetOSBetInfoByMP  '{RefNo}'")
    .AsNoTracking()
    .ToList();

            return betdetailList;
        }
    }
}
