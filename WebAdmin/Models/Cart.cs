using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdmin.Models
{
    public class CartItem
    {
        public Product _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }

    }
    //gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Add(Product _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.ID == _pro.ID);
                if( item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    _shopping_quantity = _quantity
                });
            }
                else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.ID == id);
            if(item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.Price * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.ID == id);
        }

        // tong so luong shopping
        public int Total_Qiantity_in_Cart()
        {
            return items.Sum(s => s._shopping_quantity);
        }

        public void ClearCart()
        {
            items.Clear();// xoa gio hang de thuc hien 1 order moi
        }
    }
}