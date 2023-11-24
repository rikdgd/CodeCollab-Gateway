using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CodeCollab___Gateway.Models;
using CodeCollab___Gateway.Utils;


namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkspaceController : ControllerBase
{
    private readonly Messenger _messenger;

    public WorkspaceController(Messenger messenger)
    {
        _messenger = messenger;
    }
    
    
    [HttpGet(Name = "GetWorkspace")]
    public async Task<IActionResult> GetWorkspace(long id)
    {
        string url = "https://localhost:7031/Workspace";
        string content = await GetById(url, id);
        return Ok(content);
    }
    
    
    [HttpPost("CreateWorkspace", Name = "CreateWorkspace")]
    public IActionResult CreateWorkspace([FromBody] WorkspaceModel workspace)
    {
        try 
        {
            MessageModel<WorkspaceModel> messageModel = new MessageModel<WorkspaceModel>(
                "Command", 
                "CreateWorkspace", 
                workspace
            );

            string message = JsonSerializer.Serialize(messageModel);
            _messenger.SendMessage(message);
            
            return Ok("Workspace creation successfully added to queue.");
        }
        catch (Exception ex)
        {
            return BadRequest("An error occured when trying to create the workspace: \n" + ex.Message);
        }
    }
    

    // ToDo: Error handling
    private async Task<string> GetById(string url,  long id)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };
        
        using (HttpClient client = new HttpClient(handler))
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                
                return "Could not get response content.";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }
    }
}