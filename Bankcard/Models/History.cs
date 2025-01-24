using System;
using System.Collections.Generic;

namespace Bankcard.Models
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
    }
}
