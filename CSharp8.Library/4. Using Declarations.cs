using System.IO;
// the using statements above are just shortcuts so we write less code

namespace CSharp8.Library
{
    public static class UsingDeclarations
    {
        public static int OLD_ConvertFiles()
        {
            int output = 0;

            // what this using does, it says => since the StreamReader implements IDisposable, I know there's a dispose method
            // at the end of the curly brace I'll call dispose on StreamReader so we won't keep it open longer than needed
            using (var inputFile = new StreamReader(@".\TestFile.txt"))
            {
                using (var outputFile = new StreamWriter(@".\OutputFile.txt"))
                {
                    string line;
                    while ( (line = inputFile.ReadLine()) != null)
                    {
                        outputFile.WriteLine(line);
                        output += 1;
                    }
                }
            }
            return output;
        }

        public static int NEW_ConvertFiles()
        {
            int output = 0;

            // no curly braces. Once the variable goes out of scope, it'll call the dispose method on the StreamReader
            // less nesting, more readable thanks to these 'using declarations'
            using var inputFile = new StreamReader(@".\TestFile.txt");
            using var outputFile = new StreamWriter(@".\OutputFile.txt");

            string line;

            while ((line = inputFile.ReadLine()) != null)
            {
                outputFile.WriteLine(line);
                output += 1;
            }
            return output;
        }
    }
}
