using System;

namespace CSharp7.Library.CSharp7.f._throw_expressions
{
    class Person
    {
        private string name, surname;

        public Person(string name, string surname)
        {
            /* OLD WAY
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (surname == null)
                throw new ArgumentNullException(nameof(surname));
            this.name = name;
            this.surname = surname;
            */

            // NEW WAY
            this.name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name));
            this.surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        // old
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Name));
                name = value;
            }
        }

        // new in C# 7
        public string Surname
        {
            get => surname;
            set => this.name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(Surname));
        }
    }

    class Program
    {

        private static void WriteExceptionMessage(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); Console.WriteLine();
            }
        }

        public static void Main()
        {
            WriteExceptionMessage(() => new Person("", "Angela"));
            WriteExceptionMessage(() => new Person("Andre", "null"));
            WriteExceptionMessage(() => new Person("Andre", "Angela").Name = null);
            WriteExceptionMessage(() => new Person("Andre", "Angela").Surname = null);
                
        }
    }
}
