using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyEcomerce.ef;
using ShopyLibrary.Model;

namespace ShopyEcomerce
{
   public class BusinessLogic
    {
        
        
        public static IEnumerable<Cart> LoadOrdersAndCarts(IEnumerable<Cart> carts)
        {
            List<Cart> newcarts = new List<Cart>();
            foreach (var cart in  carts)
            {
                bool isvalid = false;
                if (newcarts.Count == 0)
                {
                    newcarts.Add(cart);
                }

                foreach (var item in newcarts)
                {

                    if (item.ProductName == cart.ProductName)
                    {
                        item.Quantity += cart.Quantity;
                        isvalid = true;


                    }


                }

                if (isvalid == false)
                {
                    newcarts.Add(cart);
                }
                
            }
            return newcarts;
        }
           public static IEnumerable<Order> LoadOrdersAndCarts(IEnumerable<Order> orders)
        {
            List<Order> newcarts = new List<Order>();
            foreach (var order in  orders)
            {
                bool isvalid = false;
                if (newcarts.Count == 0)
                {
                    newcarts.Add(order);
                }

                foreach (var item in newcarts)
                {

                    if (item.ProductsName == order.ProductsName)
                    {
                        item.Quantity += order.Quantity;
                        isvalid = true;


                    }


                }

                if (isvalid == false)
                {
                    newcarts.Add(order);
                }
                
            }
            return newcarts;
        }
           

    }
}
