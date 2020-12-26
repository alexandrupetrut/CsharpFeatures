using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"Type: {type.Name}  -  BaseType: {type.BaseType}");

                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine($"\tProperty: {prop.Name}  -  PropertyType: {prop.PropertyType}");
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine($"\tField: {field.Name}");
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine($"\tMethod: {method.Name}");
                }
            }

            Console.WriteLine("------------------------------------------");

            var sample = new Sample { Name = "John", Age = 25 };
            var sampleType = typeof(Sample); // compiler knows the answer
            var sampleType2 = sample.GetType(); // compiler does not know, it gets executed at runtime 

            var nameProperty = sampleType.GetProperty("Name");
            Console.WriteLine($"Property: {nameProperty.GetValue(sample)}");

            var sampleMethod = sampleType.GetMethod("SampleMethod");
            sampleMethod.Invoke(sample, null);

            Console.WriteLine("------------------------------------------");

            assembly = Assembly.GetExecutingAssembly();
            var cutetypes = assembly.GetTypes().Where(t => t.GetCustomAttributes<CuteClassAttribute>().Count() > 0);
            foreach (var type in cutetypes)
            {
                Console.WriteLine(type.Name);

                var cutemethods = type.GetMethods().Where(m => m.GetCustomAttributes<CuteMethodAttribute>().Count() > 0);
                foreach (var method in cutemethods)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }


        [CuteClass]
        public class Sample
        {
            public string Name { get; set; }  // property
            public int Age;  // field

            [CuteMethod]
            public void SampleMethod() => Console.WriteLine("Hello from this sample method !");

            public void NoAttributeSampleMethod () { }
        }



        [AttributeUsage(AttributeTargets.Class)]
        public class CuteClassAttribute : Attribute { }

        [AttributeUsage(AttributeTargets.Method)]
        public class CuteMethodAttribute : Attribute { }
    }
}