using Generics.Generics.Entities;
using System;
using System.Collections.Generic;

namespace Generics.Generics.Repositories
{
    public class EmployeeRepositoryNOgenerics
    {
        // THIS CLASS is WITHOUT GENERICS
        private readonly List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Save()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
