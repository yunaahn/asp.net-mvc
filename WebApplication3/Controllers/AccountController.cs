using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DataContext;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// login
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //id ps - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq 쿼리식 - method chaining
                    // => A go to B
                    //var user = db.Users.
                    //FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);

                    var user = db.Users
                            .FirstOrDefault(u => u.UserId.Equals(model.UserId) && 
                                            u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        //성공

                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                        
                    }
                    
                        //로그인 실패
                        ModelState.AddModelError(string.Empty, "사용자 아이디 혹은 비밀번호가 올바르지 않습니다");
                    
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                //Java try (){} catch(){}
                //C#
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges(); //실제 sql 저장하는 명령
                }
                return RedirectToAction("index", "Home");
            }
            return View(model);
        }
    }
}