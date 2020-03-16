using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Chief: Employee
    {    
        private decimal CountSalary()
        {
            decimal countedSalary = Salary;
            foreach (var subordinate in this.Subordinates)
            {
                if (subordinate.SalaryPerHour() >= 400)
                {
                    countedSalary *= 1.03m;
                }
                else
                {
                    countedSalary *= 1.015m;
                }
            }
            return 1 + (1 - Salary / countedSalary) ;
        }

        public override decimal SalaryPerHour()
        {
            return Salary / HoursPerMonth * BossIndex;
        }
        public Chief(int id, string fio, decimal salary, decimal hoursPerWeek, Department bossDepartment, List<Employee> subordinates) : base(id, fio, salary, hoursPerWeek)
        {
            BossDepartment = bossDepartment;
            Subordinates = subordinates;
            BossIndex = CountSalary();
        }

        public decimal BossIndex { get; private set; }
        public Department BossDepartment { get; private set; }
        public List<Employee> Subordinates { get; private set; }

        public void AddSubordinate(Employee newEmployee)
        {
            Subordinates.Add(newEmployee);
        }
        public void AddSubordinates(List<Employee> newEmployees)
        {
            Subordinates.AddRange(newEmployees);
        }
        public override void Info()
        {
            Console.WriteLine($"Employee ID: {Id}," +
                              $" fullname: {Fullname}," +
                              $" salary: {Salary}," +
                              $" hours worked per week: {HoursPerWeek}," +
                              $" salary per hour: {SalaryPerHour()}");
            Console.WriteLine();
            Subordinates.Sort();
            foreach (var subordinate in Subordinates)
            {    
                subordinate.Info();
            }
        }
    }
}