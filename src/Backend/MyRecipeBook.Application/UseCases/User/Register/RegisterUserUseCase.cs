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
