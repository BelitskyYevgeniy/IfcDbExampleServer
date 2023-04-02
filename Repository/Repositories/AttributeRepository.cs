using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class AttributeRepository : GenericRepositoryAsync<IfcAttributeEntity>, IAttributeRepository
    {
        public AttributeRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}
