using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Silverlight.ApplicationCore.Constants;
using Silverlight.ApplicationCore.Entities;
using Silverlight.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.Infrastructure.Data
{
    public class SilverlightDbContextSeed
    {
        public static async Task SeedAsync(SilverlightDbContext silverlightDbContext)
        {

            if (silverlightDbContext.Database.IsSqlServer())
            {
                silverlightDbContext.Database.Migrate();
            }

            if (!await silverlightDbContext.Settings.AnyAsync())
            {
                await silverlightDbContext.Settings.AddRangeAsync(
                    GetPreconfiguredSettings());

                await silverlightDbContext.SaveChangesAsync();
            }
        }

        static IEnumerable<Settings> GetPreconfiguredSettings()
        {
            return new List<Settings>
            {
                new(){ Key = Constants.Settings.WEBSITE_NAME, Value = "Nam Phạm", CreationTime = DateTime.Now},
                new(){ Key = Constants.Settings.PHONE, Value = "0974433534", CreationTime = DateTime.Now},
                new(){ Key = Constants.Settings.ADDRESS, Value = "123", CreationTime = DateTime.Now},
                new(){ Key = Constants.Settings.FACEBOOK, Value = "https://something", CreationTime = DateTime.Now},
                new(){ Key = Constants.Settings.INSTAGRAM, Value = "https://something", CreationTime = DateTime.Now},
                new(){ Key = Constants.Settings.TWITTER, Value = "https://something", CreationTime = DateTime.Now},
            };
        }
    }

}
