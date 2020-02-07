using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Web_Product.Models
{
    public class Items
    {
        public int id {get;set;}
        public string title {get;set;}
        public int rate {get;set;}
        public int price {get;set;}
        public string desc {get;set;}
        public int total_item_in_cart {get;set;}
        public string image {get;set;}

        [ForeignKey("CartsId")]
        public int CartsId{get;set;}=0;
        public Carts Carts {get;set;}
    }
}