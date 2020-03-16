using System;

namespace Lab2
{
    public class Employee: IComparable<Employee>
    {
        public Employee(int id, string fio, decimal salary, decimal hoursPerWeek)
        {
            Id = id;
            Fullname = fio;
            Salary = salary;
            HoursPerWeek = hoursPerWeek;
            HoursPerMonth = HoursPerWeek * 4;
        }
        public int Id { get; private set; }
        public string Fullname { get; private set; }
        public decimal Salary { get; set; }
        public decimal HoursPerWeek { get; set; }
        public decimal HoursPerMonth { get; set; }

        public virtual decimal SalaryPerHour()
        {
            return Salary / HoursPerMonth;
        }

        public virtual void Info()
        {
            Console.WriteLine($"Employee ID: {Id}, fullname: {Fullname}, salary: {Salary}, hours worked per week: {HoursPerWeek}, salary per hour: {SalaryPerHour()}");
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return (int) (other.SalaryPerHour() - SalaryPerHour());
        }
    }
}