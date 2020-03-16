using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using Shopy.Models;
using ShopyEcomerce.ef;

namespace ShopyEcomerce
{
    public class BusinessLogic
    {

 
        public static List<Cart> ListingCarts { get; set; } = new List<Cart>();

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
                    tempQuantity = Temp[order.ProductsName].Quantity += order.Quantity;
                    Temp[order.ProductsName].ProductPrice *= tempQuantity;
                }
                else
                {
                    Temp.Add(order.ProductsName, order);
                }

            }

            return Temp.Values.ToList();


        }



        public static byte[] GetImageFromByteArray(byte[] byteArray)

        {
            Stream stream = new MemoryStream(byteArray);
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }




        }

        public static Cart MapCart(Product model)
        {
            Cart cart = new Cart();
            cart.ProductName = model.ProductName;
            cart.Category = model.Category;
            cart.Description = model.Description;
            cart.Price = model.Price;
            cart.Photos = model.Photos;
            return cart;
        }

        public static IEnumerable<Order> MapCartToTher(List<Cart> carts)
        {
            var orders = new List<Order>();
          var order = new Order();

          
            foreach (var cart in carts)
            {
                order.Quantity = cart.Quantity;
                order.Category = cart.Category;
                order.DatePurchaced = DateTime.Now;
                order.User_Id = cart.User_Id;
                order.ProductPrice = cart.Price;
                order.ProductsName = cart.ProductName;

            }

            return orders;


        }

        public static decimal AddToprice(decimal price)
        {
            var divide = (price + 100) / 5;
            return price + divide;
        }

        public static IEnumerable<Product> GetRandomCart(IEnumerable<Product> products)
        {
            var List = new List<Product>();
            var length = products.ToList();
            int count = 0;
            Random number = new Random();
            while (count < 8)
            {
                int index = number.Next(1, length.Count);
                List.Add(length[index]);
                count++;

            }

            return List;
        }

        public static decimal TotalPrice(IEnumerable<Cart> Carts)
        {
            decimal total = 0m;
            foreach (var VARIABLE in Carts)
            {
                total += VARIABLE.Price;
            }

            return total;
        }

        public static void ManageCarts(string productname)
        {
          ListingCarts.RemoveAll(product=> product.ProductName == productname);                                                                                                                                                              
          
        }

        public static void UndoCarts(string productname)
        {
          var value =  ListingCarts.FirstOrDefault(r => r.ProductName == productname)
                ;
          ListingCarts.Remove(value);
        }
    }
}

