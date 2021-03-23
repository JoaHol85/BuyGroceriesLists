using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuyGroceriesLists.Models;

namespace BuyGroceriesLists.Data
{
    public class BuyGroceriesListsContext : DbContext
    {
        public BuyGroceriesListsContext (DbContextOptions<BuyGroceriesListsContext> options)
            : base(options)
        {
        }

        public DbSet<BuyGroceriesLists.Models.Product> Product { get; set; }

        public DbSet<BuyGroceriesLists.Models.ProductList> ProductList { get; set; }

        public DbSet<BuyGroceriesLists.Models.UserGroup> UserGroup { get; set; }

        public DbSet<BuyGroceriesLists.Models.Member> Member { get; set; }
    }
}
