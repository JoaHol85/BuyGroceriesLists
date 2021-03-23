using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BuyGroceriesLists.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BuyGroceriesListsContext _context;
        public IndexModel(BuyGroceriesListsContext context)
        {
            _context = context;
        }

        public IList<Product> ListOfProducts { get; set; }
        public IList<ProductList> ListOfProductLists { get; set; }
        public int MyProperty { get; set; }

        [BindProperty(SupportsGet = true)]
        public int BoughtProductId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int DeleteProductId { get; set; }
        [BindProperty]
        public int SelectedListId { get; set; }             ///
        [BindProperty]
        public string UserId { get; set; }
        [BindProperty]
        public Product product { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (BoughtProductId != 0)
            {
                var p = _context.Product.FirstOrDefault(p => p.ID == BoughtProductId);
                p.Bought = true;
                SelectedListId = p.ProductListId;
                GetListProducts();
                await _context.SaveChangesAsync();
            }
            else if (DeleteProductId != 0)
            {
                var p = _context.Product.FirstOrDefault(p => p.ID == DeleteProductId);
                SelectedListId = p.ProductListId;
                _context.Product.Remove(p);
                await _context.SaveChangesAsync();
                GetListProducts();
            }

            // GET SPECIFIC USER LISTS
            if (userId != null)
            {
                List<ProductList> pList = new List<ProductList>();
                var q = _context.Member.Where(q => q.UserId == userId).ToList();
                foreach (var member in q)
                {
                    var x = _context.UserGroup.FirstOrDefault(x => x.ID == member.UserGroupId);
                    var y = _context.ProductList.FirstOrDefault(y => y.ID == x.ProductListId);
                    if (y != null)
                    {
                        pList.Add(y);
                    }
                }
                ListOfProductLists = pList;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostGetListAsync()
        {
            return await OnGetAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            GetListProducts();
            return await OnGetAsync();

            //Product p = new Product();
            //p = product;
            //p.UserID = UserId;
            //p.Bought = false;
            //_context.Product.Add(p);
            //_context.SaveChanges();
            //return RedirectToPage();
        }

        public string BoughtOrNot(bool bought)
        {
            return bought == true ? "Ja" : "Nej";
        }

        public void GetListProducts()
        {
            var q = _context.Product.Where(q => q.ProductListId == SelectedListId).ToList();
            ListOfProducts = q;
        }

    }
}
