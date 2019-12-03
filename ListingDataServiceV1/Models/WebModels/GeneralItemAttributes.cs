using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDataServiceV1.Models.WebModels
{
    
    public class GeneralItemAttributes
    {
        /**
      * The "era" of the item - when the item was manufactured. This is used by the Ebay/Etsy services to determine whether an item should be categorized as "vintage"
      *
      * REQUIRED FIELD
      *
      * @setby The Android app when the user selects the era
      * @setwhen Saving a new item
      * @modifywhen The era is modified on an existing item
      * @modifiedby The user
      */
        public ItemAttribute era { get; set; }
        /**
         * The "primary color" of the item - the color that the item is mostly composed of.
         *
         * OPTIONAL FIELD
         *
         * @setby The Android app when the user selects the primary color
         * @setwhen Saving a new item
         * @modifywhen The primary color is modified on an existing item
         * @modifiedby The user
         */
        public ItemAttribute primaryColor { get; set; }
        /**
         * The "secondary color" of the item - applies to multicolored items. Should only be set if there is a primary color set.
         *
         * OPTIONAL FIELD
         *
         * @setby The Android app when the user selects the secondary color
         * @setwhen Saving a new item
         * @modifywhen The secondary color is modified on an existing item
         * @modifiedby The user
         */
        public ItemAttribute secondaryColor { get; set; }
        /**
         * The "material" of the item - what the item is made of.
         *
         * OPTIONAL FIELD
         *
         * @setby The Android app when the user selects the material
         * @setwhen Saving a new item
         * @modifywhen The material is modified on an existing item
         * @modifiedby The user
         */
        public ItemAttribute material { get; set; }
    }
}
