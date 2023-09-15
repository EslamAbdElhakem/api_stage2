namespace api_stage2.Models;

public class stageItem
{
    public long Id { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
    public string Name { get; set; }

    public int Age { get; set; }
}
public class TodoItemDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}

public class PersonDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}