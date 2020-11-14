using System.Collections.Generic;

namespace CSharp6.Library.g._Null_Conditional_Operator
{
    public class Company
    {
        public string Name { get; set; }
        public List<Engineer> Engineers { get; set; } = new List<Engineer>();
        public Company(string name) => Name = name;
    }

    public class Engineer
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Engineer (string name, Company company)
        {
            Name = name;
            Company = company;
        }
    }

    public class CoolDemo
    {
        public static void Main()
        {
            var mainCompany = new Company("Microsoft");
            var andrea = new Engineer("Andrea", null);
            var bob = new Engineer("Bob", mainCompany);
            var alice = new Engineer("Alice", mainCompany);

            mainCompany.Engineers.AddRange(new[] { bob, alice });

            System.Console.WriteLine(GetEmployerName(null));
            System.Console.WriteLine(CompanySize(null));

            System.Console.WriteLine(GetEmployerName(andrea));
            System.Console.WriteLine(CompanySize(andrea));

            System.Console.WriteLine(GetEmployerName(bob));
            System.Console.WriteLine(CompanySize(bob));
        }

        public static string GetEmployerName (Engineer engineer) => engineer?.Company?.Name;
        // {
        //    if (engineer == null || engineer.Company == null)
        //    return null;

        //    return engineer.Company.Name;
        // }

        public static int CompanySize(Engineer engineer) => engineer?.Company?.Engineers?.Count ?? 1;
        // {
        //    if (engineer != null)
        //    {
        //      var employer = engineer.Company;
        //      if (employer != null)
        //      return employer.Engineers != null ? employer.Engineers.Count : 1;
        //    }

        //    return 1;
        // }


    }
}
