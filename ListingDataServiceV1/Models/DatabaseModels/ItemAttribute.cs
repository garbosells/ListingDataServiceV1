using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ListingDataServiceV1.Models.DatabaseModels
{
    [Table("item_attribute")]
    public class ItemAttribute
    {
        /// <summary>
        /// ID of the SubcategoryAttribute that this value applies to.
        ///<p>
        ///     NULLABLE because general attributes do not have IDs
        ///</p>
        /// <setby>The app when the user supplies a value for the attribute.</setby>
        /// <setwhen>Creating an item in the Android app.</setwhen>
        /// <modifywhen>Editing an item in the Android app.</modifywhen>
        /// <modifiedby>The app when the user supplies a new value for the attribute.</modifiedby>
        /// </summary>
        public long subcategoryAttributeId { get; set; }
        /// <summary>
        /// ID of the ItemAttribute. This is the primary key of the attribute in the database. It will have
        /// <p>
        ///     NOTE: This will be NULL when creating a new item in the app.It is not set until the item is saved.
        /// </p>
        /// <setby>The database (should be autoincremented).</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>Never.</modifywhen>
        /// <modifiedby>No one.</modifiedby>
        /// </summary>
        [Key]
        public long itemAttributeId { get; set; }
        /// <summary>
        /// The CUSTOM value of the attribute. This will only have a value if the user entered a custom value (rather than selecting from a list)
        /// <p>
        ///     NOTE: This will likely not be used as no attributes currently have custom values enabled.
        /// </p>
        /// <setby>The user when setting a custom value for an attribute.</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>Saving an existing item.</modifywhen>
        /// <modifiedby>The user when modifying a custom value or changing an attribute to have a custom value.</modifiedby>
        /// </summary>
        public string itemAttributeValue { get; set; }
        /// <summary>
        /// The ID of the value that the user selected for the attribute.
        /// 
        /// <setby>The user when setting a value for an attribute.</setby>
        /// <setwhen>Saving a new item.</setwhen>
        /// <modifywhen>Saving an existing item.</modifywhen>
        /// <modifiedby>The user when modifying the value of an attribute.</modifiedby>
        public long attributeRecommendationId { get; set; }
        //if this flag is true, then this ItemAttribute is a general item attribute
        public bool flag { get; set; }
        public Item Item { get; set; }
        public long ItemId { get; set; }
    }
}
