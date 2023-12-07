using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeCollab___Gateway.Models;

public class CodeFileModel
{
    public string fileName { get; private set; }
    public string fileContent { get; set; }

    [BsonElement("user_id")] 
    public long userId { get; set; }

    [BsonElement("workspace_id")] 
    public long workspaceId { get; set; }
    

    public CodeFileModel(string fileName, string fileContent = "", long userId = 0, long workspaceId = 0)
    {
        this.fileName = fileName;
        this.fileContent = fileContent;
        this.userId = userId;
        this.workspaceId = workspaceId;
    }
}