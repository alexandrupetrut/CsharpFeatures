using System;
using System.IO;
using System.Threading.Tasks;

namespace CSharp6.Library.f.__await__in_Catch_and_Finally
{
    class Demo
    {
        //  C# 5  =>  not possible to call async operations in catch{...} and finally{...}  by specifying await
        public void Old()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@"E:\ReadwriteFolder\demo.txt");
                string s = reader.ReadToEnd();
                Console.WriteLine(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //  C# 6  => can write await operations in 'catch' and 'finally' => async operations when encountering certain exceptions or require finally block cleanups
        StreamReader read = null;
        public async void New()
        {
            try
            {
                read = new StreamReader(@"E:\ReadwriteFolder\demo.txt");
                string s = read.ReadToEnd();
                Console.WriteLine(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Log();
            }
            finally
            {
                await Close();
            }
        }
        private async Task Log()
        {
            Console.WriteLine( "Date : {0} && Time : {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString() );
        }
        private async Task Close()
        {
            if (read != null)
                read.Close();
        }
    }
}
