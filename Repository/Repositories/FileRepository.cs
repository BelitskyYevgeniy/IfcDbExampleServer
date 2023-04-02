using Microsoft.EntityFrameworkCore;

using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class FileRepository : GenericRepositoryAsync<IfcFileEntity>, IFileRepository
    {
        public FileRepository(IfcDbContext dbContext) : base(dbContext) { }

        public async Task<bool> Exists(string name, CancellationToken ct = default)
        {
            var project = await _dbContext.Files.FirstOrDefaultAsync(p => p.Name == name, ct);
            return project != null;
        }
    }
}
