using System;
using System.Collections.Generic;

namespace Kalipso_Demo_EN_Core.Models
{
    public partial class Countries
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal? PopulationDensity { get; set; }
        public int? RegionId { get; set; }
        public string Image { get; set; }
    }
}
