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
        public static string Color = "";
        public static string ClientCode = "";

        public static string ValidateUser(IHttpContextAccessor _httpContextAccessor)
        {
            //check user roles
            string userroles = _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_userRoles");
            string errormsg = "User does not belong to any role. Please try logout and login. If the problem still persist, please contact your Administrator";
            if (userroles == null || string.IsNullOrWhiteSpace(userroles))
            {
                return errormsg;
            }
            string[] uroles = userroles.Split(',');
            if (!uroles.Contains("basic"))
            {
                return errormsg;
            }

            //check tax id
            string taxId = _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_TaxId");
            errormsg = "User does not have tax id. Please contact your Administrator.";
            if (taxId == null || string.IsNullOrWhiteSpace(taxId))
            {
                return errormsg;
            }

            //check tax id
             ClientCode= _httpContextAccessor.HttpContext?.User.FindFirstValue("extension_ClientCode");
            errormsg = "User does not have client code. Please contact your Administrator.";

            if (ClientCode == null || string.IsNullOrWhiteSpace(ClientCode))
            {
                return errormsg;
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
