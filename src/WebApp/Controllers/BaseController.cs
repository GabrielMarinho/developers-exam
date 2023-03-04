using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class BaseController : Controller
{
    protected IActionResult CreateResponse(Response response)
    {
        if (response.Errors is not null)
            return View(new
            {
                Success = false,
                response.Errors
            });

        return View(new
        {
            Success = true,
            response.Data
        });
    }
}