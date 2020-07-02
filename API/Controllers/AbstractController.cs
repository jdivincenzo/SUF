using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Controllers
{
    public abstract class AbstractController<T>: ControllerBase
    {
        private readonly ILogger<T> _logger;

        public AbstractController(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected void LogRequest(HttpRequest request, string guid, params object[] args)
        {
            //TODO: Async + Log request parameters + performance + file persist + buffer
            string log = String.Format(@"[{0}] - {1}://{2}{3} - [{4}] - #{5}# -> ", this.GetType(), request.Scheme, request.Host, request.Path, request.Method, guid.ToString());
            foreach (object o in args)
            {
                if (o.GetType() == typeof(Object[]))
                    foreach (object it in (object[])o) log = log + "(" + it.ToString() + ") ";
                else
                    log = log + "(" + o.ToString() +") ";
            }
            _logger.LogInformation(log);
        }

        protected void LogResponse(string response, string guid)
        {
            string log = String.Format(@"[{0}] - {1} - #{2}# -> ", this.GetType(), response, guid.ToString());
            _logger.LogInformation(log);
        }
    }
}

