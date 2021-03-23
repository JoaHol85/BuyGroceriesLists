using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyGroceriesLists.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public UserGroup Group { get; set; }
        public int UserGroupId { get; set; }
    }
}
