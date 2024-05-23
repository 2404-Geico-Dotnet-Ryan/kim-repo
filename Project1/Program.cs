using System.Configuration.Assemblies;
using System.Data;
using System.Security.Cryptography;

class Program
{
    //static GymnastService gs = new();
    static Gymnast? currentGymnast = null;

    static void Main(string[] args)
    {
        Presentation.MainMenu();
    }

}