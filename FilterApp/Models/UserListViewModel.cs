using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FilterApp.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList Companies { get; set; }
        public string Name { get; set; }
    }
}