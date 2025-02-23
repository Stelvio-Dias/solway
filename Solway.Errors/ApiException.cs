﻿namespace Solway.Errors;

public class ApiException : ApiResponse
{
    public string Details { get; set; } = string.Empty;
    public ApiException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        => Details = details ?? string.Empty;
}