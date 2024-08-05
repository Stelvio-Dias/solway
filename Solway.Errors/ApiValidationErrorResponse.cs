namespace Solway.Errors;

public class ApiValidationErrorResponse : ApiResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();

    public ApiValidationErrorResponse() : base(400) { }
}