using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingDataServiceV1.Models.DatabaseModels;
using ListingDataServiceV1.Models.WebModels;

namespace ListingDataServiceV1.Controllers
{
    public class Map
    {
        private static Models.DatabaseModels.Listing _dbListing;
        private static Models.WebModels.Listing _webListing;
        public static Models.DatabaseModels.Listing WebToDB(Models.WebModels.Listing l)
        {
            _dbListing = new Models.DatabaseModels.Listing();
            _dbListing.ListingId = l.ListingId;
            _dbListing.ItemId = l.ListingId;
            _dbListing.Item = new Models.DatabaseModels.Item();
            _dbListing.Item.attributes = MapWebAttributes(l.Item.attributes, l.Item.generalItemAttributes);
            _dbListing.Item.measurements = MapWebMeasurements(l.Item.measurements);
            _dbListing.Item.ItemId = l.ListingId;
            _dbListing.Item.Listing = _dbListing;
            _dbListing.Item.ListingId = l.Item.id;
            _dbListing.Item.createdDateTime = l.Item.createdDateTime;
            _dbListing.Item.updatedDateTime = l.Item.updatedDateTime;
            _dbListing.Item.createdByUserId = l.Item.createdByUserId;
            _dbListing.Item.updatedByUserId = l.Item.updatedByUserId;
            _dbListing.Item.materialId = l.Item.generalItemAttributes.material.itemAttributeId;
            _dbListing.Item.SubcategoryId = l.Item.subcategoryId;
            _dbListing.Item.CategoryId = l.Item.categoryId;
            _dbListing.Item.ShortDescription = l.Item.shortDescription;
            _dbListing.Item.LongDescription = l.Item.longDescription;
            _dbListing.Item.sizeTypeId = l.Item.size.sizeTypeId;
            _dbListing.Item.sizeValueId = l.Item.size.sizeValueId;
            _dbListing.Item.secondaryColorId = l.Item.generalItemAttributes.secondaryColor.itemAttributeId;
            _dbListing.Item.primaryColorId = l.Item.generalItemAttributes.primaryColor.itemAttributeId;
            _dbListing.Item.eraId = l.Item.generalItemAttributes.era.itemAttributeId;
            return _dbListing;
        }

        public static Models.WebModels.Listing DBToWeb(Models.DatabaseModels.Listing l)
        {
            _webListing = new Models.WebModels.Listing();
            _webListing.ListingId = l.ListingId;
            _webListing.Item = new Models.WebModels.Item();
            _webListing.Item.id = l.ListingId;
            if (l.Item != null)
            {
                if (l.Item.attributes != null)
                {
                    _webListing.Item.generalItemAttributes = WebGeneralAttrs(l.Item.attributes);
                    _webListing.Item.attributes = WebAttrs(l.Item.attributes);
                }
                _webListing.Item.categoryId = l.Item.CategoryId;
                _webListing.Item.subcategoryId = l.Item.SubcategoryId;
                _webListing.Item.updatedByUserId = l.Item.updatedByUserId;
                _webListing.Item.createdByUserId = l.Item.createdByUserId;
                _webListing.Item.createdDateTime = l.Item.createdDateTime;
                _webListing.Item.updatedDateTime = l.Item.updatedDateTime;
                _webListing.Item.shortDescription = l.Item.ShortDescription;
                _webListing.Item.longDescription = l.Item.LongDescription;
                _webListing.Item.measurements = MapDBMeasurements(l.Item.measurements);
                _webListing.Item.size = new ItemSize();
                _webListing.Item.size.sizeTypeId = l.Item.sizeTypeId;
                _webListing.Item.size.sizeValueId = l.Item.sizeValueId;
            }
            return _webListing;
        }

        public static List<Models.WebModels.Listing> DBsToWebs(List<Models.DatabaseModels.Listing> listings)
        {
            List<Models.WebModels.Listing> webListings = new List<Models.WebModels.Listing>(); 
            foreach (Models.DatabaseModels.Listing l in listings)
            {
                webListings.Add(DBToWeb(l));
            }
            return webListings;
        }

            private static List<Models.WebModels.ItemAttribute> WebAttrs(List<Models.DatabaseModels.ItemAttribute> dbAttrs)
        {
            List<Models.WebModels.ItemAttribute> webAttrs = new List<Models.WebModels.ItemAttribute>();
            Models.WebModels.ItemAttribute webAttr;
            foreach (Models.DatabaseModels.ItemAttribute it in dbAttrs)
            {
                if (!it.flag)
                {
                    webAttr = new Models.WebModels.ItemAttribute();
                    webAttr.itemAttributeId = it.itemAttributeId;
                    webAttr.itemAttributeValue = it.itemAttributeValue;
                    webAttr.subcategoryAttributeId = it.subcategoryAttributeId;
                    webAttr.attributeRecommendationId = it.attributeRecommendationId;
                    webAttrs.Add(webAttr);
                }
            }
            return webAttrs;
        }

