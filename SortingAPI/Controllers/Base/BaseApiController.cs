using Microsoft.AspNetCore.Mvc;

namespace SortingAPI.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected IActionResult HandleResult<T>(T result)
    {
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);

    }

}