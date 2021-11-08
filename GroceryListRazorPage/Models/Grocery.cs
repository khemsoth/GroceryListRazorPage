using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryListRazorPage.Models
{
    public class Grocery
    {
        public int Id { get; set; }
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
