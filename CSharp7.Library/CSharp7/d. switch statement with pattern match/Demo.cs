using System;

namespace CSharp7.Library.CSharp7.d._switch_statement_with_pattern_match
{
    class Demo
    {
        public abstract class Account { }
        public class Student : Account { }
        public class Individual : Account
        {
            public double PercentageDiscount { get; set; }
        }
        public class Business : Account
        {
            public int Employees { get; set; }
        }
        public static double ApplyDiscount (Account account, double price)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (account is Student)
            {
                return 0;
            }
            if (account is Individual individual)
            {
                return price * (1 - individual.PercentageDiscount / 100);
            }
            if (account is Business business)
            {
                if (business.Employees <= 50)
                {
                    return price * 0.7;
                }
                return price * 0.9;
            }
            throw new InvalidOperationException();
        }

        // NEW WAY OF DOING THIS !!!   but order of case statements really matter => check case Business business !!!
        public static double ApplyNewDiscount(Account account, double price)
        {
            switch (account)
            {
                case null: throw new ArgumentNullException(nameof(account));

                case Student _:
                    return 0;

                case Individual individual:
                    return price * (1 - individual.PercentageDiscount / 100);

                case Business business when business.Employees <= 50:
                        return price * 0.7;

                case Business business:
                    return price * 0.9;

                default:
                    throw new InvalidOperationException();
            }
        }

        public static void Main()
        {
            var student = new Student();
            var individual = new Individual { PercentageDiscount = 50 };
            var smallBusiness = new Business { Employees = 20 };
            var largeBusiness = new Business { Employees = 100 };

            const int price = 100;

            Console.WriteLine($"Student:\t {ApplyDiscount(student, price)}");
            Console.WriteLine($"Individual:\t {ApplyNewDiscount(individual, price)}");
            Console.WriteLine($"SmallBusiness:\t {ApplyDiscount(smallBusiness, price)}");
            Console.WriteLine($"LargeBusiness:\t {ApplyNewDiscount(largeBusiness, price)}");
        }
    }
}
