using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalsAPI.Models;

namespace AnimalsAPI.Data
{
    public class AnimalsAPIContext : DbContext
    {
        public AnimalsAPIContext (DbContextOptions<AnimalsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AnimalsAPI.Models.Animal> Animal { get; set; }
    }
}
