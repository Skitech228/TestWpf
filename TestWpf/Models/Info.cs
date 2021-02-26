using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace TestWpf.Models
{
    internal class PlaseInfo
    {
        public string name { get; set; }

        public string location { get; set; }
        public IEnumerable<ConfermdCount> ConfermdCounts { get; set; }
    }

    internal class ContrueInfo : PlaseInfo
    {
        public IEnumerable<ProvinseInfo> ProvinsecCounts { get; set; }
    }

    internal class ProvinseInfo : PlaseInfo{ }

    internal struct ConfermdCount
    {
        public DateTime Date { get;set; }
        public int Counts { get;set; }
    }

    internal struct DatePoint
    {
        public double YValues { get; set; }
        public double XValues { get;set; }
    }

}
