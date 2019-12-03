using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListingDataServiceV1.Models.WebModels
{
    /// <summary>
    ///  Represents an "Item" as it is represented in the app.
    /// </summary>
    public class Item
    {
        /**
     * The date/time when the item was originally created.
     *
     * @setby The frontend Android app when saving a new item, using <code>new Date()</code>
     * @setwhen Creating a new item in the frontend Android application.
     * @modifywhen Never. This should not be modified once set.
     * @modifiedby No one.
     */
        public DateTime createdDateTime { get; set; }
        /**
         * The date/time when the item was last modified.
         *
         * @setby The frontend Android app when saving a new item, using <code>new Date()</code>
         * @setwhen Creating a new item on the frontend Android application.
         * @modifywhen Saving an existing item in the frontend Android application.
         * @modifiedby The Android application.
         */
        public DateTime updatedDateTime { get; set; }
        /**
         * The ID of the user who created the item originally.
         *<p>
         * NOTE: this is not the <code>userLoginId</code> (which is a <code>GUID</code> or <code>string</code>). It is the <code>userId</code>, which is a <code>long</code>.
         *</p>
         * @setby The frontend Android app when saving a new item, using <code>userId</code> of the user who is logged in
         * @setwhen Creating a new item on the frontend Android application.
         * @modifywhen Never. This should not be modified once set.
         * @modifiedby No one.
         */
        public long createdByUserId { get; set; }
        /**
         * The ID of the user who last modified the item.
         *<p>
         * NOTE: this is not the <code>userLoginId</code> (which is a <code>GUID</code> or <code>string</code>). It is the <code>userId</code>, which is a <code>long</code>.
         *</p>
         * @setby The frontend Android app when saving a new item, using <code>userId</code> of the user who is logged in
         * @setwhen Creating a new item on the frontend Android application.
         * @modifywhen Saving an existing item in the frontend Android application.
         * @modifiedby The Android application.
         */
        public long updatedByUserId { get; set; }
        /**
         * The ID of the item. This is the primary key identifying the item in the database.
         * <p>
         *     NOTE: This will be NULL when creating a new item in the app. It is not set until the item is saved.
         * </p>
         *
         * @setby The database (should be set to autoincrement)
         * @setwhen A new item is saved to the database
         * @modifywhen Never.
         * @modifiedby No one.
         */
        public long id { get; set; } //nullable
                        /**
                         * This field will become the title of the listing once it is posted to Ebay/Etsy
                         * @setby The user in the frontend Android app
                         * @setwhen Creating an item in the Android app
                         * @modifywhen Editing an item in the Android app.
                         * @modifiedby The user.
                         */
        public string shortDescription { get; set; }
        /**
         * This field will become the text body of the listing once it is posted to Ebay/Etsy
         * @setby The user in the frontend Android app
         * @setwhen Creating an item in the Android app
         * @modifywhen Editing an item in the Android app.
         * @modifiedby The user.
         */
        public string longDescription { get; set; }
        /**
         * The ID of the category that the item belongs to.
         * @setby The Android app on item creation (the Category is set by the user, the ID is saved)
         * @setwhen Creating an item in the Android app
         * @modifywhen Never. Once the category is set, it should not be modified.
         * @modifiedby No one.
         */
        public long categoryId { get; set; }
        /**
         * The ID of the subcategory that the item belongs to.
         * @setby The Android app on item creation (the Subcategory is set by the user, the ID is saved)
         * @setwhen Creating an item in the Android app
         * @modifywhen Never. Once the subcategory is set, it should not be modified.
         * @modifiedby No one.
         */
        public long subcategoryId { get; set; }
        /**
         * NOT IN USE.
         * Extended feature that may be implemented after basic functionality exists.
         */
        //public List<string> tags { get; set; }
        /**
         * The measurements of the item. Only applies if <code>category.hasMeasurements == TRUE</code> May be empty. See ItemMeasurement for details.
         *
         * OPTIONAL FIELDS
         *
         * @setby The Android app when the user enters measurements.
         * @setwhen Saving a new item.
         * @modifywhen The measurements are modified on an existing item.
         * @modifiedby The user.
         */
        public List<ItemMeasurement> measurements { get; set; }
        /**
         * The size of the item. See ItemSize for details.
         *
         * REQUIRED FIELD if <code>category.hasSizing == TRUE</code>
         *
         * @setby The Android app when the user selects the size type and size value.
         * @setwhen Saving a new item.
         * @modifywhen The size type and size value are modified on an existing item.
         * @modifiedby The user.
         */
        public ItemSize size { get; set; }
        /**
         * A set of attributes that generally applies to all items, regardless of subcategory.
         * @setby The user when completing the item creation wizard.
         * @setwhen Creating an item in the Android app.
         * @modifywhen Saving an existing item.
         * @modifiedby The user.
         */
        public GeneralItemAttributes generalItemAttributes { get; set; }
        /**
         * A set of attributes that apply to the particular subcategory selected. A given subcategory may have 0 or more of these.
         * @setby The user when completing the item creation wizard.
         * @setwhen Creating an item in the Android .
         * @modifywhen Saving an existing item.
         * @modifiedby The user.
         */
        public List<ItemAttribute> attributes { get; set; }

    }
}
