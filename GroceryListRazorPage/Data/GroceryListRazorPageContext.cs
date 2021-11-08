using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryListRazorPage.Models;

namespace GroceryListRazorPage.Data
{
    public class GroceryListRazorPageContext : DbContext
    {
        public GroceryListRazorPageContext (DbContextOptions<GroceryListRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<GroceryListRazorPage.Models.Grocery> GroceryList { get; set; }
    }
}
