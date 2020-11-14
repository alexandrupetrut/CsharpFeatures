using static System.Convert;

namespace CSharp6.Library.b._using_Static
{
    public class Demo
    {
        /// summary ///
        /// We can now use any static class as a namespace

        ///  C#5 => using too many  Convert.ToInt32() or Console.WriteLine()...etc.

        public int Age { get; set; } = System.Convert.ToInt32("34");


        ///  C#6 => set default value of a read-only properly
        public int Cashflow { get; set; } = ToInt32("5000");

    }
}
