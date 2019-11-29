using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolveHelthProject.Models
{
    public class ContactDetailsContext:DbContext
    {
        public ContactDetailsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ContactDetails> EvolveHelthContactDetails { get; set; }
    }
}
