using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using FoodOrderingWebService.Repository;

namespace FoodOrderingWebService.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string ErrorMessage = string.Empty;
        protected IFoodOrderService _FoodOrderingService { get; set; }
     

    }
}