using ProgramSAP.ApplicationServices.API.Domain.Error;

namespace ProgramSAP.ApplicationServices.API.Domain;

public class ResponseBase<T> : ErrorResponseBase
{
    public T Data { get; set; }
}
