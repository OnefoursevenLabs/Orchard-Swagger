using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    internal sealed class SwaggerPathSeparatorSegment : SwaggerPathSegment
    {
#if ROUTE_DEBUGGING
        public override string LiteralText
        {
            get
            {
                return "/";
            }
        }

        public override string ToString()
        {
            return "\"/\"";
        }
#endif
    }
}