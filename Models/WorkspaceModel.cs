using System.Text.Json.Serialization;

namespace CodeCollab___Gateway.Models;


public class WorkspaceModel
{
    [JsonIgnore]
    public string? Id { get; set; }
    public string Name { get; set; }
    public long OwnerId { get; set; }

    
    public WorkspaceModel() 
    {
        
    }

    public WorkspaceModel(string name, int ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }
}
