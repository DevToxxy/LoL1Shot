using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace net10.Utils
{
    public class CustomPageFilter : IPageFilter
    {
        public CustomPageFilter(IConfiguration _config)
        {
        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {
        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext pageContext)
        {

        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            var page = ((PageResult)pageContext.Result);
            page.ViewData["Creators"] = "Jakub A. & Arkadiusz P.";

        }
    }
}

