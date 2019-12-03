using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListingDataServiceV1.Data;
using ListingDataServiceV1.Models.DatabaseModels;
using ListingDataServiceV1.Models.WebModels;
using Microsoft.EntityFrameworkCore;


namespace ListingDataServiceV1.Models.Services
{
    public class ListingRepository : IListingRepository
    {
        private readonly ListingDataServiceV1Context _context;

        public ListingRepository(ListingDataServiceV1Context context)
        {
            _context = context;
        }
        public async Task<List<DatabaseModels.Listing>> GetAllListingsAsync()
        {
            var listings = await _context.Listings.ToListAsync();
            foreach (DatabaseModels.Listing l in listings) {
                l.Item = await _context.Items.FindAsync(l.ListingId);
                var itemAttributes = from ia in _context.ItemAttributes
                                     where ia.ItemId == l.ListingId
                                     select ia;
                var itemMeasurements = from im in _context.ItemMeasurements
                                     where im.ItemId == l.ListingId
                                     select im;
                l.Item.attributes = itemAttributes.ToList();
                l.Item.measurements = itemMeasurements.ToList();
            }
            return listings;
        }

        public async Task<DatabaseModels.Listing> GetListingAsync(long id)
        {
            var listing = await _context.Listings.FindAsync(id);
            var item = await _context.Items.FindAsync(id);
            var itemAttributes = from ia in _context.ItemAttributes
                                 where ia.ItemId == id
                                 select ia;
            var itemMeasurements = from im in _context.ItemMeasurements
                                   where im.ItemId == id
                                   select im;
            listing.Item = item;
            listing.Item.attributes = itemAttributes.ToList();
            listing.Item.measurements = itemMeasurements.ToList();
            return listing;
        }

        public async Task<string> SaveNewListingAsync(DatabaseModels.Listing newListing)
        {
            _context.Listings.Add(newListing);
            _context.Items.Add(newListing.Item);
            foreach(DatabaseModels.ItemAttribute ia in newListing.Item.attributes)
            {
                _context.ItemAttributes.Add(ia);
            }
            foreach (DatabaseModels.ItemMeasurement im in newListing.Item.measurements)
            {
                _context.ItemMeasurements.Add(im);
            }
            await _context.SaveChangesAsync();
            return "success";
        }

        public async Task<string> UpdateListingAsync(DatabaseModels.Listing listing)
        {
            _context.Entry(listing).State = EntityState.Modified;
            _context.Entry(listing.Item).State = EntityState.Modified;
            foreach (DatabaseModels.ItemAttribute ia in listing.Item.attributes)
            {
                _context.Entry(ia).State = EntityState.Modified;
            }
            foreach (DatabaseModels.ItemMeasurement im in listing.Item.measurements)
            {
                _context.Entry(im).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return "error";
            }
            return "success";
        }

        public async Task<string> DeleteListingAsync(long id)
        {
            var dlist = await _context.Listings.FindAsync(id);
            var ditem = await _context.Items.FindAsync(id);
            var attrs = from ia in _context.ItemAttributes
                                 where ia.ItemId == id
                                 select ia;
            var meas = from im in _context.ItemMeasurements
                       where im.ItemId == id
                       select im;
            _context.Entry(dlist).State = EntityState.Deleted;
            _context.Entry(ditem).State = EntityState.Deleted;
            foreach(DatabaseModels.ItemAttribute ia in attrs)
            {
                _context.Entry(ia).State = EntityState.Deleted;
            }
            foreach (DatabaseModels.ItemMeasurement im in meas)
            {
                _context.Entry(im).State = EntityState.Deleted;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return "error";
            }
            return "sucess";
        }
    }
}
