using System.Net.Cache;

class Presentation
{
    public static void MainMenu()
    {
        System.Console.WriteLine("Welcome to the Competition Registration Site!");
        bool keepGoing = true;
        while (keepGoing)
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
            switch (input)
            {
                case 1:
                    Gymnast gymnast = CreateGymnast();
                    GymnastOptionsMenu(gymnast);
                    keepGoing = false;
                    break;
                case 2:
                    gymnast = GymnastLogin();
                    GymnastOptionsMenu(gymnast);
                    keepGoing = false;
                    break;
                case 3:
                    AdminLogin();
                    keepGoing = false;
                    break;
                case 0:
                    System.Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid option selected. Please select from options 0-3");
                    break;
            }
        }
    }
    public static Gymnast CreateGymnast()
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
        SQLStorageRepo repo = new();
        repo.StoreGymnast(newGymnast);
        return newGymnast;
    }
    public static Gymnast GymnastLogin()
    {
        string username;
        Gymnast loginGymnast = new();
        System.Console.WriteLine("Please enter your user name:");
        username = Console.ReadLine();
        SQLStorageRepo repo = new();
        loginGymnast = repo.LoginGymnast(username);
        return loginGymnast;
    }
    public static void AdminLogin()
    {
        string password;
        System.Console.WriteLine("Please enter your admin password:");
        password = Console.ReadLine();
        if (password == "1234")
        {
            AdminMenu();
        }
        //need to create a loop validating correct password entered
    }
    public static void AdminMenu()
    {
        System.Console.WriteLine("Welcome to the Competition Registration Site!");
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please pick an option to proceed:");
            System.Console.WriteLine("*********************************");
            System.Console.WriteLine("[1] View Competitions");
            System.Console.WriteLine("[2] Create New Competition");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("*********************************");
            int input = int.Parse(Console.ReadLine() ?? "0");
            input = ValidateCmd(input, 2);
            SQLStorageRepo repo = new();
            switch (input)
            {
                case 1:
                    List<Competition>competitions = repo.GetAllCompetitions();
                    PrintCompetitions(competitions);
                    break;
                case 2:
                    CreateCompetition();
                    break;
                case 0:
                    System.Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid option selected. Please select from options 0-5");
                    break;
            }
        }
    }
    public static void CreateCompetition()
    {
        string competitionname;
        DateTime competitionStartDate;
        DateTime competitionEndDate;
        string competitionlocation;
        Guid CompetitionId;
        System.Console.WriteLine("Please provide the name of the competition");
        competitionname = Console.ReadLine();
        System.Console.WriteLine("Please provide the competition Start Date:");
        competitionStartDate = DateTime.Parse(Console.ReadLine());
        System.Console.WriteLine("Please provide the competition End Date:");
        competitionEndDate = DateTime.Parse(Console.ReadLine());
        System.Console.WriteLine("Please provide the location of the competition:");
        competitionlocation = Console.ReadLine();
        Competition newCompetition = new(competitionname, competitionStartDate, competitionEndDate, competitionlocation);
        SQLStorageRepo repo = new();
        repo.StoreCompetition(newCompetition);
    }
    public static void GymnastOptionsMenu(Gymnast gymnast)
    {
        {
            System.Console.WriteLine($"Welcome {gymnast.Fname}!");
            bool keepGoing = true;
            while (keepGoing)
            {
                System.Console.WriteLine("Please pick an option to proceed:");
                System.Console.WriteLine("*********************************");
                System.Console.WriteLine("[1] View Competitions Currently Registered In");
                System.Console.WriteLine("[2] Register for Competition");
                System.Console.WriteLine("[0] Quit");
                System.Console.WriteLine("*********************************");
                SQLStorageRepo repo = new();
                int input = int.Parse(Console.ReadLine() ?? "0");
                input = ValidateCmd(input, 2);
                switch (input)
                {
                    case 1:
                        List<Competition> competitions = repo.GetCompetitions(gymnast);
                        PrintCompetitions(competitions);
                        break;
                    case 2:
                        Register(gymnast);
                        break;
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("Invalid option selected. Please select from options 0-3");
                        break;
                }
            }
        }
    }
    public static void PrintCompetitions(List<Competition> competitions)
    {
        foreach (Competition competition in competitions)
        {
            System.Console.WriteLine(competition.ToString());
        }
        Console.ReadLine();
    }
    public static void Register(Gymnast gymnast) // sign up for a new competition 
    {
        int compIndex = 0;
        SQLStorageRepo repo = new();
        Console.WriteLine("Please select which competition you'd like to sign up for:");
        List<Competition> competitions = repo.GetAllCompetitions();  // this will only display competitions the gymnast is NOT already enrolled in
        foreach (Competition competition in competitions)
        {
            compIndex++; // add 1 to the index, so it starts with 1(instead of 0 as defined above). Eeach time the loop goes through it will increment
            Console.WriteLine($"[{compIndex}] {competition.CompetitionName}"); // right now just printing the index and the competitionName. You can add more.
        }
        int compSelection = int.Parse(Console.ReadLine()) - 1;
        repo.Register(competitions[compSelection], gymnast);
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