﻿using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebAPI.DAL;
using WebAPI.DAL.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBasecontext _context;
        public CountryService(DataBasecontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {

                var countries = await _context.Countries.ToListAsync();

                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {  
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? 
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country != null)
                {
                    return null;
                }
                else { 
                 _context.Countries.Remove(country);
                 await _context.SaveChangesAsync();
                return country;
                }
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifyDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
    }
}
