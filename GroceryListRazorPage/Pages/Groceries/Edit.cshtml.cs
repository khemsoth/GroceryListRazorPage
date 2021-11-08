using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryListRazorPage.Data;
using GroceryListRazorPage.Models;

namespace GroceryListRazorPage.Pages.Groceries
{
    public class EditModel : PageModel
    {
        private readonly GroceryListRazorPage.Data.GroceryListRazorPageContext _context;

        public EditModel(GroceryListRazorPage.Data.GroceryListRazorPageContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grocery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(Grocery.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroceryExists(int id)
        {
            return _context.GroceryList.Any(e => e.Id == id);
        }
    }
}
