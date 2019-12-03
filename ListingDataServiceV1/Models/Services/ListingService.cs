using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingDataServiceV1.Models.DatabaseModels;
using ListingDataServiceV1.Models.WebModels;

namespace ListingDataServiceV1.Models.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        public async Task<List<DatabaseModels.Listing>> GetAllListingsAsync()
        {
            return await _listingRepository.GetAllListingsAsync();
        }

        public async Task<DatabaseModels.Listing> GetListingAsync(long id)
        {
            return await _listingRepository.GetListingAsync(id);
        }

        public async Task<string> SaveNewListingAsync(DatabaseModels.Listing newListing)
        {
            return await _listingRepository.SaveNewListingAsync(newListing);
        }

        public async Task<string> UpdateListingAsync(DatabaseModels.Listing listing)
        {
            return await _listingRepository.UpdateListingAsync(listing);
        }

        public async Task<string> DeleteListingAsync(long id)
        {
            return await _listingRepository.DeleteListingAsync(id);
        }
    }
}
