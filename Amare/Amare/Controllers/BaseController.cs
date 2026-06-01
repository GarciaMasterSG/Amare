using Microsoft.AspNetCore.Mvc;

namespace Amare.Controllers
{
    public class BaseController : ControllerBase
    {
        private string? _testWeddingCode;
        public string weddingnCode { get { return _testWeddingCode ?? HttpContext.Session.GetString("UserWeddingCode"); } set { _testWeddingCode = value; } }
    }
}
