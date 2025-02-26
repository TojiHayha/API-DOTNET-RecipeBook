namespace MyRecipeBook.Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    public Task AddUser(Entites.User user); 
}

