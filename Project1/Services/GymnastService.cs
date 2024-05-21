class GymnastService
{
   GymnastRepo gr = new();

    //Register
    public Gymnast? Register(Gymnast g)
    {
        //let's not let them register if the role is anything other than "Gymnast"
        /*if (g.Role != "Gymnast")
        {
            //reject them
            System.Console.WriteLine("Invalid Role - Please try again!");
            return null;
        }*/

        //let's not let them register if the Username is already taken! 
        //Get all Gymnasts
        List<Gymnast> allGymnasts = gr.GetAllGymnasts();
        //Check if our new Gymnastname matches any of the Gymnastnames on all those Gymnasts.
        foreach (Gymnast Gymnast in allGymnasts)
        {
            if (Gymnast.Username == g.Username)
            {
                System.Console.WriteLine("Gymnast name already taken! - Please try again!");
                return null;//reject them
            }
        }
        //If we make it this far, role and username are gtg
        return gr.AddGymnast(g);
    }

    //Login
    public Gymnast? Login(string Username)
    {
        //Get all Gymnasts
        List<Gymnast> allGymnasts = gr.GetAllGymnasts();

        //check each one to see if we find a match.
        foreach (Gymnast Gymnast in allGymnasts)
        {
            //If matching username and password, they 'login' -> return that Gymnast
            if (Gymnast.Username == Username)
            {
                return Gymnast; //us returning the Gymnast will indicate success.
            }
        }

        System.Console.WriteLine("Invalid Username / Password combo! Quit playing around and get it right!");
        return null; //reject the login
    } 
}