using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Api.Core;
using qy = Api.Weixin.Qy;

namespace Api.Weixin.Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string corpId = "", corpSecret = "";

            // 如何使用
            var access_token = qy.TokenManager.Instance().
                 GetAccessToken(corpId, corpSecret);

            qy.ApiHelper.Instance().CreateUser(access_token, new Qy.CreateUserRequest
            {
                email = "",

            });
            return View();
        }
    }
}