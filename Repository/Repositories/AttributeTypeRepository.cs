using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class AttributeTypeRepository : GenericRepositoryAsync<IfcAttributeTypeEntity>, IAttributeTypeRepository
    {
        public AttributeTypeRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}

