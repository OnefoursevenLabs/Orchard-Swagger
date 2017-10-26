using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    internal sealed class SwaggerPathParameterSubSegment: SwaggerPathSubsegment
    {
        public SwaggerPathParameterSubSegment(string parameterName)
        {
            if (parameterName.StartsWith("*", StringComparison.Ordinal))
            {
                ParameterName = parameterName.Substring(1);
                IsCatchAll = true;
            }
            else
            {
                ParameterName = parameterName;
            }
        }

        public bool IsCatchAll { get; private set; }

        public string ParameterName { get; private set; }

#if ROUTE_DEBUGGING
        public override string LiteralText
        {
            get
            {
                return "{" + (IsCatchAll ? "*" : String.Empty) + ParameterName + "}";
            }
        }

        public override string ToString()
        {
            return "{" + (IsCatchAll ? "*" : String.Empty) + ParameterName + "}";
        }
#endif
    }
}