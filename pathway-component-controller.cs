using Sabio.Models.Domain;
using Sabio.Models.Requests;
using Sabio.Models.Responses;
using Sabio.Services;
using Sabio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers
{
    [RoutePrefix("Pathway")]
    public class PathwayController : ApiController
    {
        readonly IPathwayServices pathwayServices;
        readonly IAuthenticationService authenticationService;

        public PathwayController(IPathwayServices pathwayServices, IAuthenticationService authenticationService)
        {
            this.pathwayServices = pathwayServices;
            this.authenticationService = authenticationService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllPathways ()
        {
            ItemsResponse<PathwayOnlyIdAndName> response = new ItemsResponse<PathwayOnlyIdAndName>();
            response.Items = pathwayServices.SelectOnlyIdAndName();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
