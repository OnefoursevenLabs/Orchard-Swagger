using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    public abstract class SwaggerPathSegment
    {
#if ROUTE_DEBUGGING
        public abstract string LiteralText
        {
            get;
        }
#endif
    }
}