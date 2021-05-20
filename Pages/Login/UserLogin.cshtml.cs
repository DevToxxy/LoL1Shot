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
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyCompanyDB"));
            SqlCommand cmd = new SqlCommand("sp_checkLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

        }





    }
}
