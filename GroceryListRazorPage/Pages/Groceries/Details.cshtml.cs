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
    public class DetailsModel : PageModel
    {
        private readonly GroceryListRazorPage.Data.GroceryListRazorPageContext _context;

        public DetailsModel(GroceryListRazorPage.Data.GroceryListRazorPageContext context)
        {
            _context = context;
        }

        public Grocery Grocery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.GroceryList.FirstOrDefaultAsync(m => m.Id == id);

            if (Grocery == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
