namespace Services.Interfaces
{
    public interface IIfcFileService
    {
        Task<IReadOnlyCollection<string>> GetAllFileNames(CancellationToken ct = default);
        Task SaveIfcFile(Models.IfcFile file, CancellationToken ct = default);
        Task<string> GetContent(string name, CancellationToken ct = default);
        Task<bool> Exists(string filename, CancellationToken ct = default);
    }
}
