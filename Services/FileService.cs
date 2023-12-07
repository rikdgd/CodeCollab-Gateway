using CodeCollab___Gateway.Models;

namespace CodeCollab___Gateway.Services;

public class FileService : UniversalService
{
    public async Task<bool> CreateFile(CodeFileModel codeFile)
    {
        const string url = "https://localhost:7115/files/SaveFile";
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        using (HttpClient client = new HttpClient(handler))
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, codeFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        return true;
    }
}