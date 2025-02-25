using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson requestRegister) 
    {
        // Validar a request.
        Validate(requestRegister);

        // Mapear a request em uma entidade.

        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping()); 
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entites.User>(requestRegister);

        // Criptografia da senha.

        // Salvar no banco de dados.

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
