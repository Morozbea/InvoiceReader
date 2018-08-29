using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    //gets all data all data that is not in the datagrid
    class InvoiceInformation
    {
        public string InvoceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public string CompanyNameOfOrder { get; set; }
        public string OwnerNameOfOrder { get; set; }
        public string AdressOfOrder { get; set; }
        public string PostNumberOfOrder { get; set; }
        public string CityOfOrder { get; set; }
        public string CountryOfOrder { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Tax { get; set; }
        public string TotalTax { get; set; }
        public string Total { get; set; }
        public string CompanyNameOfSeller { get; set; }
        public string SellersAddress { get; set; }
        public string SellersPostNumber { get; set; }
        public string SellersCity { get; set; }
        public string SellersCountry { get; set; }
        public string SellersTelNumber { get; set; }
        public string SellersHomePage { get; set; }
                
    }
}
