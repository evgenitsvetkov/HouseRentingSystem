﻿using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HouseQueryServiceModel> AllAsync(
            string category = null, 
            string searchTerm = null, 
            HouseSorting sorting = HouseSorting.Newest, 
            int currentPage = 1, 
            int housesPerPage = 1)
        {
            var housesToShow = repository.AllReadOnly<House>();

            if (category != null)
            {
                housesToShow = housesToShow.Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearch = searchTerm.ToLower();

                housesToShow = housesToShow
                    .Where(h => (h.Title.ToLower().Contains(normalizedSearch) ||
                                 h.Address.ToLower().Contains(normalizedSearch) ||
                                 h.Description.ToLower().Contains(normalizedSearch)));
            }

            housesToShow = sorting switch
            {
                HouseSorting.Price => housesToShow
                .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesToShow
                .OrderBy(h => h.RenterId == null)
                .ThenByDescending(h => h.Id),
                _ => housesToShow
                    .OrderByDescending(h => h.Id)
            };

            var houses = await housesToShow
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjectToHouseServiceModel()
                .ToListAsync();

            int totalHouses = await housesToShow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository
               .AllReadOnly<Category>()
               .Select(c => new HouseCategoryServiceModel()
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.AgentId == agentId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.RenterId == userId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await repository
                .AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title
            };

            await repository.AddAsync(house);
            await repository.SaveChangesAsync();

            return house.Id;
        }

        public async Task Delete(int houseId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);
            await repository.DeleteAsync(house);           
        }

        public async Task EditAsync(int houseId, HouseFormModel model)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.Title = model.Title;
                house.Address = model.Address;
                house.ImageUrl = model.ImageUrl;
                house.Description = model.Description;
                house.PricePerMonth = model.PricePerMonth;
                house.CategoryId = model.CategoryId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<HouseDetailsViewModel?> GetHouseDetailsViewModelByIdAsync(int id)
        {
            var house = await repository.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsViewModel()
                {
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return house;
        }

        public async Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id)
        {
            var house = await repository.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseFormModel()
                {
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    Description = h.Description,
                    PricePerMonth = h.PricePerMonth,
                    CategoryId = h.CategoryId,
                })
                .FirstOrDefaultAsync();

            if (house != null)
            {
                house.Categories = await AllCategoriesAsync();
            }

            return house;   
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
        {
            return await repository.AllReadOnly<House>().AnyAsync(h => h.Id == houseId && h.Agent.UserId == userId);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                   Id = h.Id,
                   Title = h.Title,
                   Address = h.Address,
                   ImageUrl = h.ImageUrl,
                   IsRented = h.RenterId != null,
                   PricePerMonth = h.PricePerMonth,
                   Agent = new Models.Agent.AgentServiceModel()
                   {
                       Email = h.Agent.User.Email,
                       PhoneNumber = h.Agent.User.PhoneNumber
                   },
                   Description = h.Description,
                   Category = h.Category.Name

                })
                .FirstAsync();
        }

        public async Task<bool> IsRentedAsync(int id)
        {
            return await repository.AllReadOnly<House>().AnyAsync(h => h.Id == id && h.RenterId != null);
        }

        public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
        {
            return await repository.AllReadOnly<House>().AnyAsync(h => h.Id == houseId && h.RenterId == userId);
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
        {
            return await repository
                .AllReadOnly<House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .ToListAsync();
        }

        public async Task Leave(int houseId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.RenterId = null;
                await repository.SaveChangesAsync();
            }
        }

        public async Task Rent(int houseId, string userId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.RenterId = userId;
                await repository.SaveChangesAsync();
            }
        }
    }
}
