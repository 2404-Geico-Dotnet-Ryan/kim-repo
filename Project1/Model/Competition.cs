<<<<<<< HEAD
public class Competition
{
    public string CompetitionName { get; set; }
    public DateTime CompetitionStartDate { get; set; }
    public DateTime CompetitionEndDate { get; set; }
    public string Location { get; set; }
    public Guid CompetitionId { get; set; }

    public Competition()
    {
        CompetitionName = "";
        Location = "";
        CompetitionStartDate = DateTime.MinValue;
        CompetitionEndDate = DateTime.MinValue;
    }
    public Competition(string competitionName, DateTime competitionStartDate, DateTime competitionEndDate, string location)
    {
        CompetitionName = competitionName;
        CompetitionStartDate = competitionStartDate;
        CompetitionEndDate = competitionEndDate;
        Location = location;
        CompetitionId = Guid.NewGuid();
    }
    public override string ToString()
    {
        return $"competitionName:  {CompetitionName}\nCompetitionStartDate:  {CompetitionStartDate}\nCompetitionEndDate:  {CompetitionEndDate}\nlocation:  {Location}\ncompetitionId:  {CompetitionId}\n------------------------------------------";
    }
        public Competition(Guid competitionid, string competitionName, DateTime competitionStartDate, DateTime competitionEndDate, string location)
    {
        CompetitionName = competitionName;
        CompetitionStartDate = competitionStartDate;
        CompetitionEndDate = competitionEndDate;
        Location = location;
        CompetitionId = competitionid;
    }
=======
class Competition
{
    public string CompetitionName { get; set; }
    public long CompetitionDates { get; set; }
    public string Location { get; set; }
    public double Score { get; set; }
    public int CompetitionId { get; set; }
    public int GymnastId { get; set; }

            public Competition()
    {
        CompetitionName = "";
        Location = "";
    }
        public Competition(string competitionName, long competitionDates, string location, double score, int competitionId, int gymnastId)
    {
        CompetitionName = competitionName;
        CompetitionDates = competitionDates;
        Location = location;
        Score = score;
        CompetitionId = competitionId;
        GymnastId = gymnastId;
    }
        public override string ToString()
    {
        return "{competitionName:" + CompetitionName
        + ",CompetitionDates:" + CompetitionDates
        + ",location:" + Location
        + ",score:" + Score
        + ",competitionId:" + CompetitionId
        + ",gymnastId:" + GymnastId + "}";
    }
>>>>>>> b58fdaa7513530bbcdcf231a0f9b572b765ebbc9
}