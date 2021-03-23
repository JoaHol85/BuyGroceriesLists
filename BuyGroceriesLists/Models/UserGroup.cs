using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyGroceriesLists.Models
{
    public class UserGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
        public int ProductListId { get; set; }
        public string Password { get; set; }
        public List<Member> MemberList { get; set; }
    }
}
