using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        public string FirstName { get; init; }
        public string Family { get; init; }
        public RankType RankType { get; init; }
        public int Stag { get; init; }
       
        public Employee(string firstname, string family , int stag, RankType ranktype)
          => (FirstName, Family, Stag, RankType) = (firstname, family, stag, ranktype);
    }
    public enum RankType
    {
        Worker,
        Manager,
        Foreman,
        DepartmentHead,
        Director
    }
}



