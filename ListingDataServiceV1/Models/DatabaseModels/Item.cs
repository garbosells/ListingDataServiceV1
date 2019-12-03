using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListingDataServiceV1.Models.DatabaseModels
{
    /// <summary>
    ///  Represents an "Item" as it is represented in the app.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The ID of the item. This is the primary key identifying the item in the database.
        /// <p>
        /// NOTE: This will be NULL when creating a new item in the app. It is not set until the item is saved.
        /// </p>
        /// <setby>The database (should be set to autoincrement)</setby>
        /// <setwhen>A new item is saved to the database</setwhen>
        /// <modifywhen>Never.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        [Key]
        public long ItemId { get; set; }
        /// <summary>
        /// The ID of the category that the item belongs to.
        ///
        /// <setby>The Android app on item creation (the Category is set by the user, the ID is saved).</setby>
        /// <setwhen>Creating an item in the Android app.</setwhen>
        /// <modifywhen>Never. Once the category is set, it should not be modified.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        public Listing Listing { get; set; }
        public long ListingId { get; set; }
        /// <summary>
        /// The date/time when the item was originally created.
        ///
        /// <setby>The frontend Android app when saving a new item, using <code>new Date()</code></setby>
        /// <setwhen>Creating a new item in the frontend Android application.</setwhen>
        /// <modifywhen>Never. This should not be modified once set.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        public DateTime createdDateTime { get; set; }
        /// <summary>
        /// The date/time when the item was last modified.
        ///
        /// <setby>The frontend Android app when saving a new item, using <code>new Date()</code></setby>
        /// <setwhen>Creating a new item in the frontend Android application.</setwhen>
        /// <modifywhen>Saving an existing item in the frontend Android application.</modifywhen>
        /// <modifiedby>The Android application.</modifiedby>
        /// </summary>
        public DateTime updatedDateTime { get; set; }
        /// <summary>
        /// The ID of the user who created the item originally.
        /// <p>
        /// NOTE: this is not the <code>userLoginId</code> (which is a<code> GUID</code> or<code>string</code>). It is the<code> userId</code>, which is a<code>long</code>.
        /// </p>
        /// <setby>The frontend Android app when saving a new item, using <code>new Date()</code></setby>
        /// <setwhen>Creating a new item in the frontend Android application.</setwhen>
        /// <modifywhen>Never. This should not be modified once set.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        public long createdByUserId { get; set; }
        /// <summary>
        /// Represents the material attribute and its recommended values.That is, what is the item made of?
        /// OPTIONAL     
        /// </summary>
        public long materialId { get; set; }
        /// <summary>
        /// The ID of the user who last modified the item.
        /// <p>
        /// NOTE: this is not the <code>userLoginId</code> (which is a<code> GUID</code> or<code>string</code>). It is the<code> userId</code>, which is a<code>long</code>.
        /// </p>
        /// <setby>The frontend Android app when saving a new item, using <code>new Date()</code></setby>
        /// <setwhen>Creating a new item in the frontend Android application.</setwhen>
        /// <modifywhen>Saving an existing item in the frontend Android application.</modifywhen>
        /// <modifiedby>The Android application.</modifiedby>
        /// </summary>
        public long updatedByUserId { get; set; }
        public long CategoryId { get; set; }
        /// <summary>
        /// The ID of the subcategory that the item belongs to.
        ///
        /// <setby>The Android app on item creation (the Subcategory is set by the user, the ID is saved).</setby>
        /// <setwhen>Creating an item in the Android app.</setwhen>
        /// <modifywhen>Never. Once the subcategory is set, it should not be modified.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        public long SubcategoryId { get; set; }
        /// <summary>
        /// This field will become the title of the listing once it is posted to Ebay/Etsy.
        ///
        /// <setby>The user in the frontend Android app.</setby>
        /// <setwhen>Creating an item in the Android app.</setwhen>
        /// <modifywhen>Editing an item in the Android app.</modifywhen>
        /// <modifiedby>The user.</modifiedby>
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// This field will become the text body of the listing once it is posted to Ebay/Etsy.
        ///
        /// <setby>The user in the frontend Android app.</setby>
        /// <setwhen>Creating an item in the Android app.</setwhen>
        /// <modifywhen>Editing an item in the Android app.</modifywhen>
        /// <modifiedby>The user.</modifiedby>
        /// </summary>
        public string LongDescription { get; set; }
        /// <summary>
        /// The size of the item. See ItemSize for details.
        ///
        /// REQUIRED FIELD if <code>category.hasSizing == TRUE</code>
        ///
        /// <setby>The Android app when the user selects the size type and size value.</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>The size type and size value are modified on an existing item.</modifywhen>
        /// <modifiedby>The user.</modifiedby>
        /// </summary>
        /// <summary>
        /// The ID of the size type selected by the user.
        /// 
        /// <setby>The Android app when the user selects the size type.</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>The size type is modified on an existing item.</modifywhen>
        /// <modifiedby>The user.</modifiedby>
        /// </summary>
        public long sizeTypeId { get; set; }
        /// <summary>
        /// The ID of the size value selected by the user. This is NOT the size itself - it is the primary key of the size value in the database.
        /// 
        /// <setby>The Android app when the user selects the size.</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>The size is modified on an existing item.</modifywhen>
        /// <modifiedby>The user.</modifiedby>
        /// </summary>
        public long sizeValueId { get; set; }
        /// <summary>
        /// Represents the primary color attribute and its recommended values.
        /// OPTIONAL
        /// </summary>
        public long primaryColorId { get; set; }
        /// <summary>
        /// Represents the secondary color attribute and its recommended values.
        /// OPTIONAL
        /// </summary>
        public long secondaryColorId { get; set; }
        /// <summary>
        /// Represents the era attribute and its recommended values. The era is whenever the item was manufactured. It is used by the Ebay/Etsy services to determine whether the item can be categorized as "vintage."
        /// REQUIRED     
        /// </summary>
        public long eraId { get; set; }
        //An Item has has 1 or 0 measurement
        public List<ItemMeasurement> measurements { get; set; }
        //An Item has n attributes
        public List<ItemAttribute> attributes { get; set; }
        
    }
}
