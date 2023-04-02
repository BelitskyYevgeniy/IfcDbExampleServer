using IfcDb.Models.Entities;

namespace Repository.Interfaces
{
    public interface IFileRepository : IGenericRepositoryAsync<IfcFileEntity>
    {
        Task<bool> Exists(string name, CancellationToken ct = default);
    }
}
