using Microsoft.EntityFrameworkCore;
using TS_Tool.DataLayer;
using TS_Tool.Models;

namespace TS_Tool.Service.Repository
{
    public interface INewSystemGameProviderRepo {
        List<Betdetail> GetBetInfoData(String WebId, String RefNo);
        NewSystemSportsBet GetSportsBet(string webId, string refNo);
    }
    public class GetBetInfoRepository : INewSystemGameProviderRepo
    {
        private readonly FirstDbContext _GameProviderdbContext;
        private readonly ILogger<GetBetInfoRepository> _logger;


        public GetBetInfoRepository(FirstDbContext GameProviderdbContext, ILogger<GetBetInfoRepository> logger)
        {
            _GameProviderdbContext = GameProviderdbContext;
            _logger = logger;
        }
        public List<Betdetail> GetBetInfoData(String WebId, String RefNo)
        {
            _logger.LogInformation("Executing GetBetInfoData with parameters WebId: {WebId}, RefNo: {RefNo}", WebId, RefNo);
            var betdetailList = _GameProviderdbContext.BetInformation
                .FromSqlRaw($"EXEC GetBetInfo {WebId}, '{RefNo}'")
                .AsNoTracking()
                .ToList();

            return betdetailList;
        }

        public NewSystemSportsBet GetSportsBet(string webId, string refNo)
        {
            throw new NotImplementedException();
        }
    }
}
