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
    public class DeleteModel : PageModel
    {
        private readonly GroceryListRazorPage.Data.GroceryListRazorPageContext _context;

        public DeleteModel(GroceryListRazorPage.Data.GroceryListRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.GroceryList.FindAsync(id);

            if (Grocery != null)
            {
                _context.GroceryList.Remove(Grocery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
