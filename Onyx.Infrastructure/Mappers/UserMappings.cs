namespace Onyx.Infrastructure.Mappers;

public static class UserMappings
{
    extension (DbModels.User db)
    {
        public Domain.Models.User ToDomain()
            => new(
                db.Id,
                db.Email,
                db.Username,
                db.FirstName,
                db.LastName,
                db.CreatedAt,
                db.IsDeleted
            );
    }

    extension(Domain.Models.User domain)
    {
        public DbModels.User ToDb()
            => new()
            {
                Id = domain.Id,
                Email = domain.Email,
                Username = domain.Username,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                CreatedAt = domain.CreationDate,
                IsDeleted = domain.IsDeleted
            };
    }
}