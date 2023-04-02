using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class ObjDestinationRepository : GenericRepositoryAsync<IfcObjDestinationEntity>, IObjDestinationRepository
    {
        public ObjDestinationRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}
