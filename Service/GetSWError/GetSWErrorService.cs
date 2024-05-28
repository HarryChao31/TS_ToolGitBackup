using Microsoft.EntityFrameworkCore;
using TS_Tool.DataLayer;
using TS_Tool.Models;
using TS_Tool.Service.Repository;

namespace TS_Tool.Service.GetSWError
{
    public interface IGetSWErrorService {
        List<SeamlessWalletError> GetSWErrorFromDB(string WebId, string RefNo);
    }
    public class GetSWErrorService : IGetSWErrorService
    {
        private readonly IGetSWErrorRepository _GetSWErrorRepo;
        public GetSWErrorService(IGetSWErrorRepository GetSWErrorRepo)
        {
            _GetSWErrorRepo = GetSWErrorRepo;
        }
        public List<SeamlessWalletError> GetSWErrorFromDB(string WebId, string RefNo) => _GetSWErrorRepo.GetSWErrorFromDB(WebId, RefNo);
    }
}
