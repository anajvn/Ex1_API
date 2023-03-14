using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ex1_API.Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new List<string>
            {
                "Ocorreu o seguinte erro: ",
                context.Exception.Message
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
