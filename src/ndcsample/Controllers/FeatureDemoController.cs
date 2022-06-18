using Microsoft.AspNetCore.Mvc;

namespace ndcsample.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureDemoController : ControllerBase
{

    private readonly ILogger<FeatureDemoController> _logger;

    public FeatureDemoController(ILogger<FeatureDemoController> logger)
    {
        _logger = logger;
    }

    [Route("Feature")]
    [HttpGet]
    public IActionResult InFeatureB()
    {
        return Ok("You are in feature B");
    }
}
