using Microsoft.AspNetCore.Mvc;

namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkspaceController : ControllerBase
{
    [HttpGet(Name = "GetWorkspace")]
    public async Task<IActionResult> GetWorkspace(long id)
    {
        string url = "https://localhost:7031/Workspace";
        string content = await GetById(url, id);
        return Ok(content);
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