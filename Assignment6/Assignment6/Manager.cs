using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Manager
    {
        public Manager()
        {

        }

        public int Total { get; set; }

        public void CountTotalAmount(string totalPrice, string discount)
        {
            int total;
            int discountToInt;
            try
            {
                if (int.TryParse(totalPrice, out total) && int.TryParse(discount, out discountToInt))
                {
                    int tax;
                    tax = total / 100;
                    tax = tax * discountToInt;
                    Total = tax;
                }

            }
            catch (Exception ex)
            {

            }
        }

       
    }
}
