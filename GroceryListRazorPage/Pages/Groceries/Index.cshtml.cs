using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryListRazorPage.Data;
using GroceryListRazorPage.Models;

namespace GroceryListRazorPage.Pages.Groceries
{
    public class IndexModel : PageModel
    {
        private readonly GroceryListRazorPage.Data.GroceryListRazorPageContext _context;

        public IndexModel(GroceryListRazorPage.Data.GroceryListRazorPageContext context)
        {
            _context = context;
        }

        public IList<Grocery> Grocery { get;set; }

        public async Task OnGetAsync()
        {
            Grocery = await _context.GroceryList.ToListAsync();
        }
    }
}
