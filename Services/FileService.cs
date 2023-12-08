using System.Net;
using System.Text;
using CodeCollab___Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeCollab___Gateway.Services;

public class FileService : UniversalService
{
    public async Task<HttpResponseMessage> CreateFile(CodeFileModel codeFile)
    {
        const string url = "https://localhost:7115/files/SaveFile";
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpResponseMessage response;
        using (HttpClient client = new HttpClient(handler))
        {
            string jsonData = JsonConvert.SerializeObject(codeFile);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            response = await client.PostAsync(url, content);
        }

        return response;
    }
}