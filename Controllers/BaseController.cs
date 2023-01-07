using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ARS_OS.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        public UserInfo UserInfo { get; set; } = new UserInfo()
        {
            
        };

        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    var user = User;
        //    var userInfo = new UserInfo();

        //    // eger role admin ise ve header'da customerid geciyorsa userInfo.Id customer'�n id(headerdagelen)'si olacak.
        //    UserInfo = userInfo;

        //    await next();
        //}
    }
}
