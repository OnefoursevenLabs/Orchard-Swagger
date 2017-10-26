using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;

namespace Orchard.Swagger
{
    public class SwaggerApiDescription:ApiDescription
    {
        /// <summary>
        /// Initializes a  instance of the <see cref="ApiDescription"/> class.
        /// </summary>
        public SwaggerApiDescription()
        {
            SupportedRequestBodyFormatters = new Collection<MediaTypeFormatter>();
            SupportedResponseFormatters = new Collection<MediaTypeFormatter>();
            ParameterDescriptions = new Collection<ApiParameterDescription>();
        }

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        /// <value>
        /// The HTTP method.
        /// </value>
        public  HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the relative path.
        /// </summary>
        /// <value>
        /// The relative path.
        /// </value>
        public  string RelativePath { get; set; }

        /// <summary>
        /// Gets or sets the action descriptor that will handle the API.
        /// </summary>
        /// <value>
        /// The action descriptor.
        /// </value>
        public  HttpActionDescriptor ActionDescriptor { get; set; }

        /// <summary>
        /// Gets or sets the registered route for the API.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public  IHttpRoute Route { get; set; }

        /// <summary>
        /// Gets or sets the documentation of the API.
        /// </summary>
        /// <value>
        /// The documentation.
        /// </value>
        public  string Documentation { get; set; }

        /// <summary>
        /// Gets the supported response formatters.
        /// </summary>
        public  Collection<MediaTypeFormatter> SupportedResponseFormatters { get;set; }

        /// <summary>
        /// Gets the supported request body formatters.
        /// </summary>
        public  Collection<MediaTypeFormatter> SupportedRequestBodyFormatters { get;set; }

        /// <summary>
        /// Gets the parameter descriptions.
        /// </summary>
        public  Collection<ApiParameterDescription> ParameterDescriptions { get;set; }

        /// <summary>
        /// Gets the ID. The ID is unique within <see cref="HttpServer"/>.
        /// </summary>
        public  string ID
        {
            get
            {
                return (HttpMethod != null ? HttpMethod.Method : String.Empty) +
                    (RelativePath ?? String.Empty);
            }
        }
    }
}