        private static GeneralItemAttributes WebGeneralAttrs(List<Models.DatabaseModels.ItemAttribute> dbAttrs)
        {
            List<Models.WebModels.ItemAttribute> genAttrs = new List<Models.WebModels.ItemAttribute>();
            Models.WebModels.ItemAttribute webAttr;
            GeneralItemAttributes gItemAttrs = new GeneralItemAttributes();
            foreach (Models.DatabaseModels.ItemAttribute it in dbAttrs)
            {
                if (it.flag)
                {
                    webAttr = new Models.WebModels.ItemAttribute();
                    webAttr.attributeRecommendationId = it.attributeRecommendationId;
                    webAttr.itemAttributeId = it.itemAttributeId;
                    webAttr.itemAttributeValue = it.itemAttributeValue;
                    webAttr.subcategoryAttributeId = it.subcategoryAttributeId;
                    genAttrs.Add(webAttr);
                }
            }
            gItemAttrs.era = genAttrs[0];
            gItemAttrs.primaryColor = genAttrs[1];
            gItemAttrs.secondaryColor = genAttrs[2];
            gItemAttrs.material = genAttrs[3];
            return gItemAttrs;
        }

        private static List<Models.DatabaseModels.ItemAttribute> MapWebAttributes(List<Models.WebModels.ItemAttribute> attrs, Models.WebModels.GeneralItemAttributes gAttrs)
        {
            Models.DatabaseModels.ItemAttribute dbattr;
            List<Models.DatabaseModels.ItemAttribute> dbAttrs = new List<Models.DatabaseModels.ItemAttribute>();
            List<Models.WebModels.ItemAttribute> webgAttrs = new List<Models.WebModels.ItemAttribute>();
            webgAttrs.Add(gAttrs.era);
            webgAttrs.Add(gAttrs.primaryColor);
            webgAttrs.Add(gAttrs.secondaryColor);
            webgAttrs.Add(gAttrs.material);
            foreach (Models.WebModels.ItemAttribute it in webgAttrs)
            {
                dbattr = new Models.DatabaseModels.ItemAttribute();
                dbattr.itemAttributeId = it.itemAttributeId;
                dbattr.itemAttributeValue = it.itemAttributeValue;
                dbattr.subcategoryAttributeId = it.subcategoryAttributeId;
                dbattr.attributeRecommendationId = it.attributeRecommendationId;
                dbattr.flag = true;
                dbattr.Item = _dbListing.Item;
                dbattr.ItemId = _dbListing.ItemId;
                dbAttrs.Add(dbattr);
            }
            foreach (Models.WebModels.ItemAttribute it in attrs)
            {
                dbattr = new Models.DatabaseModels.ItemAttribute();
                dbattr.itemAttributeId = it.itemAttributeId;
                dbattr.itemAttributeValue = it.itemAttributeValue;
                dbattr.subcategoryAttributeId = it.subcategoryAttributeId;
                dbattr.attributeRecommendationId = it.attributeRecommendationId;
                dbattr.flag = false;
                dbattr.Item = _dbListing.Item;
                dbattr.ItemId = _dbListing.ItemId;
                dbAttrs.Add(dbattr);
            }     
            return dbAttrs;
        }

        private static List<Models.DatabaseModels.ItemMeasurement> MapWebMeasurements(List<Models.WebModels.ItemMeasurement> wMeas)
        {
            List<Models.DatabaseModels.ItemMeasurement> dbMeas = new List<Models.DatabaseModels.ItemMeasurement>();
            Models.DatabaseModels.ItemMeasurement dbMea = new Models.DatabaseModels.ItemMeasurement();
            foreach (Models.WebModels.ItemMeasurement im in wMeas)
            {
                dbMea.categoryMeasurementId = im.categoryMeasurementId;
                dbMea.itemMeasurementId = im.itemMeasurementId;
                dbMea.itemMeasurementValue = im.itemMeasurementValue;
                dbMea.Item = _dbListing.Item;
                dbMea.ItemId = _dbListing.Item.ItemId;
                dbMeas.Add(dbMea);
            }
            return dbMeas;
        }

        private static List<Models.WebModels.ItemMeasurement> MapDBMeasurements(List<Models.DatabaseModels.ItemMeasurement> dbMeas)
        {
            List<Models.WebModels.ItemMeasurement> webMeas = new List<Models.WebModels.ItemMeasurement>();
            Models.WebModels.ItemMeasurement webMea = new Models.WebModels.ItemMeasurement();
            foreach (Models.DatabaseModels.ItemMeasurement im in dbMeas)
            {
                webMea.categoryMeasurementId = im.categoryMeasurementId;
                webMea.itemMeasurementId = im.itemMeasurementId;
                webMea.itemMeasurementValue = im.itemMeasurementValue;
                webMeas.Add(webMea);
            }
            return webMeas;
        }
    }
}
