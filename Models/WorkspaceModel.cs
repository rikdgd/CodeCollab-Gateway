using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeCollab___Gateway.Models;


public class WorkspaceModel
{
    [JsonIgnore]
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId? Id { get; set; }
    public string Name { get; set; }
    public long OwnerId { get; set; }

    
    public WorkspaceModel() 
    {
        
    }

    public WorkspaceModel(string id, string name, int ownerId)
    {
        Id = ObjectId.Parse(id);
        Name = name;
        OwnerId = ownerId;
    }

    public WorkspaceModel(string name, long ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }
}
