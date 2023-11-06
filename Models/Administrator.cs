namespace Models;

public class Administrator : BaseModel
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public Administrator()
    {
        
    }

    public Administrator(Guid id, string login, string password)
    {
        Id = id;
        Login = login;
        Password = password;
    }
}