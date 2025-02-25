namespace MyRecipeBook.Domain.Entites;
public class User : EntityBase
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

