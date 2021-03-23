using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;

namespace BuyGroceriesLists.Pages.AdminProductList
{
    public class DeleteModel : PageModel
    {
        private readonly BuyGroceriesLists.Data.BuyGroceriesListsContext _context;

        public DeleteModel(BuyGroceriesLists.Data.BuyGroceriesListsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductList ProductList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductList = await _context.ProductList.FirstOrDefaultAsync(m => m.ID == id);

            if (ProductList == null)
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

            ProductList = await _context.ProductList.FindAsync(id);

            if (ProductList != null)
            {
                _context.ProductList.Remove(ProductList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
