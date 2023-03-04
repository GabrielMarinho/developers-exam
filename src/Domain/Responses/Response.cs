using Domain.Enums;
using Domain.Extensions;
using FluentValidation.Results;

namespace Domain.Responses;

public class Response
{
    public ValidationResult Errors { get; private set; }
    public object Data { get; private set; }

    private Response(object data = null, ValidationResult errors = null)
    {
        Data = data;
        Errors = errors;
    }
    
    public static Response CreateSuccess(object data = null)
    {
        return new Response(data);
    }

    public static Response CreateBadRequest(ValidationResult errors)
    {
        return new Response(null, errors);
    }

    public static Response CreateWithError(ErrorCode code)
    {
        var errors = new List<ValidationFailure>()
        {
            new ValidationFailure(
                code.GetDiaplay(),
                code.GetDescription())
        };

        return CreateBadRequest(new ValidationResult(errors));
    }
}