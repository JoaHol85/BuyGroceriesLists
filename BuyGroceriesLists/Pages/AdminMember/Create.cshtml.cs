using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;

namespace BuyGroceriesLists.Pages.AdminMember
{
    public class CreateModel : PageModel
    {
        private readonly BuyGroceriesLists.Data.BuyGroceriesListsContext _context;

        public CreateModel(BuyGroceriesLists.Data.BuyGroceriesListsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
