using System;
using System.IO;
using System.Text;

namespace SUM_NUMBER_FILE_TEXT
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int sum = 0;
                using (StreamReader newStreamReader = new StreamReader("Number.txt", new UTF8Encoding()))
                {
                    string line = string.Empty;
                    while ((line = newStreamReader.ReadLine()) != null)
                    {
                        try
                        {
                            int number = int.Parse(line);
                            sum += number;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                Console.WriteLine($"Sum of numbers in file Number.txt: {sum}");
            }
            catch (IOException exIO)
            {
                Console.WriteLine(exIO.Message);
            }
            
        }
    }
}
