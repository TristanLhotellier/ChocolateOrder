namespace Models;

public class Buyer : BaseModel
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Phone { get; set; }

    public Buyer()
    {
       
    }
}