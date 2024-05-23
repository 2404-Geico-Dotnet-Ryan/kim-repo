using System.Data.SqlClient;
public class SQLStorageRepo
{
    private string connectionstring;
    public SQLStorageRepo()
    {
        string path = @"C:\Users\A154862\Source\Revature\kim-repo\Project1\Repository\Gymnastics_App.txt";
        this.connectionstring = File.ReadAllText(path);
    }
    public void StoreGymnast(Gymnast gymnast)
    {
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        connection.Open();
        string Query =
                @"INSERT INTO Gymnastics_App.dbo.Gymnasts (GymnastId, FirstName, LastName, DOB, Username)
                VALUES
                (@Gymnast_Id, @First_Name, @Last_Name, @DOB, @User_Name)";
        using SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@Gymnast_Id", gymnast.GymnastId);
        cmd.Parameters.AddWithValue("@First_Name", gymnast.Fname);
        cmd.Parameters.AddWithValue("@Last_Name", gymnast.Lname);
        cmd.Parameters.AddWithValue("@DOB", gymnast.DOB);
        cmd.Parameters.AddWithValue("@User_Name", gymnast.Username);
        cmd.ExecuteNonQuery();
        connection.Close();

    }
    public Gymnast LoginGymnast(string username)
    {
        Gymnast gymnast = new();
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        connection.Open();
        string Query =
        @"Select GymnastId, FirstName, LastName, DOB, Username from Gymnastics_App.dbo.Gymnasts 
        Where Username = @User_Name";
        using SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@User_Name", username);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Guid GymnastId = new Guid(reader.GetString(0));
            string firstname = reader.GetString(1);
            string lastname = reader.GetString(2);
            DateTime dob = reader.GetDateTime(3);
            string user_name = reader.GetString(4);
            gymnast = new Gymnast(GymnastId, user_name, firstname, lastname, dob);
        }
        return gymnast;
    }
    public void StoreCompetition(Competition competition)
    {
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        connection.Open();
        string Query =
                @"INSERT INTO Gymnastics_App.dbo.Competitions (CompetitionId, CompetitionName, CompetitionStartDate, CompetitionEndDate, competitionLocation)
                VALUES
                (@Competition_Id, @Competition_Name, @CompetitionStartDate, @CompetitionEndDate, @CompetitionLocation)";
        using SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@Competition_Id", competition.CompetitionId);
        cmd.Parameters.AddWithValue("@Competition_Name", competition.CompetitionName);
        cmd.Parameters.AddWithValue("@CompetitionStartDate", competition.CompetitionStartDate);
        cmd.Parameters.AddWithValue("@CompetitionEndDate", competition.CompetitionEndDate);
        cmd.Parameters.AddWithValue("@CompetitionLocation", competition.Location);
        cmd.ExecuteNonQuery();
        connection.Close();
    }
    public List<Competition> GetCompetitions(Gymnast gymnast) // this looks similar to the one above because of naming, but This is specifically getting the list of competitions which a gymnast is signed up for
    {
        // a SQLConnection object is created to connect to the database, and is provided the connection string
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        List<Competition> competitions = new();


        connection.Open(); // open the connection to the database


        string cmdText = @$"select C.CompetitionId, CompetitionName, CompetitionStartDate, CompetitionEndDate, CompetitionLocation
                             FROM Competitions as C
                             join CompetitionGymnasts as G on G.CompetitionId = C.CompetitionId


                             WHERE G.GymnastId = '{gymnast.GymnastId}'";


        //Create the command object
        using SqlCommand cmd = new SqlCommand(cmdText, connection);


        //We create a SqlDataReader... so that we can read our data from the database.
        using SqlDataReader reader = cmd.ExecuteReader();


        while (reader.Read()) // Read each row returned in query
        {
            Guid CompetitionId = new Guid(reader.GetString(0));
            string competitionName = reader.GetString(1);
            DateTime startDate = reader.GetDateTime(2);
            DateTime endDate = reader.GetDateTime(3);
            string location = reader.GetString(4);


            Competition competition = new(CompetitionId, competitionName, startDate, endDate, location);
            competitions.Add(competition);
        }
        connection.Close();


        return competitions;
    }
    public List<Competition> GetAvailableCompetitions(Gymnast gymnast) // this looks similar to the one above because of naming, but This is specifically getting the list of competitions which a gymnast is signed up for
    {
        // a SQLConnection object is created to connect to the database, and is provided the connection string
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        List<Competition> competitions = new();


        connection.Open(); // open the connection to the database


        string cmdText = @$"select C.CompetitionId, CompetitionName, CompetitionStartDate, CompetitionEndDate, CompetitionLocation
                             FROM Competitions as C
                             join CompetitionGymnasts as G on G.CompetitionId = C.CompetitionId


                             WHERE G.GymnastId != '{gymnast.GymnastId}'";


        //Create the command object
        using SqlCommand cmd = new SqlCommand(cmdText, connection);


        //We create a SqlDataReader... so that we can read our data from the database.
        using SqlDataReader reader = cmd.ExecuteReader();


        while (reader.Read()) // Read each row returned in query
        {
            Guid CompetitionId = new Guid(reader.GetString(0));
            string competitionName = reader.GetString(1);
            DateTime startDate = reader.GetDateTime(2);
            DateTime endDate = reader.GetDateTime(3);
            string location = reader.GetString(4);


            Competition competition = new(CompetitionId, competitionName, startDate, endDate, location);
            competitions.Add(competition);
        }
        connection.Close();


        return competitions;
    }
    public void Register(Competition competition, Gymnast gymnast)   // this updates a competition by adding a gymnast to the linking table by adding a row with competionId and UserID
    {
        using SqlConnection connection = new SqlConnection(this.connectionstring);
        connection.Open();


        string cmdText =
            @"INSERT INTO Gymnastics_App.dbo.CompetitionGymnasts (CompetitionId, GymnastID)
                VALUES
                ( @Competition_Id, @Gymnast_Id)";


        using SqlCommand cmd = new SqlCommand(cmdText, connection);


        cmd.Parameters.AddWithValue("@Competition_Id", competition.CompetitionId);
        cmd.Parameters.AddWithValue("@Gymnast_Id", gymnast.GymnastId);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
            public List<Competition> GetAllCompetitions()  // this retrieves all competitions and returns them as a List of Competitions so they can be printed
        {
            // a SQLConnection object is created to connect to the database, and is provided the connection string
            using SqlConnection connection = new SqlConnection(this.connectionstring);
            List<Competition> competitions = new();


            connection.Open(); // open the connection to the database


            string cmdText = @"select CompetitionId, CompetitionName, CompetitionStartDate, CompetitionEndDate, CompetitionLocation from Competitions";


            //Create the command object
            using SqlCommand cmd = new SqlCommand(cmdText, connection);


            //We create a SqlDataReader... so that we can read our data from the database.
            using SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read()) // Read each row returned in query
            {
                Guid CompetitionId = new Guid(reader.GetString(0));
                string competitionName = reader.GetString(1);
                DateTime startDate = reader.GetDateTime(2);
                DateTime endDate = reader.GetDateTime(3);
                string location = reader.GetString(4);


                Competition competition = new(CompetitionId, competitionName, startDate, endDate, location);
                competitions.Add(competition);                                                                              
            }
            connection.Close();


            return competitions;
        }
}