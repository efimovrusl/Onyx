namespace Onyx.Infrastructure.Mappers;

public static class GroupMappings
{
    extension (DbModels.Group db)
    {
        public Domain.Models.Group ToDomain()
            => new(db.Id, db.Name);
    }

    extension (Domain.Models.Group domain)
    {
        public DbModels.Group ToDb()
            => new()
            {
                Id = domain.Id,
                Name = domain.Name
            };
    }
}