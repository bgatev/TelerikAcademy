namespace App.WebAPI.Controllers
{
    using App.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public abstract class BaseApiController : ApiController
    {
        protected IAppData data;

        protected BaseApiController(IAppData data)
        {
            this.data = data;
        }
    }
}