﻿using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;
using System.Collections.Generic;

namespace ReserveProject.Application.Services
{
    public interface IRestaurantManagementService
    {
        ReserveDbContext Context { get; }

        void AddRestaurant(AddRestaurantCommand addRestaurantCommand);
        void ChangeBusinessHours(ChangeBusinessHoursCommand businessHoursCommand);
        void AddMenuItem(AddMenuItemCommand addMenuItemCommand);
        void AddIngredient(AddIngredientCommand addIngredientCommand);
        void AddCategory(AddCategoryCommand addCategoryCommand);
        void AddCuisine(AddCuisineCommand addCuisineCommand);
        RestaurantsPerCategoryQueryResult RestaurantsPerCategory(RestaurantsPerCategoryQuery restaurantsPerCategoryQuery);
        CuisinesQueryResult Cuisines();
        RestaurantProfileQueryResult RestaurantProfile(string userId);
        void UpdateRestaurant(string userId, UpdateRestaurantCommand updateRestaurantCommand);
        public RestaurantMenuItemsQueryResult GetMenuItems(string userId);
        CategoriesQueryResult Categories();
        IngredientsQueryResult Ingredients();
        KeyValuesQueryResult CategoriesKeyValues();
    }
}