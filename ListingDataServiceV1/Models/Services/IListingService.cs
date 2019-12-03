using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingDataServiceV1.Models.WebModels;

namespace ListingDataServiceV1.Models.Services
{
    public interface IListingService
    {
        Task<List<DatabaseModels.Listing>> GetAllListingsAsync();
        Task<DatabaseModels.Listing> GetListingAsync(long id);
        Task<string> SaveNewListingAsync(DatabaseModels.Listing newListing);
        Task<string> UpdateListingAsync(DatabaseModels.Listing listing);
        Task<string> DeleteListingAsync(long id);
    }
}
