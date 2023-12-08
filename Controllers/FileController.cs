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
        var response = await _service.CreateFile(codeFile);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return Ok("Code file successfully created.");
        }

        return BadRequest("Failed to create code file.");
    }


    [HttpPost("UploadFile", Name = "UploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile? file, long userId, long workspaceId)
    {
        if (file == null || file.Length < 1)
        {
            return BadRequest("The uploaded file doesn't contain any content.");
        }

        CodeFileModel codeFile = new CodeFileModel(file.FileName, userId: userId, workspaceId: workspaceId);

        try
        {
            using (StreamReader streamReader = new StreamReader(file.OpenReadStream()))
            {
                string fileContent = await streamReader.ReadToEndAsync();
                codeFile.fileContent = fileContent;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("Failed to read the file's contents.");
        }
        
        var response = await _service.CreateFile(codeFile);
        
        if (response.StatusCode == HttpStatusCode.OK) return Ok("File uploaded successfully.");
        return BadRequest("Could not upload file.");
    }
}