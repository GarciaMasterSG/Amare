using Microsoft.AspNetCore.Mvc;

namespace Amare.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string weddingnCode { get { return HttpContext.Session.GetString("UserWeddingCode"); } }
    }
}
