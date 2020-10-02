using System.Collections.Generic;

namespace SortApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}