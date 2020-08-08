using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Persistence.Configurations
{
    public class ReviewMediaConfiguration : EntityConfiguration<ReviewMedia>
    {
        public override void Map(EntityTypeBuilder<ReviewMedia> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
