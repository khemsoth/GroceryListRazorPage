using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryListRazorPage.Data;
using GroceryListRazorPage.Models;

namespace GroceryListRazorPage.Pages.Groceries
{
    public class CreateModel : PageModel
    {
        private readonly GroceryListRazorPage.Data.GroceryListRazorPageContext _context;

        public CreateModel(GroceryListRazorPage.Data.GroceryListRazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grocery Grocery { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GroceryList.Add(Grocery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
