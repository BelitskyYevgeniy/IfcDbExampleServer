using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using Services.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfcFilesController : ControllerBase
    {
        private readonly IIfcFileService _ifcFileService;

        public IfcFilesController(IIfcFileService ifcFileService)
        {
            this._ifcFileService = ifcFileService;
        }

        [HttpGet("files")]
        public async Task<IActionResult> GetFileNames(CancellationToken ct = default)
        {
            var filenames = await _ifcFileService.GetAllFileNames(ct);
            return Ok(filenames);
        }

        [HttpGet("content")]
        public async Task<IActionResult> Get(string filename, CancellationToken ct = default)
        {
            var content = await _ifcFileService.GetContent(filename, ct);
            return Ok(content);
        }

        [HttpPost]
        public Task Post([FromBody] IfcFile file, CancellationToken ct = default)
        {
            return _ifcFileService.SaveIfcFile(file, ct);
        }
    }
}
