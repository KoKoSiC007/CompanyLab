using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Company
    {
        public Company(List<Chief> employers)
        {
            Employees = employers;
        }

        public Company(Chief chief)
        {
            Employees = new List<Chief>(){ chief };
        }
        public List<Chief> Employees { get; set; }

        public void AddEmployee(Chief chief)
        {
            Employees.Add(chief);
        }

        public void ShowEmployersInfo()
        {
            List<Employee> companyEmployees = new List<Employee>();
            foreach (var chief in Employees)
            {
                companyEmployees.AddRange(chief.Subordinates);
                companyEmployees.Add(chief);
            }
            companyEmployees.Sort();
            foreach (var employee in companyEmployees)
            {
                Console.WriteLine(employee.Fullname + ' '+ employee.SalaryPerHour());
            }
        }
        public int GetAllEmployersCount()
        {
            int count = 0;
            foreach (var employer in Employees)
            {
                count += employer.Subordinates.Count;
            }

            return count;
        }

        public void GetAllEmployersInfo()
        {
            foreach (var chief in Employees)
            {
                foreach (var employee in chief.Subordinates)
                {
                    Console.WriteLine(employee.Fullname);
                }
            }
        }
    }
}