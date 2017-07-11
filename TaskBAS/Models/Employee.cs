using System;
namespace TaskBAS.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AvarageSalary { get; set; }
        public string Value { get; set; }

        public abstract void MonthlyAvarage();
    }
}
