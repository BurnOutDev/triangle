﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;

namespace ReserveProject.Persistence.Configurations
{
    public class MenuItemConfiguration : EntityConfiguration<MenuItem>
    {
        public override void Map(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
