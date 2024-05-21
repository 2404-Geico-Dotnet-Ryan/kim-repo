class Gymnast
{
    public string Fname { get; set; }
    public string Lname { get; set; }
    public DateTime DOB { get; set; }
    public string Username { get; set; }
    public Guid GymnastId { get; set; }


        public Gymnast()
    {
        Fname = "";
        Lname = "";
        DOB = DateTime.MinValue;
        Username = "";
    }
        public Gymnast(string username, string fname, string lname, DateTime dob)
    {
        Username = username;
        Fname = fname;
        Lname = lname;
        DOB = dob;
        GymnastId = Guid.NewGuid();
    }
        public override string ToString()
    {
        return "{fname:" + Fname
        + ",lname:" + Lname
        + ",dob:" + DOB
        + ",username:" + Username
        + ",gymnastId:" + GymnastId + "}";
    }
}