using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TS_Tool.Models;
using TS_Tool.Service.Repository;

namespace TS_Tool.Service.GetBetInfo
{
    public interface IGetBetInfoService
    {
        List<Betdetail> GetBetInfoData(string WebId, string RefNo);
    }

    public class GetBetInfoService : IGetBetInfoService
    {
        const int MIX_PARLAY = 40;
        private readonly INewSystemGameProviderRepo _newSystemGameProviderRepo;
        private readonly IGetOSBetInfoByMixParlayBetRepository _getOSBetInfoByMixParlayBetRepo;
        private readonly IGetOSBetInfoBySingleBetRepository _getOSBetInfoBySingleBetRepo;

        public GetBetInfoService(
            INewSystemGameProviderRepo newSystemGameProviderRepo,
            IGetOSBetInfoByMixParlayBetRepository getOSBetInfoByMixParlayBetRepo,
            IGetOSBetInfoBySingleBetRepository getOSBetInfoBySingleBetRepo)
        {
            _newSystemGameProviderRepo = newSystemGameProviderRepo;
            _getOSBetInfoByMixParlayBetRepo = getOSBetInfoByMixParlayBetRepo;
            _getOSBetInfoBySingleBetRepo = getOSBetInfoBySingleBetRepo;
        }

        public List<Betdetail> GetBetInfoData(string WebId, string RefNo)
        {
            var newSystemSportsBet = _newSystemGameProviderRepo.GetSportsBet(WebId, RefNo);
            var nsBetDetail = _newSystemGameProviderRepo.GetBetInfoData(WebId, RefNo).First(); //Single Rows
            newSystemSportsBet.SeamlessWalletRecord.Response.
            OldSystemSportsBet oldSystemSportsBet = new OldSystemSportsBet();

            foreach (var newSystemSubBet in newSystemSportsBet.SubBets)
            {
                var oldSystemSubBet = oldSystemSportsBet.SubBet
                    .Where(o => o.TransId.ToString() == newSystemSubBet.IdentifyString).FirstOrDefault();
            }


            List<Betdetail> osBetDetails = null;
            if (nsBetDetail.BetType == MIX_PARLAY)
            {
                osBetDetails = _getOSBetInfoByMixParlayBetRepo.GetOSBetInfoDataByMixParlay(WebId, RefNo);
            }
            else
            {
                osBetDetails = _getOSBetInfoBySingleBetRepo.GetOSBetInfoDataBySingleBet(WebId, RefNo);
            }

            foreach (var osBetDetail in osBetDetails)
            {

                nsBetDetail.OsStatus = osBetDetail.OsStatus;
                nsBetDetail.MatchResultId = osBetDetail.MatchResultId;
                nsBetDetail.Remark = osBetDetail.Remark;
            }

            return combinedBetDetails;
        }
    }
}
