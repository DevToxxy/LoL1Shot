using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
         public override void OnResultExecuting(ResultExecutingContext context)
         {
            var result = context.Result;
            if (result is PageResult)
                {
                    var page = ((PageResult)result);
                    page.ViewData["Creators"] = "Jakub A. & Arkadiusz P.";
            }
        }
        }
  
}
