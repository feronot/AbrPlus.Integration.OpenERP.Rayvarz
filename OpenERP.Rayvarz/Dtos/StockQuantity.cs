using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Dtos
{
    public class StockQuantity
    {
        public virtual string StockCode { get; set; }
        public virtual string StockName { get; set; }
        public virtual string ItemQuantity { get; set; }
        public virtual string ReservedQuantity { get; set; }
    }
}
