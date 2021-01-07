using System;
using System.IO;
namespace COPY_FILE_LARGE_SIZE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter source file: ");
            string sourcePath = Console.ReadLine();
            Console.WriteLine("Enter destination file: ");
            string destinationPath = Console.ReadLine();

            FileInfo sourceFile = new FileInfo(sourcePath);
            FileInfo destinationFile = new FileInfo(destinationPath);

            try
            {
                CopyFileUsingStream(sourceFile, destinationFile);
                Console.WriteLine("Copy is completed");
            }
            catch (IOException ioE)
            {
                Console.WriteLine(ioE.Message);
            }
        }

        private static FileInfo CopyFileUsingFileInfo(FileInfo fileSource, FileInfo fileDestination)
        {
            Console.WriteLine("Start copy using FileInfo");
            return fileSource.CopyTo(fileDestination.Name, overwrite: true);
        }

        private static FileInfo CopyFileUsingStream(FileInfo fileSource, FileInfo fileDestination)
        {
            Console.WriteLine("Start copy using Stream");
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader(fileSource.FullName);
                writer = new StreamWriter(fileDestination.FullName);
                char[] buffer = new char[1024];
                int length;
                while ((length = reader.Read(buffer)) > 0)
                {
                    writer.Write(buffer: buffer, index: 0, count: length);
                }
            }
            catch (IOException exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
            }
            return fileDestination;
        }

    }
}
