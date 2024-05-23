
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
}