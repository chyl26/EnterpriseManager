using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseManager.Service;

using EnterpriseManager.Models;
using EnterpriseManager.Domain;

namespace EnterpriseManager.Controllers
{
    public class AccountController : Controller
    {
        ChoiceDB db = new ChoiceDB();//创建一个访问对象
        UserService userService = new UserService();

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            Session.Clear();//清空
            return RedirectToAction("Login", "Account");
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登陆方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult login(EnterpriseManager.Models.User user)
        {
            var item = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
            if (item == null)
            {
                //Session["User"] = item;
                //return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "登陆失败");//自定义添加错误提示消息
                return View(user);
            }
            if(item.Classify<= 1)
            {
                Session["User"] = item;
                return RedirectToAction("VIP", "Home");
            }
            else
            {
                Session["User"] = item;
                return RedirectToAction("Index", "Home");
            }

        }
        /// <summary>
        /// 注册方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(EnterpriseManager.Models.User user)
        {
            //MySQL
            //user.UserId = "UserId";
            //userService.Create(user);
            //return View();

            //SQL
            if (db.Users.FirstOrDefault(u => u.UserName == user.UserName) != null)//判断注册用户是否存在
            {
                ModelState.AddModelError("", "用户已经存在");//自定义添加错误提示消息
                return View();
            }
            db.Users.Add(user);//将用户对象添加到数据库中
            db.SaveChanges();//将用户提交到数据保存
            return RedirectToAction("Login", "Account");

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
    }
}