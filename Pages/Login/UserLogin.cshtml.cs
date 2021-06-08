using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using LoL1Shot.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace LoL1Shot.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public User user { get; set; }

        public UserLoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
        }
        public bool ValidateUser(User user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));
            SqlCommand cmd = new SqlCommand("sp_checkLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (user.userName == null) user.userName = "";

            cmd.Parameters.Add("@username", SqlDbType.NChar, 50).Value = user.userName;

            if (user.password == null) user.password = "";

            SqlParameter hashedpassword = new SqlParameter("@password", SqlDbType.NChar, 100);
            hashedpassword.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(hashedpassword);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            var passwordHasher = new PasswordHasher<string>();

            if (passwordHasher.VerifyHashedPassword(null, hashedpassword.Value.ToString(), user.password) 
                == PasswordVerificationResult.Success)
                return true;
            else 
                return false;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}   
            if (ValidateUser(user))
            {
                var claims = new List<Claim>()
                {
                 new Claim(ClaimTypes.Name, user.userName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                return Redirect(returnUrl);
            }
            return Page();
        }

    }
}
