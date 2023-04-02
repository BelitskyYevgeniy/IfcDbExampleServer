using Microsoft.EntityFrameworkCore;

using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class ValueRepository : GenericRepositoryAsync<IfcValueEntity>, IValueRepository
    {
        public ValueRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}
