using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Filters
{
    public class TimeExpiriedException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is TimeoutException)
            {
                exceptionContext.Result = new RedirectResult("/Error/DbError?" + exceptionContext.Exception.Message);
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}