class CompetitionRepo
{

    CompetitionStorage competitionStorage = new();


    public Competition AddCompetition(Competition c)
    {
        //We need first ensure that the movie being added has a correct ID.
        //Assume it doesnt...and force it to have a correct ID using our idCounter.
        c.CompetitionId = competitionStorage.idCounter++; //incrementing the value afterwards, to prep it for the next time it's needed.

        //Add the movie into our collection.
        competitionStorage.competitions.Add(c.CompetitionId, c);
        return c;
    }

    public Competition? GetCompetition(int id)
    {
        
        if (competitionStorage.competitions.ContainsKey(id))
        {
            Competition selectedCompetition = competitionStorage.competitions[id];
            return selectedCompetition;
            // return competitionStorage.competitions[id];
        }
        else
        {
            System.Console.WriteLine("Invalid Competition ID - Please Try Again");
            return null;
        }
    }

    public List<Competition> GetAllcompetitions()
    {

        return competitionStorage.competitions.Values.ToList();
    }


    public Competition? UpdateCompetition(Competition updatedCompetition)
    {

        try
        {
            competitionStorage.competitions[updatedCompetition.CompetitionId] = updatedCompetition;

            return updatedCompetition;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Competition ID - Please Try Again");
            return null;
        }
    }

    public Competition? DeleteCompetitoin(Competition c)
    {
        //If we have the ID -> then simply Remove it from storage
        bool didRemove = competitionStorage.competitions.Remove(c.CompetitionId);

        if (didRemove)
        {
            
            return c;
        }
        else
        {
            System.Console.WriteLine("Invalid Competition ID - Please Try Again");
            return null;
        }
    }

}
