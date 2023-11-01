namespace Models;

public class PurchasedArticle
{
    public Guid IdBuyer { get; set; }
    public Guid IdChocolate { get; set; }
    public int Quantity{ get; set; }
    public DateTime PurchasedDate { get; set; }

    public PurchasedArticle(Guid idBuyer, Guid idChocolate, int quantity, DateTime purchasedDate)
    {
        IdBuyer = idBuyer;
        IdChocolate = idChocolate;
        Quantity = quantity;
        PurchasedDate = purchasedDate;
    }
}