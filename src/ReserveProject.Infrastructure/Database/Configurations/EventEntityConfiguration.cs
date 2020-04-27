using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class EventEntityConfiguration : EntityConfiguration<Event>
    {
        public override void Map(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events", DbSchemas.Event);
        }
    }
}