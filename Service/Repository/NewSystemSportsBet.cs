
namespace TS_Tool.Service.Repository
{
    public class NewSystemSportsBet
    {
        public string RefNo { get; set; }
        public int WebId { get; set; }

        public List<NewSystemSportsSubBet> SubBets { get; set; }
        public string BetType { get; private set; }

        internal bool IsMixParlay()
        {
            return BetType == "Mix Parlay";
        }

        public SeamlessWalletRecord SeamlessWalletRecord { get; set; }
    }
}