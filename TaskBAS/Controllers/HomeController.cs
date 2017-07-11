using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskBAS.Models;
using TaskBAS.ViewModels;
using Microsoft.Extensions.Configuration;

namespace TaskBAS.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _iconfiguration;

        public HomeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            BaseViewModel bv = new BaseViewModel();

            List<Employee> employees = new List<Employee>()
            {
                new Monthly(1, "Oleg", "100"),
			    new Monthly(2, "Alex", "200"),
			    new Monthly(3, "Arman", "900"),
			    new Daily(4, "Bruno", "50"),
			    new Monthly(5, "Max", "600"),
			    new Daily(6, "Borya", "10"),
			    new Daily(7, "Rusya", "30"),
			    new Monthly(8, "Iska", "500"),
			    new Monthly(9, "Bob", "1000"),
			    new Daily(10, "Obama", "20")
            };

            string path = _iconfiguration.GetSection("FilePath").Value;

            System.IO.File.WriteAllText(path, String.Empty);

            FileInfo fi = new FileInfo(path);

            using (StreamWriter sw = fi.AppendText())
            {
                foreach (var emp in employees)
                {
                    sw.WriteLine(emp.Id + " " + emp.Name + " " + emp.Value);
                }
            }

            try 
            {
                string extension = Path.GetExtension(path);
                if (!string.Equals(extension, ".txt"))
                {
                    throw new FileFormatException("Wrong File Extension");
                }
                else
                {
                    List<Employee> empLst = System.IO.File.ReadAllLines(path).ToEmployeeList();

                    foreach (Employee emp in empLst)
					{
						emp.MonthlyAvarage();
					}

                    bv.All = empLst = empLst.OrderByDescending(m => m.AvarageSalary).ThenBy(m => m.Name).ToList();
                    bv.FirstFive = empLst.GetRange(0, 5).Select(m => m.Name).ToList();
                    bv.LastThree = empLst.GetRange(employees.Count() - 3, 3).Select(m => m.Id).ToList();
                }
            }
            catch(FileFormatException ex)
            {
                throw new Exception(ex.Message);
            }

            return View(bv);
        }
    }

    public class FileFormatException : System.Exception
    {
        public FileFormatException() : base()
        { }

        public FileFormatException(String message) : base(message)
		{ }
    }


}
