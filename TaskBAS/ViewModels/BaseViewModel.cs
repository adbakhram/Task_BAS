using System;
using System.Collections.Generic;
using TaskBAS.Models;

namespace TaskBAS.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            All = new List<Employee>();
            FirstFive = new List<string>();
            LastThree = new List<int>();
        }

        public List<Employee> All { get; set; }

        public List<String> FirstFive { get; set; }

        public List<int> LastThree { get; set; }

    }
}
