using Microsoft.AspNetCore.Mvc;

namespace SimpleErpApi.Controllers;

[ApiController]
[Route("/")]
public class ApiStatusController : ControllerBase
{
  [HttpGet]
  public IActionResult Index()
  {
      return  StatusCode(200, "A API está pronta para ser utilizada!");
  }
}
