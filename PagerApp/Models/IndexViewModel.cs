using System.Collections.Generic;

namespace PagerApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}