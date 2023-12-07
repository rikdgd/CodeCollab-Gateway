using Microsoft.AspNetCore.Mvc;
using CodeCollab___Gateway.Services;

namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _service = new();

    [HttpPost("CreateFile", Name = "CreateFile")]
    public async Task<IActionResult> CreateFile()
    {
        return Ok("hoi");
    }
}