using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoL1Shot.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace LoL1Shot.Pages.Register
{
    public class UserRegisterModel : PageModel
    {
        public IConfiguration _configuration { get; }
        [BindProperty]
        public User newUser { get; set; }

        public UserRegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));
            SqlCommand cmd = new SqlCommand("sp_createUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = newUser.userName;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = newUser.email;
            var passwordHasher = new PasswordHasher<string>();
            newUser.password = passwordHasher.HashPassword(null, newUser.password);
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = newUser.password;

            SqlParameter userID_SqlParam = new SqlParameter("@userID", SqlDbType.Int);
            userID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(userID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToPage("/Index");
        }
    }
}
