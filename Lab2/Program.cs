using System;
using System.Collections.Generic;
using static Lab2.Employee;
using static Lab2.Chief;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>() {
                new Employee(1, "Геральд Из Ривии", 30, 30),
                new Employee(2, "Губка БоБ Квадратные Штаны", 360, 20),
                new Employee(3, "Эцио Аудиторе Де Ференсе", 0, 40),
                new Employee(4, "Кадзима Гений", 10000, 50),
                new Employee(5, "Пак Мэн", 5, 1),

            };

            foreach (var employee in employees)
            {
                employee.Info();
            }
            Console.WriteLine();
            Chief cheif = new Chief(6, "Солид Снейк", 300, 56, Department.Dev, employees);
            cheif.Info();
            Console.WriteLine();
            Company company = new Company(cheif);
            company.GetAllEmployersInfo();
            Console.WriteLine($"\nEmployers count: {company.GetAllEmployersCount()}\n");
            company.ShowEmployersInfo();
        }
    }
}
