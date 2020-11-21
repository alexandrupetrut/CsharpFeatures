/* 
 * Benefits of Records:
 *   - Simple to set up
 *   - Thread-safe => since it's immutable, it's by definition thread-safe (unless we use setters instead of init ...)
 *   - Easy/safe to share => I can pass these things around without having to worry about the info inside changing unexpectedly
 *  
 * When To Use Records:
 *   - Capturing external data that doesn't change (example: poll from WeatherService in Blazor demo)
 *   - When you have your own API calls  (a lot of time you get data from DB and send data to your APIs, without modifying it in between)
 *   - Processing data (you get data from DB and you do something with it or based upon it, but not changing it)
 *  
 * When NOT To Use Records:
 *   - When you need to change the data (example: Entity Framework - change tracking exists and updating values happens)
 *   - 
*/   

namespace RecordDemo
{
    // Records act like value types, but they are reference types
    // a Record is just a fancy class (class with pre-built code behind the scenes to make life easier)
    // it is immutable (uses init instead of set), the values can't be changed by default, by design - can be seen as a read-only class
    // can be made mutable, but that goes against its purpose
    public record Record_1(string FirstName, string LastName);

    // inheritance - records can inherit from another record, but not from a class
    public record User_1(int id, string FirstName, string LastName) : Record_1(FirstName, LastName);

    // at a high-level, the declaration of Class_1 is similar to Record_1 but it's not the same
    public class Class_1
    {
        // init allows you to set the value in a ctor or when you create the class, using curly braces
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Class_1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }

    // we can also create records with curly braces for further changes
    public record Record_2(string FirstName, string LastName)
    {
        // declaring the property explicitly and assigning the value being passed in
        internal string FirstName { get; init; } = FirstName;
        public string FullName { get => $"{FirstName} {LastName}"; }

        // full property
        private string _nickname = FirstName;
        public string Nickname
        {
            get { return _nickname.Substring(0,3); }
            init { }
        }

        // method
        public string SayHello()
        {
            return $"Hello {Nickname}";
        }
    }
}
