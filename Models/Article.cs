namespace Models;

public class Article : BaseModel
{
    public Guid Id { get; set; }
    public string Reference { get; set; }
    public float Price { get; set; } = 5;

    public Article()
    {
     
    }
}