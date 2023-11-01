namespace Models;

public class Article
{
    public Guid Id { get; set; }
    public string Reference { get; set; }
    public float Price { get; set; }

    public Article(Guid id, string reference, float price)
    {
        Id = id;
        Reference = reference;
        Price = price;
    }
}