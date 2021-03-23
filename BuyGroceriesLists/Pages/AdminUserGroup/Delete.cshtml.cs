using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;

namespace BuyGroceriesLists.Pages.AdminUserGroup
{
    public class DeleteModel : PageModel
    {
        private readonly BuyGroceriesLists.Data.BuyGroceriesListsContext _context;

        public DeleteModel(BuyGroceriesLists.Data.BuyGroceriesListsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserGroup UserGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserGroup = await _context.UserGroup.FirstOrDefaultAsync(m => m.ID == id);

            if (UserGroup == null)
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

            UserGroup = await _context.UserGroup.FindAsync(id);

            if (UserGroup != null)
            {
                _context.UserGroup.Remove(UserGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
