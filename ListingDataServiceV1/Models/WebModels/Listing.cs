using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDataServiceV1.Models.WebModels
{
    public class Listing
    {
        /// <summary>
        ///  Each Listing has an item.
        /// </summary>
        /// 
        public long ListingId { get; set; }
        public Item Item { get; set; }
    }
}
