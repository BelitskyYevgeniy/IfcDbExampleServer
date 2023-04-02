using Repository.Interfaces;

using IfcDb;
using IfcDb.Models.Entities;

namespace Repository.Repositories
{
    public class ObjRepository : GenericRepositoryAsync<IfcObjEntity>, IObjRepository
    {
        public ObjRepository(IfcDbContext dbContext) : base(dbContext) { }
    }
}
