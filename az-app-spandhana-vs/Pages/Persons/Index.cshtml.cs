using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using az_app_spandhana_vs.Data;

namespace az_app_spandhana_vs.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly az_app_spandhana_vs.Data.AppDbContext _context;

        public IndexModel(az_app_spandhana_vs.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Persons != null)
            {
                Person = await _context.Persons.ToListAsync();
            }
        }
    }
}
