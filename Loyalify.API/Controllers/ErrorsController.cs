﻿using Loyalify.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    protected IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IServiceException serviceException =>
            ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError,
            "An unexpected error occurred"),
        };
        return Problem(statusCode: statusCode, title: message);
    }
}
