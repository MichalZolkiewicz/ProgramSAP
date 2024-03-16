using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgramSAP.ApplicationServices.API.Domain.Error;
using ProgramSAP.ApplicationServices.API.Domain.ErrorHandling;
using System.Net;

namespace ProgramSAP.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMediator mediator;

    protected ApiControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
    {
        if(!this.ModelState.IsValid)
        {
            return this.BadRequest(
                this.ModelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new { property = x.Key, errors = x.Value.Errors }));
        }
        var response = await this.mediator.Send(request);
        if(response.Error != null)
        {

        }

        return this.Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        return StatusCode((int)httpCode, errorModel);
    }

    private static HttpStatusCode GetHttpStatusCode(string error)
    {
        switch(error)
        {
            case ErrorType.NotFound:
                return HttpStatusCode.NotFound;
            case ErrorType.Unauthorized:
                return HttpStatusCode.Unauthorized;
            case ErrorType.ValidationError: 
                return HttpStatusCode.NotAcceptable;
            case ErrorType.InternalSeverError: 
                return HttpStatusCode.InternalServerError;
            case ErrorType.NotAuthenticated: 
                return HttpStatusCode.NotAcceptable;
            case ErrorType.TooManyRequests: 
                return HttpStatusCode.TooManyRequests;  
            case ErrorType.RequestTooLarge: 
                return HttpStatusCode.RequestEntityTooLarge;
            case ErrorType.EmptyOrNullRequest:
                return HttpStatusCode.Forbidden;
            default:
                return HttpStatusCode.BadRequest;
        }
    }
}
