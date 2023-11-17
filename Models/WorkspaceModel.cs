namespace CodeCollab___Gateway.Models;


public class WorkspaceModel
{
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
