namespace Models;

public class Buyer
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Phone { get; set; }

    public Buyer(Guid id, string lastName, string firstName, int phone)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        Phone = phone;
    }
}