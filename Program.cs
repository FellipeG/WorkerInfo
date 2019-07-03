using System;
using WorkerInfo.Entities;
using WorkerInfo.Entities.Enums;
using System.Globalization;

namespace WorkerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level(Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("How many contracts to this worker? ");
            int contractNumbers = int.Parse(Console.ReadLine());


            Worker worker = new Worker(name, workerLevel, baseSalary, new Department(departmentName));
            for(int i=1; i<=contractNumbers; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                worker.AddContract(new HourContract(date, valuePerHour, hours));
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine();
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine("Income for "+ month + "/" + year + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
