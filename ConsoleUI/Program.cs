/*
using System;
namespace ConsoleUI
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Add(4,3));

            // Add() as a local method that only works inside the Main() method
            
            static double Add (double firstNumber, double secondNumber)
            {
                return firstNumber + secondNumber;
            }
        }
    }
}
*/


// may ignore all entry point ceremony and only have the following and it runs just fine !!!
// C# 9 expects a class file (Program.cs) that has top level calls (no namespace, no class, no main method) => the file is assumed to be the entry point of your app !

// top level call must be at the top, can't add anything else like a class before ...

using System;

Console.WriteLine("Hello World!");
Console.WriteLine(Add(4, 3));

static double Add(double firstNumber, double secondNumber)
{
    return firstNumber + secondNumber;
}
