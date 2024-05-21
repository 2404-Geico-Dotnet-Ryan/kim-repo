class CompetitionStorage
{
  

    public Dictionary<int, Competition> competitions;
    public int idCounter = 1;

    //Making this constructor give us some pre-loaded competitions to work with.
    public CompetitionStorage()
    {
        Competition competition1 = new("Capital Classic", "05/31/2024", "Boo Williams Sports Complex", 0, idCounter++, 1); idCounter++;
        Competition competition2 = new("Apollo Invitational", "06/11/2024", "Boo Williams Sports Complex", 0, idCounter++, 2); idCounter++;
        Competition competition3 = new("Pink Invitiational", "02/15/2025", "Philidelphia Convention Center", 0, idCounter++, 3); idCounter++;

        competitions = []; //Sets the Dictionary to an empty collection.
        competitions.Add(competition1.CompetitionId, competition1);
        competitions.Add(competition2.CompetitionId, competition2);
        competitions.Add(competition3.CompetitionId, competition3);
    }

}
