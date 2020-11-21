using System;

namespace CSharp8.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            // interfaces are public methods, properties, events known for the interface
            // if an interface has more methods than the implementation class, only way to get them is by referencing the interface, not the concrete class
            //BetterShopCart cart1 = new BetterShopCart();
            //cart1.CalculateSubTotal();
            //cart1.CalculateTotal();


            //BetterShopCart cart2 = new BetterShopCart();
            //cart2.CalculateSubTotal();
            //cart2.CalculateTotal();

            // so you have starting source code with default implementation, similar to abstract classes BUT NOT THE SAME AS ABSTRACT CLASSES !
            // reason => the only way to use a default implementation method is to reference the interface type (IShopCart cart = new ShopCart..)
            // unless we over override them ~

            //ShopCart cart3 = new ShopCart();
            //IShopCart cart4 = new ShopCart();

            //cart3.CalculateSubTotal();
            //cart4.CalculateSubTotal();

            //cart3.CalculateTotal();
            //cart4.CalculateTotal();

            //IndicesAndRanges.Demo();

            NullCoalescingAssignment.Demo();

            Console.ReadLine();
        }
    }
}
