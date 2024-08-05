using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Diagnostics;
using WebApp_OpenIDConnect_DotNet.Models;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using TodoListClient;
namespace TodoListClient
{
    public class UserValidate
    {
        public string Color { get; set; }
        public string ClientCode { get; set; }
        IHttpContextAccessor _httpContextAccessor;

        public UserValidate(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ValidateUser()
        {
            //check user roles
            string userroles = _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_userRoles");
            string errormsg=string.Empty;

            if (userroles == null || string.IsNullOrWhiteSpace(userroles))
            {
                errormsg = "User does not belong to any role. Please try logout and login. If the problem still persist, please contact your Administrator";
            }
            string[] uroles = userroles.Split(',');
            if (!uroles.Contains("basic"))
            {
                errormsg = "User does not belong to 'basic' role. Please try logout and login. If the problem still persist, please contact your Administrator";
            }

            //check tax id
            string taxId = _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_TaxId");           
            if (taxId == null || string.IsNullOrWhiteSpace(taxId))
            {
                errormsg = "User does not have tax id. Please contact your Administrator.";
            }

            //check tax id
             ClientCode= _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_ClientCode");
            if (ClientCode == null || string.IsNullOrWhiteSpace(ClientCode))
            {
                errormsg = "User does not have client code. Please contact your Administrator."; 
            }

            switch (ClientCode)
            {
                case "CareOregon":
                    Color = "bg-success text-white";
                    
                    break;
                case "Encora":
                    Color = "bg-primary text-white";
                    break;
            }
            
            return string.Empty;
        }
    }
}
