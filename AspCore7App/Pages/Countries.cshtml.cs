using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspCore7App.Data;
using AspCore7App.Models;

namespace AspCore7App.Pages
{
    public class CountriesModel : PageModel
    {
        private readonly AspCore7App.Data.ApplicationDbContext _context;

        public CountriesModel(AspCore7App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Countries != null)
            {
                // take 3 most populous countries
                Country = await _context.Countries
                    .OrderByDescending(c => c.Population)
                    .Take(3)
                    .ToListAsync();
            }
        }
    }
}
