using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;

namespace BuyGroceriesLists.Pages.AdminUserGroup
{
    public class EditModel : PageModel
    {
        private readonly BuyGroceriesLists.Data.BuyGroceriesListsContext _context;

        public EditModel(BuyGroceriesLists.Data.BuyGroceriesListsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(UserGroup.ID))
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

        private bool UserGroupExists(int id)
        {
            return _context.UserGroup.Any(e => e.ID == id);
        }
    }
}
