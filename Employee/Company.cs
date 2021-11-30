using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Company
    {
        public List<Employee> Employees { get; }

        public Company()
        {
            Employees = new List<Employee>();
        }

        public void PrintEmployees()
        {
            foreach (Employee rabotnik in Employees)
            {
               
                Console.WriteLine($" {Employees.IndexOf(rabotnik)} { rabotnik.Family}  { rabotnik.FirstName} {rabotnik.Stag} {rabotnik.RankType} ");

            }
            Console.ReadKey();

        }
        public void PrintEmployees(int number)
        {

            Employee rabotnik = Employees[number];
         
                Console.WriteLine($" {Employees.IndexOf(rabotnik)} { rabotnik.Family}  { rabotnik.FirstName} {rabotnik.Stag} {rabotnik.RankType} ");
            Console.ReadKey();


        }
        public int CompareRankType (int x, int y)
        {
            if (Employees[x].RankType == Employees[y].RankType) return -1; //Должности равноценны
            if (Employees[x].RankType > Employees[y].RankType)
                                return x;
            else return y;
        }

        public static Company operator +(Company company, Employee employee)
        {
            company.Employees.Add(employee);
            return company;
        }

        public static Company operator -(Company company, Employee employee)
        {
            company.Employees.Remove(employee);
            return company;
        }

    }
}
