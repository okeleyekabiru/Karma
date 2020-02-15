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
            int tempQuantity;

            Dictionary<string, Cart> Temp = new Dictionary<string, Cart>();

            foreach (var cart in carts)
            {
                if (Temp.ContainsKey(cart.ProductName))
                {
                    tempQuantity = Temp[cart.ProductName].Quantity += cart.Quantity;
                    Temp[cart.ProductName].Price *= tempQuantity;
                }
                else
                {
                    Temp.Add(cart.ProductName, cart);
                }

            }

            return Temp.Values.ToList();



        }
        public static IEnumerable<Order> LoadOrdersAndCarts(IEnumerable<Order> orders)
        {

            int tempQuantity;
            Dictionary<string, Order> Temp = new Dictionary<string, Order>();

           
            foreach (var order in orders)
            {
                if (Temp.ContainsKey(order.ProductsName))
                {
                  tempQuantity =  Temp[order.ProductsName].Quantity += order.Quantity;
                    Temp[order.ProductsName].ProductPrice *=  tempQuantity;
                }
                else
                {
                    Temp.Add(order.ProductsName, order);
                }

            }

            return Temp.Values.ToList();



        }


    }
}
