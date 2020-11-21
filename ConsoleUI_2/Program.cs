using System;

Console.WriteLine("Hello World!");
Console.WriteLine(Add(4, 3));
static double Add(double firstNumber, double secondNumber)
{
    return firstNumber + secondNumber;
}


var p = new PersonModel { Id = 1, FirstName = "Alex", LastName = "Popa" };
// p.Id = 2 --- we want this to say  HEY ! CAN'T CHANGE ID NUMBER !!! => 
p.FirstName = "Alexandru";
Console.WriteLine($"Hello {p.FirstName} {p.LastName} with the ID of {p.Id}");


PersonModel p2 = new PersonModel();
var p3 = new PersonModel();

// known object type shorthand instantiation !!!
PersonModel p4 = new();

// can do this but it's getting unreadable so be careful !
PersonModel p5;
p5 = new();

public class PersonModel
{
    // with init you can change the value either in a constructor or when you first create the object
    // so this does not allow further modifications
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // can't do this !
    /*
        public void UpdateId(int newId)
        {
            Id = newId;
        }
    */

    // can do this ! Constructor allowed !
    /*
        public PersonModel(int id)
        {
            Id = id;
        }
    */
}