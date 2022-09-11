namespace APIAuthentication.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web.Http;
    using VHaaSh.API.BLL.Account;
    using VHaaShAPIModals;
    using VHaaShAPIModals.Account;

    public class LoginController : ApiController
    {
        private IAccountControllerBL _accountBL;

        public LoginController(IAccountControllerBL accountBL)
        {
            _accountBL = accountBL;
        }

        [HttpPost]
        public HttpResponseMessage Authenticate([FromBody] LoginRequest login)
        {            
            User user = _accountBL.Authenticate(login.Username, login.Password);

            if (user.IsAuthenticated == 1 && user.AccountLocked == 0)
            {
                string token = createToken(login.Username);

                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private string createToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(10);
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)                
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            var token = (JwtSecurityToken)
        tokenHandler.CreateJwtSecurityToken(issuer: GlobalConstants.JwtTokenIssuer, audience: GlobalConstants.JwtTokenIssuer,
            subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }        
    }
}
