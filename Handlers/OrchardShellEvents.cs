using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using Orchard.Environment;
using Orchard.Mvc.Routes;
using Orchard.WebApi.Routes;
//using OrchardSwagger.Application;
using System.Web.Mvc;
using Orchard.Swagger.Controlles;
using System.Web.Http.Dispatcher;
using Orchard.WebApi;

namespace Orchard.Swagger.Handlers {
    public class OrchardShellEvents : IOrchardShellEvents {
        private readonly IEnumerable<IHttpRouteProvider> _httpRouteProviders;

        public OrchardShellEvents(IEnumerable<IHttpRouteProvider> httpRouteProviders) {
            _httpRouteProviders = httpRouteProviders;
        }

        public void Activated() {
            ReloadApiExlorer();
        }

        public void Terminating() {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IApiExplorer),
                new CustomApiExplorer(new HttpConfiguration()));
        }

        private void ReloadApiExlorer()
        {
            var config = new HttpConfiguration();
            var allRoutes = new List<RouteDescriptor>();
            allRoutes.AddRange(_httpRouteProviders.SelectMany(provider => provider.GetRoutes()));
            foreach (var routeDescriptor in allRoutes)
            {
                // extract the WebApi route implementation
                var httpRouteDescriptor = routeDescriptor as HttpRouteDescriptor;

                if (httpRouteDescriptor != null)
                {
                    if (string.IsNullOrEmpty(httpRouteDescriptor.Name))
                    {
                        // todo: decide what to do with this guy
                        var area = httpRouteDescriptor.RouteTemplate.Substring(4,
                            httpRouteDescriptor.RouteTemplate.Length - 18 - 4);
                       httpRouteDescriptor.Name = $"Default{area}";
                    }
                    else
                    {
                       // var area = httpRouteDescriptor.RouteTemplate.Substring(4,
                       //        httpRouteDescriptor.RouteTemplate.Length - 18 - 4);
                       //httpRouteDescriptor.RouteTemplate= httpRouteDescriptor.RouteTemplate.Replace("{controller}","{action}").Replace(area, "{cotroller}");
                       // httpRouteDescriptor.Defaults = new { controller = area, action = "api", id = UrlParameter.Optional};
                        config.Routes.MapHttpRoute(httpRouteDescriptor.Name,
                            httpRouteDescriptor.RouteTemplate,
                            httpRouteDescriptor.Defaults, httpRouteDescriptor.Constraints);
                    }
                }
            }
            GlobalConfiguration.Configuration.Services.Replace(typeof(IApiExplorer), new CustomApiExplorer(config));
        }
    }
   

}