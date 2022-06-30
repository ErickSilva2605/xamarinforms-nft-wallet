using System;
using System.Collections.Generic;

namespace NFTWallet.Models
{
    public class ChartModel
    {
        public DateTime DateMax { get; set; }
        public DateTime DateMin { get; set; }
        public double Interval { get; set; }
        public double ValueMax { get; set; }
        public double ValueMin { get; set; }
        public ICollection<ChartValueModel> Values { get; set; }
    }
}
