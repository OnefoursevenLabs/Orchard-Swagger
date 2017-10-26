using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Orchard.Swagger
{
    internal sealed class SwaggerPathContentSegment : SwaggerPathSegment
    {
        public SwaggerPathContentSegment(IList<SwaggerPathSubsegment> subsegments)
        {
            Subsegments = subsegments;
        }

        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification = "Not changing original algorithm.")]
        public bool IsCatchAll
        {
            get
            {
                // TODO: Verify this is correct. Maybe add an assert.
                return Subsegments.Any<SwaggerPathSubsegment>(seg => (seg is SwaggerPathParameterSubSegment) && ((SwaggerPathParameterSubSegment)seg).IsCatchAll);
            }
        }

        public IList<SwaggerPathSubsegment> Subsegments { get; private set; }

#if ROUTE_DEBUGGING
        public override string LiteralText
        {
            get
            {
                List<string> s = new List<string>();
                foreach (PathSubsegment subsegment in Subsegments)
                {
                    s.Add(subsegment.LiteralText);
                }
                return String.Join(String.Empty, s.ToArray());
            }
        }

        public override string ToString()
        {
            List<string> s = new List<string>();
            foreach (PathSubsegment subsegment in Subsegments)
            {
                s.Add(subsegment.ToString());
            }
            return "[ " + String.Join(", ", s.ToArray()) + " ]";
        }
#endif
    }
}