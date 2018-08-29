using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Manager
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Manager()
        {

        }
        /// <summary>
        /// is the amount to pay after the discount
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Count the discount of the price
        /// </summary>
        /// <param name="totalPrice">the total price before the discount</param>
        /// <param name="discount">the given discount by the user</param>
        public void CountTotalAmount(string totalPrice, string discount)
        {
            //total price
            int total;
            //the discount
            int discountToInt;
            //check if the number is int and parse 
            try
            {
                if (int.TryParse(totalPrice, out total) && int.TryParse(discount, out discountToInt))
                {
                    int tax;
                    tax = total / 100;
                    tax = tax * discountToInt;
                    Total = total - tax;
                }
                
            }
            //catch the error if something goes wrong ( for exempel the if will not be true)
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }       
    }
}
