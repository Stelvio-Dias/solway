using Solway.Errors;

namespace Solway.API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : BaseAPIController
{
    public ActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
}