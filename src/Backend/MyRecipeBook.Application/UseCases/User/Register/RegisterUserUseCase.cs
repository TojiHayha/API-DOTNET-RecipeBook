using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson requestRegister) 
    {
        // Criptografia da senha.
        var encryptionPassword = new PasswordEncripter();

        // Mapear a request em uma entidade.
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        // Validar a request.
        Validate(requestRegister);

        var user = autoMapper.Map<Domain.Entites.User>(requestRegister);

        user.Password = encryptionPassword.Encrypt(requestRegister.Password);

        // Salvar no banco de dados.
        await _writeOnlyRepository.AddUser(user);

        return new ResponseRegisteredUserJson 
        { 
            Name = requestRegister.Name
        }; 
    }

    private void Validate(RequestRegisterUserJson requestRegister) {

        var validator = new RegisterUserValidator();

        var result = validator.Validate(requestRegister);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
