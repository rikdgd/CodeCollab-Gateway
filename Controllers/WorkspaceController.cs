using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CodeCollab___Gateway.Models;
using CodeCollab___Gateway.Services;
using CodeCollab___Gateway.Utils;


namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkspaceController : ControllerBase
{
    private readonly Messenger _messenger;
    private readonly WorkspaceService _service = new();

    public WorkspaceController(Messenger messenger)
    {
        _messenger = messenger;
    }
    
    
    [HttpGet(Name = "GetWorkspace")]
    public async Task<IActionResult> GetWorkspace(long id)
    {
        string url = "https://localhost:7031/Workspace";
        string content = await _service.GetById(url, id);
        return Ok(content);
    }


    [HttpPost(Name = "CreateWorkspace")]
    public IActionResult CreateWorkspace([FromBody] WorkspaceModel workspace)
    {
        try
        {
            string workspaceJson = JsonSerializer.Serialize(workspace);
            
            _messenger.SendMessage($"CREATE Workspace FROM: {workspaceJson}");
        
            return Ok($"Successfully created workspace from JSON:\n {workspaceJson}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest("Failed to create the new workspace.");
        }
    }
}