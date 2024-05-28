using Microsoft.EntityFrameworkCore;
using TS_Tool.DataLayer;
using TS_Tool.Models;

namespace TS_Tool.Service.Repository
{
    public interface IGetOSBetInfoBySingleBetRepository
    {
        List<Betdetail> GetOSBetInfoDataBySingleBet(String WebId, String RefNo);
    }
    public class GetOSBetInfoBySingleBetRepository : IGetOSBetInfoBySingleBetRepository
    {
        private readonly ThirdDbContext _CasMainWLDbContext;

        public GetOSBetInfoBySingleBetRepository (ThirdDbContext casMainWLDbContext)
        {
            _CasMainWLDbContext = casMainWLDbContext;
        }

        List<Betdetail> IGetOSBetInfoBySingleBetRepository.GetOSBetInfoDataBySingleBet(String WebId, String RefNo)
        {
            var betdetailList = _CasMainWLDbContext.OSBetInformation
    .FromSqlRaw($"EXEC GetOSBetInfoBySingleBet  '{RefNo}'")
    .AsNoTracking()
    .ToList();

            return betdetailList;
        }
    }
}
