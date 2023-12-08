using System.Net;
using CodeCollab___Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using CodeCollab___Gateway.Services;

namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _service = new();

    [HttpPost("CreateFile", Name = "CreateFile")]
    public async Task<IActionResult> CreateFile([FromBody] CodeFileModel codeFile)
    {
        var message = await _service.CreateFile(codeFile);

        if (message.StatusCode == HttpStatusCode.OK)
        {
            return Ok("Code file successfully created.");
        }

        return BadRequest("Failed to create code file.");
    }
}