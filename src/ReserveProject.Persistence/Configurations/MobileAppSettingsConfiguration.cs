using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain.Entities;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Persistence.Configurations
{
    public class MobileAppSettingsConfiguration : EntityConfiguration<MobileAppSettings>
    {
        public override void Map(EntityTypeBuilder<MobileAppSettings> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
