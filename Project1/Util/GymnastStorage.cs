class GymnastStorage
{
    
    public Dictionary<int, Gymnast> gymnasts;
    public int idCounter = 1;

    public GymnastStorage()
    {
        Gymnast gymnasts1 = new("Arianna", "Perkins", "06/28/2010", "aperkins", idCounter); idCounter++;
        Gymnast gymnasts2 = new("Chandler", "Kitts", "10/10/2010", "ckitts", idCounter); idCounter++;
        Gymnast gymnasts3 = new("Leann", "Munoz", "10/20/2010", "lmunoz", idCounter); idCounter++;

        gymnasts = [];
        gymnasts.Add(gymnasts1.GymnastId, gymnasts1);
        gymnasts.Add(gymnasts2.GymnastId, gymnasts2);
        gymnasts.Add(gymnasts3.GymnastId, gymnasts3);
    }

}