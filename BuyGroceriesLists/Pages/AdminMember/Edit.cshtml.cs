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

namespace BuyGroceriesLists.Pages.AdminMember
{
    public class EditModel : PageModel
    {
        private readonly BuyGroceriesLists.Data.BuyGroceriesListsContext _context;

        public EditModel(BuyGroceriesLists.Data.BuyGroceriesListsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Member
                .Include(m => m.Group).FirstOrDefaultAsync(m => m.ID == id);

            if (Member == null)
            {
                return NotFound();
            }
           ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "ID", "ID");
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

            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.ID))
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

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.ID == id);
        }
    }
}
