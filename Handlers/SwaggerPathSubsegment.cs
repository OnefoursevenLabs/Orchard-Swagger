using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    internal abstract class SwaggerPathSubsegment
    {
#if ROUTE_DEBUGGING
        public abstract string LiteralText
        {
            get;
        }
#endif
    }
}