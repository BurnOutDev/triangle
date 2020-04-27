﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReserveProject.Infrastructure.Database.Configurations.Infrastructure
{
    public interface IEntityMappingConfiguration<T> : IEntityConfiguration
        where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}