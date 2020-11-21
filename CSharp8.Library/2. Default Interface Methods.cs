using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.Library
{
    public interface IShoppingCart
    {
        void CalculateTotal();

        // if we add this in production, it ruins things so we could just make a new interface with this method that ShoppingCart implements
        // void CalculateSubTotal();
    }

    public interface ISubShoppingCart
    {
        void CalculateSubTotal();
    }

    public class ShoppingCart : IShoppingCart, ISubShoppingCart
    {
        public void CalculateTotal()
        {
            Console.WriteLine("This is CalculateTotal in the ShoppingCart class.");
        }

        public void CalculateSubTotal()
        {
            throw new NotImplementedException();
        }
    }


    // there's a better way of doing this, instead of making 20 interfaces and just adding stuff into the code
    // we could use default implementation

    // primary design is for making changes to an interface to add more things as you go, add more features !!!
    // so we add default implementations of them and we don't affect any of the old classes
    // it allows us to extend an interface, safely  &  allows us to have a more specific implementation (esp if 95% of that default implementation is used everywhere), like inheritance ~
    public interface IShopCart
    {
        private static string defaultName = "default";
        public static void SetDefaultName(string name)
        {
            defaultName = name;
        }
        void CalculateTotal();
        void CalculateSubTotal()
        {
            Console.WriteLine($"This is a {defaultName} IShopCart implementation for CalculateSubTotal.");
        }
    }

    public class ShopCart : IShopCart
    {
        // IShopCart won't yell that it lacks CalculateSubTotal() implementation anymore
        public void CalculateTotal()
        {
            Console.WriteLine("This is CalculateTotal in the ShoppingCart class.");
        }
    }

    public class BetterShopCart : IShopCart
    {
        //ctor - mostly an edge case, but allows for better variation for the classes that implement the interface
        public BetterShopCart()
        {
            IShopCart.SetDefaultName("DefaultBetterShoppingCart");
        }

        public void CalculateTotal()
        {
            Console.WriteLine("This is CalculateTotal in the BetterShoppingCart class.");
        }

        // i can override the default with my own or not 
        public void CalculateSubTotal()
        {
            Console.WriteLine("This is BetterShopCart implementation of CalculateSubTotal.");
        }
    }
}
