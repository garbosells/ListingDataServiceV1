﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ListingDataServiceV1.Models.WebModels
{
    public class ItemAttribute
    {
        /**
    * ID of the SubcategoryAttribute that this value applies to.
    *<p>
    *     NULLABLE because general attributes do not have IDs
    *</p>
    *
    * @setby The app when the user supplies a value for the attribute.
    * @setwhen Creating an item in the Android app.
    * @modifywhen Editing an item in the Android app.
    * @modifiedby The app when the user supplies a new value for the attribute.
    */
        public long subcategoryAttributeId { get; set; } //nullable
                                            /**
                                             * ID of the ItemAttribute. This is the primary key of the attribute in the database. It will have
                                             * <p>
                                             *     NOTE: This will be NULL when creating a new item in the app. It is not set until the item is saved.
                                             * </p>
                                             * @setby The database (should be autoincremented).
                                             * @setwhen Saving a new item.
                                             * @modifywhen Never.
                                             * @modifiedby No one.
                                             */
        public long itemAttributeId { get; set; } //nullable
                                     /**
                                      * The CUSTOM value of the attribute. This will only have a value if the user entered a custom value (rather than selecting from a list)
                                      * <p>
                                      *     NOTE: This will likely not be used as no attributes currently have custom values enabled.
                                      * </p>
                                      * @setby The user when setting a custom value for an attribute.
                                      * @setwhen Saving a new item.
                                      * @modifywhen Saving an existing item.
                                      * @modifiedby The user when modifying a custom value or changing an attribute to have a custom value.
                                      */
        public string itemAttributeValue { get; set; } //could be a string, bool, or number, but we'll store it as a string for simplicity
                                          /**
                                           * The ID of the value that the user selected for the attribute.
                                           * @setby The user when setting a value for an attribute.
                                           * @setwhen Saving a new item.
                                           * @modifywhen Saving an existing item.
                                           * @modifiedby The user when modifying the value of an attribute.
                                           */
        public long attributeRecommendationId { get; set; } //nullable, used if the user chose a "recommended" value for the attribute
    }
}
