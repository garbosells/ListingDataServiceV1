using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDataServiceV1.Models.WebModels
{
    public class ItemSize
    {
        /**
    * The ID of the size type selected by the user.
    *
    * @setby The Android app when the user selects the size type.
    * @setwhen Saving a new item.
    * @modifywhen The size type is modified on an existing item.
    * @modifiedby The user.
    */
        public long sizeTypeId { get; set; }
        /**
         * The ID of the size value selected by the user. This is NOT the size itself - it is the primary key of the size value in the database.
         *
         * @setby The Android app when the user selects the size.
         * @setwhen Saving a new item.
         * @modifywhen The size is modified on an existing item.
         * @modifiedby The user.
         */
        public long sizeValueId { get; set; }
    }
}
