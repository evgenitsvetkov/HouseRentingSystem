using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableExtension
    {
        public static IQueryable<HouseServiceModel> ProjectToHouseServiceModel(this IQueryable<House> houses)
        {
            return houses
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth
                });
        }
    }
}
