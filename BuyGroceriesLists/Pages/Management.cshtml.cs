using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BuyGroceriesLists.Data;
using BuyGroceriesLists.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BuyGroceriesLists.Pages
{
    public class ManagementModel : PageModel
    {
        private readonly BuyGroceriesListsContext _context;
        public ManagementModel(BuyGroceriesListsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductList ProductList { get; set; }
        [BindProperty]
        public UserGroup UserGroup { get; set; }
        [BindProperty]
        public Member Member { get; set; }
        [BindProperty]
        public Product Product { get; set; }


        [BindProperty]
        public int BuyListId { get; set; }
        [BindProperty]
        public int SelectedGroupId { get; set; }
        [BindProperty]
        public string AddUserToGroupPassword { get; set; }
        [BindProperty]
        public string PasswordErrorMessage { get; set; }


        [BindProperty(SupportsGet = true)]
        public int DeleteListId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int DeleteGroupId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int DeleteFromGroupId { get; set; }


        public List<ProductList> ListOfProductLists { get; set; }
        public List<UserGroup> ListOfUserGroups { get; set; }
        public List<ProductList> ListOfUserLists { get; set; }
        public List<UserGroup> ListOfCreatedUserGroups { get; set; }
        public List<ProductList> ListOfAllProductLists { get; set; }
        public List<Member> ListOfGroupsMemberIn { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if(DeleteListId != 0)
            {
                var q = await _context.ProductList.FirstOrDefaultAsync(q => q.ID == DeleteListId);
                _context.ProductList.Remove(q);
                await _context.SaveChangesAsync();
            }

            else if(DeleteGroupId != 0)
            {
                var q = await _context.UserGroup.FirstOrDefaultAsync(q => q.ID == DeleteGroupId);
                _context.UserGroup.Remove(q);
                await _context.SaveChangesAsync();
            }

            else if(DeleteFromGroupId != 0)
            {
                var q = await _context.Member.FirstOrDefaultAsync(q => q.ID == DeleteFromGroupId);
                _context.Member.Remove(q);
                await _context.SaveChangesAsync();
            }

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

            ListOfAllProductLists = await _context.ProductList.ToListAsync();
            ListOfUserGroups = await _context.UserGroup.ToListAsync();
            ListOfGroupsMemberIn = await _context.Member.Where(q => q.UserId == userId).ToListAsync();
            ListOfUserLists = await _context.ProductList.Where(l => l.CreatedByUserId == userId).ToListAsync();
            ListOfCreatedUserGroups = await _context.UserGroup.Where(l => l.CreatedByUserId == userId).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateGroupAsync()
        {
            UserGroup uGroup = new UserGroup();
            uGroup = UserGroup;
            uGroup.ProductListId = BuyListId;
            _context.UserGroup.Add(uGroup);
            await _context.SaveChangesAsync();
            return await OnGetAsync();
        }

        public async Task<IActionResult> OnPostCreateListAsync()
        {
            ProductList pList = new ProductList();
            pList = ProductList;
            _context.ProductList.Add(pList);
            await _context.SaveChangesAsync();
            return await OnGetAsync();
        }

        public async Task<IActionResult> OnPostAddToGroupAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Member member = new Member();
            member = Member;
            member.UserGroupId = SelectedGroupId;
            member.Group = _context.UserGroup.FirstOrDefault(q => q.ID == SelectedGroupId);
            if (AddUserToGroupPassword == _context.UserGroup.FirstOrDefault(q => q.ID == SelectedGroupId).Password ||
                userId == _context.UserGroup.FirstOrDefault(q => q.ID == SelectedGroupId).CreatedByUserId)
            {
                _context.Member.Add(member);
                await _context.SaveChangesAsync();
            }
            else
            {
                PasswordErrorMessage = "Lösenordet stämmer inte.";
            }
            return await OnGetAsync();
        }

        public async Task<IActionResult> OnPostAddProductAsync()
        {
            Product product = new Product();
            product = Product;
            product.Bought = false;
            product.ProductListId = BuyListId;
            //product.ProductList = _context.ProductList.FirstOrDefault(q => q.ID == BuyListId);
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return await OnGetAsync();
        }


    }
}
