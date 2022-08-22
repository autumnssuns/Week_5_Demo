namespace ReadEmployee
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filename = "EmployeeDetails.txt";
            bool fileExists = File.Exists(filename);
            if (fileExists == true)
            {
                while (true)
                {
                    Console.WriteLine("The file indeed exists.");
                    Console.WriteLine(@"What do you want to do?
1. Display Summary
2. Write Data
3. Quit the program");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        DisplaySummary(filename);
                    }
                    else if (choice == "2")
                    {
                        WriteToFile(filename);
                    } else if (choice == "3")
                    {
                        Console.WriteLine("Quitting from the program");
                        break;
                    }
                }
            }
        }

        static void WriteToFile(string filename)
        {
            Console.WriteLine("What do you want to write, separate by commas?");
            string line = Console.ReadLine();
            // Start a streamwriter in appending mode so I don't lose data
            using (StreamWriter writer = new StreamWriter(filename, append: true))
            {
                writer.Write("\n" + line);
            }
        }

        static void DisplaySummary(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                int numberOfEmployees = 0;
                double averageSalary = 0,
                    maxSalary = double.MinValue,
                    minSalary = double.MaxValue;
                while (line != null)
                {
                    string[] data = line.Split(',');
                    int employeeId = int.Parse(data[0]);
                    string employeeName = data[1];
                    double salary = double.Parse(data[2]);
                    Console.WriteLine($"The employee {employeeName} has salary of {salary}");
                    averageSalary += salary;
                    if (salary > maxSalary)
                    {
                        maxSalary = salary;
                    }
                    if (salary < minSalary)
                    {
                        minSalary = salary;
                    }
                    numberOfEmployees++;
                    line = reader.ReadLine();
                }
                Console.WriteLine($"The average salary is {averageSalary / numberOfEmployees}, " +
                    $"the maximum salary is {maxSalary} " +
                    $"and the minimum salary is {minSalary}.");
            }
        }
    }
}