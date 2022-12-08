using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspCore7App.Data;
using AspCore7App.Models;
using System.Reflection.Metadata;

namespace AspCore7App.Pages
{
    public class CountriesUsingRepositoryPatternModel : PageModel
    {
        private readonly ICountryRepository _countryRepo;

        public CountriesUsingRepositoryPatternModel(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IEnumerable<Country> Country { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // take 3 most populous countries
            Country = (_countryRepo.GetAllCountries())
                .OrderByDescending(c => c.Population)
                .Take(3); ;

        }
    }

    public interface ICountryRepository
    {
        Country? GetCountry(string name);

        IEnumerable<Country> GetAllCountries();

        void AddCountry(Country country);

        void SaveChanges();
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
            => _context = context;

        public void AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        
        public Country? GetCountry(string name)
        {
            return _context.Countries.SingleOrDefault(c => c.Name == name);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    }
