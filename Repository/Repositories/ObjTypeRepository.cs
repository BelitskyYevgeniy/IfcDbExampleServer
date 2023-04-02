using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class ObjTypeRepository : GenericRepositoryAsync<IfcObjTypeEntity>, IObjTypeRepository
    {
        public ObjTypeRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}
