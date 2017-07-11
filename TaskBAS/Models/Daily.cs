using System;
namespace TaskBAS.Models
{
    public class Daily : Employee
    {
        public Daily(int id, string name, string salary)
        {
            Id = id;
            Name = name;
            Value = salary;
        }

        public override void MonthlyAvarage()
        {
            AvarageSalary = 20.8 * 8 * double.Parse(Value);
        }
    }
}
