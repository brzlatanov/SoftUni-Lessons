using System;
using System.Text;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {  
           StudentSystemContext databaseContext = new StudentSystemContext();
           databaseContext.Database.EnsureCreated();
        }
    }
}
