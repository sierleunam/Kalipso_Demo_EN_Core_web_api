using System;
using System.Collections.Generic;

namespace Kalipso_Demo_EN_Core.Models
{
    public partial class Products
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Prico { get; set; }
        public decimal? Stock { get; set; }
        public string Family { get; set; }
        public int Flag { get; set; }
        public DateTime? Date { get; set; }
    }
}
