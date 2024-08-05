using Solway.Errors;
using Solway.Models;

namespace Solway.DTO;

public class ServerResponse : ApiResponse
{
    public object? Objects { get; set; }

    public ServerResponse(int statusCode, string? message = null) : base(statusCode, message) { }
}