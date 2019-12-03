using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDataServiceV1.Models.DatabaseModels
{
    public class Listing
    {
        /// <summary>
        ///  Each Listing has an item.
        /// </summary>
        /// 
        [Key]
        public long ListingId { get; set; }
        public Item Item { get; set; }

        public long ItemId { get; set; }
    }
}
