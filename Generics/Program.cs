using Generics.Data;
using Generics.Generics.Entities;
using Generics.Generics.Repositories;
using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Option");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    // STACK
                    StackClass.StackDoubles();
                    StackClass.StackStrings();
                    break;
                case 2:

                    //---- Employee

                    // Employee Repository without Generics
                    EmployeeRepositoryNOgenerics employeeRepository = new EmployeeRepositoryNOgenerics();
                    AddEmployeeWithoutGeneric(employeeRepository);

                    // Employee WITH Generics
                   var  genericrepo = new SqlRepository<Employee>(new StorageAppDBContext());
                    AddEmplyeesWithGeneric(genericrepo);

                    GetEmployeeById(genericrepo);
                    WriteAllToConsole(genericrepo);

                    //---- Managers
                   // AddManagers(SqlRepository employee) ;



                    //---- Organizations

                    GenericRepository<Organization> OrganizationRepo = new GenericRepository<Organization>();
                    AddOrganizations(OrganizationRepo);
                   // WriteAllToConsole(OrganizationRepo);

                    Console.ReadLine();


                    break;

                default:
                    break;
            }
            




        }

        private static void AddManagers(IRepository<Manager> ManagerRepository) 
        {
            ManagerRepository.Add(new Manager { FirstName = "Sara" });
            ManagerRepository.Add(new Manager { FirstName = "Henry" });
            ManagerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> Repository)
        {
            var items = Repository.GetAll();

            foreach (var item in items)
            {
                Console.WriteLine(item);

            }
        }

        private static void GetEmployeeById(IRepository<Employee> genericrepo)
        {
            var employee = genericrepo.GetById(2);
            Console.WriteLine($"Employee With ID 2 =  {employee.FirstName}" );
        }

        private static void AddEmplyeesWithGeneric(IRepository<Employee> genericrepo)
        {
            genericrepo.Add(new Employee { Id = 1, FirstName = "JuliaGENERIC" });
            genericrepo.Add(new Employee { FirstName = "MAriaGENERIC" });
            genericrepo.Add(new Employee { FirstName = "AnaGENERIC" });
            genericrepo.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> OrganizationRepo)
        {
            OrganizationRepo.Add(new Organization { Name = "Orga 1" });
            OrganizationRepo.Add(new Organization { Name = "Orga 2", City = "Medellin" });
            OrganizationRepo.Add(new Organization { Name = "Orga 3" });
            OrganizationRepo.Save();
        }

        private static void AddEmployeeWithoutGeneric(EmployeeRepositoryNOgenerics employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "maria" });
            employeeRepository.Add(new Employee { FirstName = "ana" });
            employeeRepository.Add(new Employee { FirstName = "vero" });
            employeeRepository.Save();
        }



    }
}
