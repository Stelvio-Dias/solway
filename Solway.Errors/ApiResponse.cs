namespace Solway.Errors;

public class ApiResponse
{
    private int _statusCode;
    public int StatusCode
    {
        get { return _statusCode; }
        set
        {
            _statusCode = value;
            Message = ApiResponse.GetDefaultMessageWithStatusCode(value);
        }
    }
    public string Message { get; set; } = string.Empty;

    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageWithStatusCode(statusCode);
    }

    public static string GetDefaultMessageWithStatusCode(int statusCode)
    {
        return (int)statusCode switch
        {
            200 => "Request processed successfully!",
            201 => "Resource created successfully!",
            204 => "No content to return.",
            400 => "The request is poorly formatted.",
            401 => "You are not authorized to access this resource.",
            402 => "Payment required to access this resource.",
            403 => "Access denied. You do not have permission to perform this action.",
            404 => "The requested resource was not found.",
            405 => "Method not allowed. Use the [correct method] for this action.",
            406 => "Unsupported content format. Use the [correct format].",
            413 => "Request size exceeds the allowed limit. Reduce the size and try again.",
            418 => "I am a teapot! This request makes no sense to me.",
            422 => "Invalid entity. Check the errors and try again.",
            429 => "Too many requests in a short period. Wait and try again.",
            451 => "Resource unavailable for legal reasons.",
            500 => "Internal server error. Please try again later.",
            503 => "Service unavailable at the moment. Please try again later.",
            504 => "Gateway timeout. Please try again.",
            _ => "Unexpected error. Please try again later."
        };
    }
}