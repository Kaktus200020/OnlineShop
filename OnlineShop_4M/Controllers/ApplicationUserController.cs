using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop_4M_DataAccess.Data;
using OnlineShop_4M.Models;
using OnlineShop_4M_Models;
using OnlineShop_4M_Utility;
namespace OnlineShop_4M.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext context;

        public ApplicationUserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            //List<ApplicationUser> userList= context.ApplicationUser.Where(X=>X.Id==context.Users);
            List<ApplicationUser> userList = null;



            return View(userList);
        }

        
        
    }
}
