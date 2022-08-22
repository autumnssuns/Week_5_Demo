namespace Week_5_Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            string filename = GetUserFilename();
            CheckIfFileExists(filename);
        }

        static string GetUserFilename()
        {
            Console.WriteLine("Enter the filename");
            string filename = Console.ReadLine();
            return filename;
        }

        static void CheckIfFileExists(string filename)
        {
            bool fileExists = File.Exists(filename);
            if (fileExists == true)
            {
                Console.WriteLine(File.GetCreationTime(filename));
                Console.WriteLine(File.GetLastWriteTime(filename));
                Console.WriteLine(File.GetLastAccessTime(filename));
            } else
            {
                Console.WriteLine("Error: The file does not exist");
            }
        }
    }
}