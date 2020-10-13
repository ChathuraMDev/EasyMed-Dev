using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using AuthServices.Providers;
using Domain.ViewModels;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web.Http.Cors;

namespace AuthServices.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        /* DB Controll */
        private readonly IDbConnection idbCon;

        private const string LocalLoginProvider = "Local";

        public AccountController()
        {
            idbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EasyMedDBConnection"].ConnectionString);
        }
                
        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }
        
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserDataViewModel model)
        {
            try
            {
                int lastUserId = idbCon.Query<int>("spCreateUser", new
                {
                    txtUserName = (model.txtUserName == null) ? null  :model.txtUserName,
                    txtPassword = (model.txtPassword == null) ? null : model.txtPassword,
                    chrRole = (model.chrRole == null) ? null : model.chrRole,
                    txtFName = (model.txtFName == null) ? null : model.txtFName,
                    txtMName = (model.txtMName == null) ? null : model.txtMName,
                    txtLName = (model.txtLName == null) ? null : model.txtLName,
                    txtTitle = (model.txtTitle == null) ? null : model.txtTitle,
                    txtContactNo = (model.txtContactNo == null) ? null : model.txtContactNo,
                    txtEmail = (model.txtEmail == null) ? null : model.txtEmail,
                    txtFax = (model.txtFax == null) ? null : model.txtFax,
                    txtAddress1 = (model.txtAddress1 == null) ? null : model.txtAddress1,
                    txtAddress2 = (model.txtAddress2 == null) ? null : model.txtAddress2,
                    txtAddress3 = (model.txtAddress3 == null) ? null : model.txtAddress3,
                    txtQualification = (model.txtQualification == null) ? null : model.txtQualification
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch 
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [Route("ReadUser")]
        [HttpPost]
        public UserDataViewModel ReadUser(UserDataViewModel user)
        {
            UserDataViewModel uData = idbCon.Query<UserDataViewModel>("spGetUserData", new { txtUserName = user.txtUserName }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return uData;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

    }
}
