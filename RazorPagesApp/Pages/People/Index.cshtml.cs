using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesApp.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Person> People { get; set; }
        public IndexModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            People = _context.People.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.People.FindAsync(id);

            if (product != null)
            {
                _context.People.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}