namespace CodeCollab___Gateway.Services;

public class UniversalService
{
    public async Task<string> GetById(string url,  long id)
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
                return ex.Message;
            }
        }
    }
}