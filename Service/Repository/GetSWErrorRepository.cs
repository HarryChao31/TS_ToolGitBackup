using Microsoft.EntityFrameworkCore;
using TS_Tool.DataLayer;
using TS_Tool.Models;

namespace TS_Tool.Service.Repository
{
    public interface IGetSWErrorRepository
    {
        List<SeamlessWalletError> GetSWErrorFromDB(string webId, string refNo);
    }
    public class GetSWErrorRepository : IGetSWErrorRepository
    {
        private readonly SecondDbContext _RecorddbContext;

        public GetSWErrorRepository(SecondDbContext RecorddbContext)
        {
            _RecorddbContext = RecorddbContext;
        }
        public List<SeamlessWalletError> GetSWErrorFromDB(String WebId, String RefNo) {
            var SWError = _RecorddbContext.SWErrorInfo
  .FromSqlRaw($"EXEC GetSeamlessWalletError {WebId}, '{RefNo}'")
  .AsNoTracking()
  .ToList();
            return SWError;
        }
    }
}
