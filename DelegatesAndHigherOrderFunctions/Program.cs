using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndHigherOrderFunctions
{
    class Program
    {
        private static bool EvenNumbersMethod(int number) => number % 2 == 0;
        private static void Method1(string data) => Console.WriteLine("Method1: " + data);
        private static void Method2(string data) => Console.WriteLine("Method2: " + data);

        delegate bool MyFunc(int number);
        delegate void TransformDelegate(string data); // returns a void and takes a string parameter
        /* What's a delegate ?   
         *   => a function pointer ?   Similar to a C function pointer, but it is a strongly typed function pointer
         *   At compile time, the compiler takes the delegate and converts it to a class definition. The class name will be TransformDelegate or whatever we call the delegate.
         *   The class descends from a class called MulticastDelegate. So Delegates are just fancy classes. And descend from MulticastDelegate. 
         *   The delegate has a method called Invoke() that is used under the hood
             Delegates are first class citizens of C# => can be passed to methods as arguments and can be returned from methods as return types
        */

        // LINQ is functional programming => its methods take functions/delegates as arguments, it uses higher order functions
        // Functional programming - no classes, just passing functions to functions, as such passing different functions as arguments you get different behaviour (similar to class polymorphism)

        private static IEnumerable<Movie> GetAllMovies()
        {
            yield return new Movie("Star Wars Episode IV: A New Hope", "StarWarsEpisodeIV.jpg", "Sci-Fi", 1977);
            yield return new Movie("Star Wars Episode V: The Empire Strikes Back", "StarWarsEpisodeV.jpg", "Sci-Fi", 1980);
            yield return new Movie("Star Wars Episode VI: Return of the Jedi", "StarWarsEpisodeVI.jpg", "Sci-Fi", 1983);
            yield return new Movie("Star Wars Episode I The Phantom Menace", "StarWarsEpisodeI.jpg", "Sci-Fi", 1999);
            yield return new Movie("Star Wars Episode II: Attack of the Clones", "StarWarsEpisodeII.jpg", "Sci-Fi", 2002);
            yield return new Movie("Star Wars Episode III: Attack of the Sith", "StarWarsEpisodeIII.jpg", "Sci-Fi", 2005);
            yield return new Movie("Olympus Has Fallen", "Olympus_Has_Fallen_poster.jpg", "Action", 2013);
            yield return new Movie("G.I. Joe: Retaliation", "GIJoeRetaliation.jpg", "Action", 2013);
            yield return new Movie("Jack the Giant Slayer", "jackgiantslayer4.jpg", "Action", 2013);
            yield return new Movie("Drive", "FileDrive2011Poster.jpg", "Action", 2011);
            yield return new Movie("Sherlock Holmes", "FileSherlock_Holmes2Poster.jpg", "Action", 2009);
        }

        private static IEnumerable<Movie> s_AllMovies = GetAllMovies();

        static void Main(string[] args)
        {
            #region DELEGATES

            TransformDelegate a, b, c, d;
            // a = new TransformDelegate(Method1);
            a = Method1;  // ^ how does this work ? It's short for saying, HEY TransformDelegate instance, please delegate when called to this method
            b = Method2;

            d = a + b;  // multicast delegates so we can use += 
            d("World");

            var numbers = Enumerable.Range(0, 99);

            var evenNumbers = numbers.Where(delegate (int n)
            {
                return n % 2 == 0;
            });  // anonymous method - is a method with no name so you can call it on the go

            evenNumbers = numbers.Where(new Func<int, bool>(EvenNumbersMethod)); // Where needs a Func<int, bool> as predicate

            evenNumbers = numbers.Where(EvenNumbersMethod);  // same as previous, simplified

            evenNumbers = numbers.Where(n => n % 2 == 0); // lambda expression, simplified further and Linq became more feasible
                                                          // at compile time => compiler takes the lambda expression, creates an anonymous method that is a Func<int,bool>
                                                          // so behind the scenes, it's still down to the classic, exhausting long code, with no magic there

            Func<int, bool> myDel = n => n % 2 == 0;
            evenNumbers = numbers.Where(myDel);

            // MyFunc myFunc = EvenNumbersMethod;
            // evenNumbers = numbers.Where(myFunc);  cannot convert from MyFunc to System.Func<int, bool>  because it thinks of them as 2 different types
            // they look the same, they feel the same... but MyFunc is a delegate and at compile time the types differ (static language issue)
            #endregion



            #region Higher Order Functions

            var requiredYear = 2013;
            //var requiredMovie = s_AllMovies.Single(m => m.Year == requiredYear); // Single() throws exception if there's none or more than one ... unlike FirstOrDefault()
            // As such, we should implement our own Single() custom method

            var requiredMovie = s_AllMovies.SingleElseException(m => m.Year == requiredYear, matchedMovies =>
            {
                return new FilteredMovieException($"We were expecting to find exactly 1 movie for year {requiredYear}, but we found {matchedMovies.Count()} movies instead.");
            });

            Console.WriteLine($"{requiredMovie.Title}");

            #endregion
        }
    }

    static class EnumerableExtensions
    {
        public static T SingleElseException<T>(this IEnumerable<T> sequence, Func<T, bool> predicate, Func<IEnumerable<T>, Exception> exceptionFactory)
        {
            var matchedItems = new List<T>();
            foreach (var item in sequence)
            {
                if (predicate(item))
                    matchedItems.Add(item);
            }

            if (matchedItems.Count == 1)
                return matchedItems[0];

            throw exceptionFactory(matchedItems);
        }
    }
}