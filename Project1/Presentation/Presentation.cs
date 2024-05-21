class Presentation
{
     public static void MainMenu()
     {
        System.Console.WriteLine("Welcome to the Competition Registration Site!");
        bool keepGoing = true;
        while(keepGoing)
        {
            System.Console.WriteLine("Please pick an option to proceed:");
            System.Console.WriteLine("*********************************");
            System.Console.WriteLine("[1] Create New User");
            System.Console.WriteLine("[2] Gymnast Login");
            System.Console.WriteLine("[3] Administrator Login");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("*********************************");

            int input = int.Parse(Console.ReadLine() ?? "0");
            input = ValidateCmd(input, 3);

            keepGoing = DecideNextOption(input);
        }
     }
    public static void CreateGymnast()
    {
        string username;
        string fname;
        string lname;
        DateTime dob;
        System.Console.WriteLine("Please provide user name:");
        username = Console.ReadLine();
        System.Console.WriteLine("Please provide gymnast's first name:");
        fname = Console.ReadLine();
        System.Console.WriteLine("Please provide gymnast's last name:");
        lname = Console.ReadLine();
        System.Console.WriteLine("Please provide gymnast's DOB:");
        dob = DateTime.Parse(Console.ReadLine());

        Gymnast newGymnast = new(username, fname, lname, dob);
    }
    public static Gymnast GymnastLogin()
    {
        string username;
        Gymnast loginGymnast = new();
        System.Console.WriteLine("Please enter your user name:");
        username = Console.ReadLine();
        //here - call db to find user to log in
        return loginGymnast;
    }
        public static void AdminLogin()
    {
        string password;
        System.Console.WriteLine("Please enter your admin password:");
        password = Console.ReadLine();
        //need to create a loop validating correct password entered
        AdminMenu();
        
    }
     public static void AdminMenu()
    {
        System.Console.WriteLine("Welcome to the Competition Registration Site!");
        bool keepGoing = true;
        while(keepGoing)
        {
            System.Console.WriteLine("Please pick an option to proceed:");
            System.Console.WriteLine("*********************************");
            System.Console.WriteLine("[1] View Competitions");
            System.Console.WriteLine("[2] View active Gymnasts");
            System.Console.WriteLine("[3] Register Gymnast for Competition");
            System.Console.WriteLine("[4] View Gymnasts Registered for Competition");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("*********************************");

            int input = int.Parse(Console.ReadLine() ?? "0");
            input = ValidateCmd(input, 4);

            keepGoing = DecideNextOption(input);
        }
    }
    public static bool DecideNextOption(int input)
    {
        switch (input)
        {
            case 1:
            {
                RetrievingAvailableCompetitions();
                break;
            }
            case 2:
            {
                RetrievingActiveGymnasts();
                break;
            }
            case 3:
            {
                RegisterGymnast();
                break;
            }
            case 4:
            {
                ViewRegistrations();
                break;
            }
            case 0:
            default:
            {
                return false;
            }
        }
        return true;
    }
    private static void RetrievingAvailableCompetitions()
    {
        List<Competition> competition = 
    }

    
    private static int ValidateCmd(int cmd, int maxOption)
    {
        while (cmd < 0 || cmd > maxOption)
        {
            System.Console.WriteLine("Invalid Command - Please Enter a command 1-" + maxOption + "; or 0 to Quit");
            cmd = int.Parse(Console.ReadLine() ?? "0");
        }

        //if input was already valid - it skips the if statement and just returns the value.
        return cmd;
    }
}