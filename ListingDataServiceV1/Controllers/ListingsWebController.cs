using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListingDataServiceV1.Models.WebModels;
using ListingDataServiceV1.Models.Services;
using System.Collections;

namespace ListingDataServiceV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsWebController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingsWebController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet("GetListing/id")]
        public async Task<Listing> GetAsync(long id)
        {
            
            var listing = await _listingService.GetListingAsync(id);
            return Map.DBToWeb(listing);
        }

        [HttpGet("GetAllListings")]
        public async Task<IEnumerable<Listing>> GetAllAsync()
        {
            var listings = await _listingService.GetAllListingsAsync();
            return Map.DBsToWebs(listings);
        }

        [HttpPost("SaveListing")]
        public async Task<string> SaveNewAsync([FromBody] Listing newListing)
        {
            var response = await _listingService.SaveNewListingAsync(Map.WebToDB(newListing));
            return response;
        }
        [HttpPut("UpdateListing")]
        public async Task<string> UpdateAsync([FromBody] Listing listing)
        {
            var response = await _listingService.UpdateListingAsync(Map.WebToDB(listing));
            return response;
        }
        [HttpDelete("DeleteListing/id")]
        public async Task<string> DeleteListingAsync(long id)
        {
            var response = await _listingService.DeleteListingAsync(id);
            return "success";
        }
    }
}