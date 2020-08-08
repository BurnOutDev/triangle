using Microsoft.EntityFrameworkCore;
using ReserveProject.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Persistence
{
    public class ReserveDbContext : DbContext
    {
        public ReserveDbContext()
        {
        }

        public ReserveDbContext(DbContextOptions<ReserveDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new BusinessHoursConfiguration());
            builder.AddConfiguration(new CategoryConfiguration());
            builder.AddConfiguration(new CuisineConfiguration());
            builder.AddConfiguration(new CustomerConfiguration());
            builder.AddConfiguration(new IngredientConfiguration());
            builder.AddConfiguration(new MediaConfiguration());
            builder.AddConfiguration(new MenuItemConfiguration());
            builder.AddConfiguration(new MenuItemsIngredientConfiguration());
            builder.AddConfiguration(new PromoConfiguration());
            builder.AddConfiguration(new ReservationConfiguration());
            builder.AddConfiguration(new ReservationMenuItemConfiguration());
            builder.AddConfiguration(new RestaurantConfiguration());
            builder.AddConfiguration(new ReviewConfiguration());
            builder.AddConfiguration(new SeatTypeConfiguration());
            builder.AddConfiguration(new UserConfiguration());
            builder.AddConfiguration(new CustomerFavoriteRestaurantsConfiguration());
            builder.AddConfiguration(new MobileAppSettingsConfiguration());
            builder.AddConfiguration(new ReviewMediaConfiguration());
        }
    }
}
