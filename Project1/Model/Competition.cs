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
}