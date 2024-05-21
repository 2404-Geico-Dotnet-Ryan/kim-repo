class GymnastRepo
{
    GymnastStorage gymnastStorage = new();

    //add, get-one, get-all, update, and delete
    public Gymnast AddGymnast(Gymnast g)
    {
        g.GymnastId = gymnastStorage.idCounter++;
        gymnastStorage.gymnasts.Add(g.GymnastId, g);
        return g;
    }

    public Gymnast? Getgymnast(int id)
    {
        if (gymnastStorage.gymnasts.ContainsKey(id))
        {
            Gymnast selectedgymnast = gymnastStorage.gymnasts[id];
            return selectedgymnast;
        }
        else
        {
            System.Console.WriteLine("Invalid gymnast ID - Please Try Again");
            return null;
        }
    }

    public List<Gymnast> GetAllGymnasts()
    {
        return gymnastStorage.gymnasts.Values.ToList();
    }

    public Gymnast? Updategymnast(Gymnast updatedgymnast)
    {
        try
        {
            gymnastStorage.gymnasts[updatedgymnast.GymnastId] = updatedgymnast;
            return updatedgymnast;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid gymnast ID - Please Try Again");
            return null;
        }
    }

    public Gymnast? Deletegymnast(Gymnast g)
    {
        bool didRemove = gymnastStorage.gymnasts.Remove(g.GymnastId);

        if (didRemove)
        {
            return g;
        }
        else
        {
            System.Console.WriteLine("Invalid gymnast ID - Please Try Again");
            return null;
        }
    }
}
