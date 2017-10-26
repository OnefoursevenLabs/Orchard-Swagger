using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace Orchard.Swagger
{
    public class SwaggerBoundRouteTemplate
    {
        public string BoundTemplate { get; set; }

        public HttpRouteValueDictionary Values { get; set; }
    }
}