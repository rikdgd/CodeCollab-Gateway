using Microsoft.AspNetCore.Mvc;

namespace CodeCollab___Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkspaceController : ControllerBase
{
    [HttpGet(Name = "GetWorkspace")]
    public async Task<IActionResult> GetWorkspace(long id)
    {
        string content = await GetById("url", id);
        return Ok(content);
    }

    private async Task<string> GetById(string url,  long id)
    {
        using (HttpClient client = new HttpClient())
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
                return "Request failed.";
            }
        }
    }
}