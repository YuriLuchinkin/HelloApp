using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
    
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AgeAsc, // по возрасту по возрастанию
        AgeDesc,    // по возрасту по убыванию
        CompanyAsc, // по компании по возрастанию
        CompanyDesc // по компании по убыванию
    }
}
