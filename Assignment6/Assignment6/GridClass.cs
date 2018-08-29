using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    //I used a struct (it could be a class to) because I have to 
    //add an object to the datagrid with only the datagrids datas
    public struct GridClass
    {
        //handles the data that is in the datagrid
        public string Item { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Tax { get; set; }
        public string TotalTax { get; set; }
        public string Total { get; set; }
    }
}
