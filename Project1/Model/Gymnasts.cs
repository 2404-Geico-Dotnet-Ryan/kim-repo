class Gymnasts
{
    public string Fname { get; set; }
    public string Lname { get; set; }
    public long DOB { get; set; }
    public int GymnastId { get; set; }

        public Gymnasts()
    {
        Fname = "";
        Lname = "";
    }
        public Gymnasts(string fname, string lname, long dob, int gymnastId)
    {
        Fname = fname;
        Lname = lname;
        DOB = dob;
        GymnastId = gymnastId;
    }
        public override string ToString()
    {
        return "{fname:" + Fname
        + ",lname:" + Lname
        + ",dob:" + DOB
        + ",gymnastId:" + GymnastId + "}";
    }
}