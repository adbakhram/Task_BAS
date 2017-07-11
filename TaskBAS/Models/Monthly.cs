using System;
namespace TaskBAS.Models
{
    public class Monthly : Employee
    {
        public Monthly(int id, string name, string salary)
        {
            Id = id;
            Name = name;
            Value = salary;
        }

        public override void MonthlyAvarage()
        {
            AvarageSalary = double.Parse(Value);
        }
    }
}
