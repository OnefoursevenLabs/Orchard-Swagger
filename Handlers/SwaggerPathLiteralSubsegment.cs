using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    internal sealed class SwaggerPathLiteralSubsegment : SwaggerPathSubsegment
    {
        public SwaggerPathLiteralSubsegment(string literal)
        {
            Literal = literal;
        }

        public string Literal { get; private set; }

#if ROUTE_DEBUGGING
        public override string LiteralText
        {
            get
            {
                return Literal;
            }
        }

        public override string ToString()
        {
            return "\"" + Literal + "\"";
        }
#endif
    }
}