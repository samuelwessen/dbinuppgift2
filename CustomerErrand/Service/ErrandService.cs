using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerErrand.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerErrand.Service
{
    public static class ErrandService
    {
        public static async Task AddNewErrandAsync(string description, DateTime creationTime, string customerFullName, string customerEmail, int? customerPhoneNr, string status, string category)
        {
            using DataContext context = new DataContext();

            context.Errand.Add(new Errand(description, creationTime, customerFullName, customerEmail, customerPhoneNr, status, category));
            await context.SaveChangesAsync();
        }

    }
}
