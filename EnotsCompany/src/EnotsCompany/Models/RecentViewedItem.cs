using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnotsCompany.Models
{
    public class RecentViewedItem
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        public string Price { get; set; }
        public string ImageItem { get; set; }

        public DateTime LastVisited { get; set; }

        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
