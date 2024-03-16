namespace ProgramSAP.ApplicationServices.API.Domain.Error;

public class ErrorModel
{
    public string Error { get; set; }
    public ErrorModel(string error) 
    {
        this.Error = error;
    }
}