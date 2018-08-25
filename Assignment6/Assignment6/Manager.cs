using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Manager
    {
        string m_totalPrice;
        string m_discount;
        int mTotalTotalPrice;
        public Manager()
        {

        }

        public int Total
        {
            get { return mTotalTotalPrice; }
            set { mTotalTotalPrice = value; }
        }

        public void CountTotalTax(string totalPrice, string discount)
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
