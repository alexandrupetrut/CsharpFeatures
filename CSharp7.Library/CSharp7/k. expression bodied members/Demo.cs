using System;

namespace CSharp7.Library.CSharp7.k._expression_bodied_members
{
    public class CashMoney
    {
        private decimal value;
        public decimal Value
        {
            get
            {  return value;  }
            set
            {  SetValue(value);  }
        }
        public CashMoney(decimal value)
        {
            SetValue(value);
        }
        private void SetValue (decimal newValue)
        {
            value = newValue >= 0 ? newValue : throw new Exception();
        }
    }

    public class CreditMoney
    {
        private decimal value;
        public decimal Value
        {
            get => value;  
            set => SetValue(value);
        }
        public CreditMoney(decimal value) => SetValue(value);
        private void SetValue(decimal newValue) => value = newValue >= 0 ? newValue : throw new Exception();
    }

    public class Program
    {
        public static void Main()
        {
            var money = new CashMoney(10);
            Console.WriteLine(money);
            try
            {
                money.Value = -100;
            }
            catch (Exception)
            {
                Console.WriteLine("Can't set the value to a negative number");
            }

            money.Value = 100;
            Console.WriteLine(money);
        }
    }
}
