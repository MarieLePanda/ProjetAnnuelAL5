using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApplication7
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NullResponseIs404Attribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if ((actionExecutedContext.Response == null) || !actionExecutedContext.Response.IsSuccessStatusCode)
                return;

            object contentValue;
            actionExecutedContext.Response.TryGetContentValue<object>(out contentValue);
            if (contentValue == null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Object not found");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SaveAfterAttribute: ActionFilterAttribute
    {
        private readonly DbContext context;
        public SaveAfterAttribute(DbContext context)
        {
            this.context = context;
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

            this.context.SaveChanges();
        }
    }
}