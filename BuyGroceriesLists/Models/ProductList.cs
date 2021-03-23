using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyGroceriesLists.Models
{
    public class ProductList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
    }
}
