using System.Linq.Expressions;

using Services.Exceptions;
using Services.Interfaces;

using Repository.Interfaces;

using IfcDb;
using IfcDb.Helpers;
using IfcDb.Interfaces;
using IfcDb.Models.Entities;

using FileNotFoundException = Services.Exceptions.FileNotFoundException;

namespace Services.Services
{
    public class IfcFileService : IIfcFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileDataHelper _fileDataHelper;
        public IfcFileService(IFileDataHelper fileDataHelper, IFileRepository fileRepository)
        {
            this._fileRepository = fileRepository;
            this._fileDataHelper = fileDataHelper;
        }

        public async Task<IReadOnlyCollection<string>> GetAllFileNames(CancellationToken ct = default)
        {
            var projects = await _fileRepository.GetAllAsync(ct);
            return projects.Select(x => x.Name).ToList();
        }

        public Task<bool> Exists(string filename, CancellationToken ct = default)
        {
            return _fileRepository.Exists(filename, ct);
        }

        public async Task<string> GetContent(string name, CancellationToken ct = default)
        {
            var project = (await _fileRepository.FindAsync(filter: new List<Expression<Func<IfcFileEntity, bool>>>() { p => p.Name == name }, ct: ct)).FirstOrDefault();
            if (project == null)
            {
                throw new FileNotFoundException();
            }
            var file = await _fileDataHelper.GetAsync(project.Name, ct);
            return file.ToString();
        }

        public async Task SaveIfcFile(Models.IfcFile file, CancellationToken ct = default)
        {
            var fileExists = await _fileRepository.Exists(file.FileName, ct);
            if (fileExists)
            {
                throw new FileAlreadyExistsException();
            }

            var fileEntity = _fileDataHelper.ParseFile(file.Content);
            fileEntity.Name = file.FileName;
            await _fileDataHelper.AddFileAsync(fileEntity, ct);
        }
    }
}
