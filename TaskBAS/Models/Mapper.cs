using System;
using System.Collections.Generic;

namespace TaskBAS.Models
{
    public static class Mapper
    {
		public static List<Employee> ToEmployeeList(this string[] lines)
		{
			List<Employee> lst = new List<Employee>();

            foreach(string s in lines)
            {
                int id = int.Parse(s.Split(' ')[0]);
                string name = s.Split(' ')[1];
                string val = s.Split(' ')[2];

                if (int.Parse(val) <= 50) {
                    lst.Add(new Daily(id, name, val));
                }
                else
                {
                    lst.Add(new Monthly(id, name, val));
                }
            }
			return lst;
		}
    }
}
