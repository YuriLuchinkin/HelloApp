using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class PersonModel : PageModel
    {
        List<Person> people;
        public List<Person> DisplayedPeople { get; set; }
        public PersonModel()
        {
            people = new List<Person>()
            {
                new Person{ Name="Tom", Age=23},
                new Person {Name = "Sam", Age=25},
                new Person {Name="Bob", Age=23},
                new Person{Name="Tom", Age=25}
            };
        }

        public void OnGet()
        {
            DisplayedPeople = people;
        }
        public void OnPostGreaterThan(int age)
        {
            DisplayedPeople = people.Where(p => p.Age > age).ToList();
        }
        public void OnPostLessThan(int age)
        {
            DisplayedPeople = people.Where(p => p.Age < age).ToList();
        }
    }
}