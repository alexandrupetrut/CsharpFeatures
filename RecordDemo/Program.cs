using RecordDemo;
using System;


Record_1 record1_a = new("Alex", "Popa");
Record_1 record1_b = new("Alex", "Popa");
Record_1 record1_c = new("Sue", "Peets");

Class_1 class1_a = new("Alex", "Popa");
Class_1 class1_b = new("Alex", "Popa");
Class_1 class1_c = new("Sue", "Peets");

Console.WriteLine("Record Type:");
Console.WriteLine($"To String: {record1_a}");  // overrides ToString() and shows the members too, way more readable
                                               // the concept of records act more like value types is shown next because the values may be the same despite being two different objects
Console.WriteLine($"Are the two objects equal: {Equals(record1_a, record1_b)}");  // it will say YES - because behind the scenes it also overrides Equals() method
Console.WriteLine($"Are the two objects == (equal): {record1_a == record1_b}");  // it will say YES, despite being a different equality check (this was overriden too...)
Console.WriteLine($"Are the two objects != ( notequal): {record1_a != record1_c}");  // it will say YES
Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(record1_a, record1_b)}");  // it will say NO, they're not in the same location
Console.WriteLine($"Hash code of object A: {record1_a.GetHashCode()}");  // 1152317016
Console.WriteLine($"Hash code of object B: {record1_b.GetHashCode()}");  // 1152317016  (hash code was overridden to be all about the value, not about the address too)
Console.WriteLine($"Hash code of object C: {record1_c.GetHashCode()}");  // 1290776147

Console.WriteLine();
Console.WriteLine("***************************************");
Console.WriteLine();

Console.WriteLine("Class Type:");
Console.WriteLine($"To String: {class1_a}");
Console.WriteLine($"Are the two objects equal: {Equals(class1_a, class1_b)}"); // it will say NO
Console.WriteLine($"Are the two objects == (equal): {class1_a == class1_b}"); // it will say NO
Console.WriteLine($"Are the two objects != (not equal): {class1_a != class1_c}"); // it will say YES
Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(class1_a, class1_b)}"); // it will say NO
Console.WriteLine($"Hash code of object A: {class1_a.GetHashCode()}");  // 54267293
Console.WriteLine($"Hash code of object B: {class1_b.GetHashCode()}");  // 18643596
Console.WriteLine($"Hash code of object C: {class1_c.GetHashCode()}");  // 33574638

Console.WriteLine();
Console.WriteLine("***************************************");
Console.WriteLine();

// records are deconstructed properly based on the order of declared parameters ... into tuples
var (fn, ln) = record1_a;
Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");
// classes would require to write that ourselves ...
class1_a.Deconstruct(out var f, out var l);
Console.WriteLine($"The value of f is {f} and the value of l is {l}");

Console.WriteLine();
Console.WriteLine("***************************************");
Console.WriteLine();

// records allow us to use the original value of the copy and change a few things if we want to override stuff ~
Record_1 record1_d = record1_a with
{
    FirstName = "Meow"
};
Console.WriteLine($"Meow's record: {record1_d}");

Console.WriteLine();
Console.WriteLine("***************************************");
Console.WriteLine();

Record_2 record2_a = new("Alex", "Popa");
Console.WriteLine($"Record2_a's Value : {record2_a}");  // despite FirstName also being in the object .. the internal is throwing it off and can't be seen
Console.WriteLine($"Record2_a's First Name : {record2_a.FirstName} and Last Name : {record2_a.LastName}");  // it all shows up
Console.WriteLine(record2_a.SayHello());  // makes proper use of the nickname property




// **************************
// DO NOT DO ANY OF THE BELOW
// **************************

public record Record_3  // no constructor so no deconstructor by default
{
    // this works, but the set makes the record mutable which is BAD !
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

// Don't just make clones all over to update state to go around imutability, otherwise use classes
/* this works for like one property or so, but too much would be better with classes
 Record_1 record1_d = record1_a with
 {
     FirstName = "Meow"
 };
*/
