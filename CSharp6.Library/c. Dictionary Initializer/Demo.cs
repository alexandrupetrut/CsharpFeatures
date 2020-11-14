using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6.Library.c._Dictionary_Initializer
{
    class Demo
    {
        //  C#5 => initializing values of keys in Dictionary Collection was confusing

        Dictionary<int, string> dictionaryInt = new Dictionary<int, string>()
        {
            {1, "Alex" },
            {2, "Ron" },
            {3, "Light" }
        };

        //  C#6 => directly initialize a value of a key
        Dictionary<int, string> dictionaryInteger = new Dictionary<int, string>()
        {
            [1] = "Alex",
            [2] = "Ron",
            [3] = "Light"
        };
    }
}
