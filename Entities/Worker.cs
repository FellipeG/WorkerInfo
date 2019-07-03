using System.Collections.Generic;
using WorkerInfo.Entities.Enums;

namespace WorkerInfo.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> HourContract { get; private set; }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            HourContract = new List<HourContract>();
        }

        public void AddContract(HourContract contract)
        {
            HourContract.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            HourContract.Remove(contract);
        }

        public double Income(int year, int month)
        {
            List<HourContract> contracts = HourContract.FindAll(contract => contract.Date.Month == month && contract.Date.Year == year);
            double totalIncome = BaseSalary;
            foreach(HourContract contract in contracts)
            {
                totalIncome += contract.TotalValue();
            }

            return totalIncome;
        }
    }
}
