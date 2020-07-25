using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class RestaurantManagementService : IRestaurantManagementService
    {
        public ReserveDbContext Context { get; }

        public RestaurantManagementService(ReserveDbContext context)
        {
            Context = context;
        }

        public void AddRestaurant(AddRestaurantCommand addRestaurantCommand)
        {
            var cuisine = Context.Find<Cuisine>(addRestaurantCommand.CuisineId);

            var restaurant = new Restaurant
            {
                Name = addRestaurantCommand.Name,
                Description = addRestaurantCommand.Description,
                PhoneNumber = addRestaurantCommand.PhoneNumber,
                WebsiteUrl = addRestaurantCommand.WebsiteUrl,
                Email = addRestaurantCommand.Email,
                BusinessId = addRestaurantCommand.BusinessId,
                FacebookId = addRestaurantCommand.FacebookId,
                HasParking = addRestaurantCommand.HasParking,
                IsCardPaymentAvailable = addRestaurantCommand.IsCardPaymentAvailable,
                PriceRange = addRestaurantCommand.PriceRange,
                Cuisine = cuisine,
                Address = addRestaurantCommand.Address,
                AddressLatitude = addRestaurantCommand.AddressLatitude,
                AddressLongtitude = addRestaurantCommand.AddressLongtitude,
                ImageUrl = addRestaurantCommand.Image
            };

            restaurant.BusinessHours = addRestaurantCommand.BusinessHours?.Select(workday => new BusinessHours
            {
                Restaurant = restaurant,
                WeekDay = workday.WeekDay,
                OpeningTime = TimeSpan.Parse(workday.OpeningTime),
                ClosingTime = TimeSpan.Parse(workday.ClosingTime)
            }).ToList();

            Context.Add(restaurant);
            Context.SaveChanges();
        }

        public void ChangeBusinessHours(ChangeBusinessHoursCommand businessHoursCommand)
        {
            var restaurant = Context.Find<Restaurant>(businessHoursCommand.RestaurantId);
            var businessHours = Context.Set<BusinessHours>().Where(businessHour => businessHour.Restaurant.Id == businessHoursCommand.RestaurantId);

            Context.Set<BusinessHours>().RemoveRange(businessHours);

            Context.AddRange(businessHoursCommand.BusinessHours.Select(workday => new BusinessHours
            {
                Restaurant = restaurant,
                WeekDay = workday.WeekDay,
                OpeningTime = TimeSpan.Parse(workday.OpeningTime),
                ClosingTime = TimeSpan.Parse(workday.ClosingTime)
            }).ToList());

            Context.Update(restaurant);
            Context.SaveChanges();
        }

        public void UpdateRestaurant(string userId, UpdateRestaurantCommand updateRestaurantCommand)
        {
            var restaurant = GetRestaurantByUserId(userId);

            restaurant.Name = updateRestaurantCommand.Name;
            restaurant.Description = updateRestaurantCommand.Description;
            restaurant.PhoneNumber = updateRestaurantCommand.PhoneNumber;
            restaurant.WebsiteUrl = updateRestaurantCommand.WebsiteUrl;
            restaurant.Email = updateRestaurantCommand.Email;

            restaurant.FacebookId = updateRestaurantCommand.FacebookId;

            restaurant.ImageUrl = updateRestaurantCommand.ImageUrl;

            restaurant.Address = updateRestaurantCommand.Address;
            restaurant.AddressLatitude = updateRestaurantCommand.AddressLatitude;
            restaurant.AddressLongtitude = updateRestaurantCommand.AddressLongtitude;

            restaurant.CuisineId = updateRestaurantCommand.CuisineId;
            restaurant.PriceRange = updateRestaurantCommand.PriceRange;

            restaurant.HasParking = updateRestaurantCommand.HasParking;
            restaurant.IsCardPaymentAvailable = updateRestaurantCommand.IsCardPaymentAvailable;

            Context.Update(restaurant);
            Context.SaveChanges();
        }

        public void AddMenuItem(string userId, AddMenuItemCommand addMenuItemCommand)
        {
            var category = Context.Find<Category>(addMenuItemCommand.CategoryId);

            var restaurant = GetRestaurantByUserId(userId);

            var menuItem = new MenuItem
            {
                Name = addMenuItemCommand.Name,
                Description = addMenuItemCommand.Description,
                ImageUrl = addMenuItemCommand.ImageUrl,
                Category = category,
                Restaurant = restaurant,
                Price = addMenuItemCommand.Price,
                Unavailable = false
            };

            var x = Context.Set<Ingredient>()
                .Where(ingredient => addMenuItemCommand.IngredientIds.Contains(ingredient.Id));

            var select = x.Select(ingredient => new MenuItemIngredients
            {
                MenuItem = menuItem,
                Ingredient = ingredient
            }).ToList();

            menuItem.MenuItemIngredients = select;

            Context.Add(menuItem);
            Context.SaveChanges();
        }

        public void EditMenuItem(string userId, EditMenuItemCommand editMenuItemCommand)
        {
            var category = Context.Find<Category>(editMenuItemCommand.CategoryId);

            var restaurant = GetRestaurantByUserId(userId);

            var item = Context.Set<MenuItem>().Find(editMenuItemCommand.Id);

            item.Name = editMenuItemCommand.Name;
            item.Description = editMenuItemCommand.Description;
            item.ImageUrl = editMenuItemCommand.ImageUrl;
            item.Category = category;
            item.Restaurant = restaurant;
            item.Price = editMenuItemCommand.Price;
            item.Unavailable = false;

            var oldIngredients = Context.Set<MenuItemIngredients>().Where(x => x.MenuItem.Id == item.Id);

            Context.RemoveRange(oldIngredients);

            var x = Context.Set<Ingredient>()
                .Where(ingredient => editMenuItemCommand.IngredientIds.Contains(ingredient.Id));

            var select = x.Select(ingredient => new MenuItemIngredients
            {
                MenuItem = item,
                Ingredient = ingredient
            }).ToList();

            item.MenuItemIngredients = select;

            Context.Update(item);
            Context.SaveChanges();
        }

        public void AddIngredient(AddIngredientCommand addIngredientCommand)
        {
            var ingredient = new Ingredient
            {
                Name = addIngredientCommand.Name,
                IsAllergen = addIngredientCommand.IsAllergen,
                IsVegan = addIngredientCommand.IsVegan,
                IsVegetarian = addIngredientCommand.IsVegetarian
            };

            Context.Add(ingredient);
            Context.SaveChanges();
        }

        public void AddCategory(AddCategoryCommand addCategoryCommand)
        {
            var category = new Category
            {
                Name = addCategoryCommand.Name,
                Icon = addCategoryCommand.Icon
            };

            Context.Add(category);
            Context.SaveChanges();
        }

        public void AddCuisine(AddCuisineCommand addCuisineCommand)
        {
            var cuisine = new Cuisine
            {
                Name = addCuisineCommand.Name,
                Icon = addCuisineCommand.Icon
            };

            Context.Add(cuisine);
            Context.SaveChanges();
        }

        public RestaurantsPerCategoryQueryResult RestaurantsPerCategory(RestaurantsPerCategoryQuery restaurantsPerCategoryQuery)
        {
            var restaurants = Context.Set<Restaurant>().Select(restaurant => new RestaurantsPerCategoryQueryResult.RestaurantItem
            {
                Title = restaurant.Name,
                Cuisine = restaurant.Cuisine.Name,
                PriceRange = (int)restaurant.PriceRange,
                Image = restaurant.ImageUrl,
                Address = restaurant.Address,
                Rating = $"4.{new Random().Next(0, 9)}",
                ReviewsCount = new Random().Next(24, 90)
            });

            var queryResult = new RestaurantsPerCategoryQueryResult
            {
                CategoryName = restaurantsPerCategoryQuery.CategoryName,
                Restaurants = restaurants.ToList()
            };

            //Image = restaurant.Media
            //                .Where(x => x.Format == MediaFormat.Picture)
            //                .Select(x => x.Url)
            //                .FirstOrDefault(),

            return queryResult;
        }

        public RestaurantsQueryResult Restaurants()
        {
            var restaurants = Context.Set<Restaurant>().Select(restaurant => new RestaurantsQueryResult.RestaurantItem
            {
                Title = restaurant.Name,
                Cuisine = restaurant.Cuisine.Name,
                PriceRange = (int)restaurant.PriceRange,
                Image = restaurant.ImageUrl,
                Address = restaurant.Address,
                Rating = $"4.{new Random().Next(0, 9)}",
                ReviewsCount = new Random().Next(24, 90)
            });

            var queryResult = new RestaurantsQueryResult
            {
                Restaurants = restaurants.ToList()
            };

            return queryResult;
        }

        public CuisinesQueryResult Cuisines()
        {
            var cuisines = Context.Set<Cuisine>().Select(cuisine => new CuisinesQueryResult.CuisineItem
            {
                CuisineId = cuisine.Id,
                Title = cuisine.Name,
                RestaurantQuantity = cuisine.Restaurants.Count,
                Image = cuisine.Icon
            });

            var queryResult = new CuisinesQueryResult
            {
                Cuisines = cuisines.ToList()
            };

            return queryResult;
        }

        public RestaurantProfileQueryResult RestaurantProfile(string userId)
        {
            var restaurant = GetRestaurantByUserId(userId);

            var queryResult = new RestaurantProfileQueryResult
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                Address = restaurant.Address,
                AddressLatitude = restaurant.AddressLatitude,
                AddressLongtitude = restaurant.AddressLongtitude,
                BusinessId = restaurant.BusinessId,
                Email = restaurant.Email,
                FacebookId = restaurant.FacebookId,
                HasParking = restaurant.HasParking,
                ImageUrl = restaurant.ImageUrl,
                IsCardPaymentAvailable = restaurant.IsCardPaymentAvailable,
                PhoneNumber = restaurant.PhoneNumber,
                PriceRange = (int)restaurant.PriceRange,
                WebsiteUrl = restaurant.WebsiteUrl,
                CuisineId = restaurant.Cuisine.Id
            };

            return queryResult;
        }

        private Restaurant GetRestaurantByUserId(string userId)
        {
            return Context.Set<IdentityUserRestaurant>().Where(user => user.IdentityUserId == userId).FirstOrDefault().Restaurant;
        }

        public IngredientsQueryResult Ingredients()
        {
            var ingredients = Context.Set<Ingredient>().Select(ingredient => new IngredientsQueryResult.IngredientItem
            {
                IngredientId = ingredient.Id,
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen,
                IsVegan = ingredient.IsVegan,
                IsVegetarian = ingredient.IsVegetarian,
            });

            var queryResult = new IngredientsQueryResult
            {
                Ingredients = ingredients.ToList()
            };

            return queryResult;
        }

        public CategoriesQueryResult Categories()
        {
            var categories = Context.Set<Category>().Select(category => new CategoriesQueryResult.CategoryItem
            {
                CategoryId = category.Id,
                Name = category.Name
            });

            var queryResult = new CategoriesQueryResult
            {
                Categories = categories.ToList()
            };

            return queryResult;
        }

        public KeyValuesQueryResult CategoriesKeyValues()
        {
            var categories = Context.Set<Category>().ToDictionary(x => x.Id, x => x.Name);

            var queryResult = new KeyValuesQueryResult(categories);

            return queryResult;
        }

        public RestaurantMenuItemsQueryResult GetMenuItems(string userId)
        {
            var restaurant = GetRestaurantByUserId(userId);

            var menuItems = restaurant.MenuItems.Select(x => new RestaurantMenuItemsQueryResult.RestaurantMenuItem
            {
                CategoryId = x.Category.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IngredientIds = x.MenuItemIngredients.Select(ingredient => ingredient.Id).ToArray(),
                Name = x.Name,
                Price = x.Price,
                Unavailable = x.Unavailable,
                MenuItemId = x.Id,
                CategoryName = x.Category.Name
            }).ToList();

            var queryResult = new RestaurantMenuItemsQueryResult
            {
                MenuItems = menuItems,
                RestaurantId = restaurant.Id
            };

            return queryResult;
        }

        public RestaurantMenuItemQueryResult Get(int id)
        {
            var queryResult = Context.Set<MenuItem>().Where(x => x.Id == id).Select(x => new RestaurantMenuItemQueryResult
            {
                CategoryId = x.Category.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IngredientIds = x.MenuItemIngredients.Select(ingredient => ingredient.Id).ToArray(),
                Name = x.Name,
                Price = x.Price,
                Unavailable = x.Unavailable,
                MenuItemId = x.Id,
                CategoryName = x.Category.Name
            }).FirstOrDefault();

            return queryResult;
        }

        public void Update(UpdateMenuItemCommand queryResult)
        {
            var mi = Context.Set<MenuItem>().FirstOrDefault(x => x.Id == queryResult.MenuItemId);

            mi.Category.Id = queryResult.CategoryId;
            mi.Description = queryResult.Description;
            mi.ImageUrl = queryResult.ImageUrl;
            mi.Name = queryResult.Name;
            mi.Price = queryResult.Price;
            mi.Unavailable = queryResult.Unavailable;
            mi.Id = queryResult.MenuItemId;

            var ingredientsNeedsToBeUpdated = Enumerable.SequenceEqual(mi.MenuItemIngredients.Select(x => x.Id), queryResult.IngredientIds);

            if (ingredientsNeedsToBeUpdated)
            {
                var ingredientsToRemove = Context.Set<MenuItemIngredients>().Where(x => x.MenuItem.Id == x.Id);

                Context.RemoveRange(ingredientsToRemove);

                var ingredientsToAdd = Context.Set<Ingredient>().Where(x => queryResult.IngredientIds.Contains(x.Id))
                    .Select(x => new MenuItemIngredients
                    {
                        Ingredient = x,
                        MenuItem = mi
                    });

                Context.AddRange(ingredientsToAdd);
            }

            Context.Update(mi);
        }
    }
}
