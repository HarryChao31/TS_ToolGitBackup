namespace TS_Tool.Service.GetBetInfo
{
    public class OldSystemSportsBet
    {
        public int TransId { get; set; }
        public int WebId { get; set; }
        public List<OldSystemSportsSubBet> SubBet { get; set; }
    }

    public class OldSystemSportsSubBet
    {
        public int TransId { get; set; }
    }
}