using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Diagnostics;
using WebApp_OpenIDConnect_DotNet.Models;
using Microsoft.AspNetCore.Http;
using TodoListClient;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITokenAcquisition tokenAcquisition;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ITokenAcquisition tokenAcquisition, IHttpContextAccessor httpContextAccessor)
        {
            this.tokenAcquisition = tokenAcquisition;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {   
            string errormsg= UserValidate.ValidateUser(_httpContextAccessor);
            if (string.IsNullOrEmpty(errormsg))
            {
                return View();
            }
            else
            {
                ViewBag.ErrorMsg=errormsg;
                return View();
            }
        }

      

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}