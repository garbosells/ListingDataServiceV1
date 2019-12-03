using ListingDataServiceV1.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingDataServiceV1.Models.Services
{
    public interface IListingRepository
    {
        Task<List<DatabaseModels.Listing>> GetAllListingsAsync();
        Task<DatabaseModels.Listing> GetListingAsync(long id);
        Task<string> SaveNewListingAsync(Listing newListing);
        Task<string> UpdateListingAsync(Listing listing);
        Task<string> DeleteListingAsync(long id);
    }
}
