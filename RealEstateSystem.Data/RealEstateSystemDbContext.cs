using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data
{
    public class RealEstateSystemDbContext :IdentityDbContext<ApplicationUser>
    {

        public RealEstateSystemDbContext(DbContextOptions<RealEstateSystemDbContext> options)
            : base(options)
        {

        }


    }
}
