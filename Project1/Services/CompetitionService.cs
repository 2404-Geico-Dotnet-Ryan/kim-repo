class CompetitionService
{
    CompetitionRepo cr;

    public CompetitionService(CompetitionRepo cr)
    {
        this.cr = cr;
    }
    public Competition? Register(Competition c)
}