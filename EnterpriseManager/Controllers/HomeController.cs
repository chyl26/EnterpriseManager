using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnterpriseManager.Models;

using PagedList;

namespace EnterpriseManager.Controllers
{
    public class HomeController : Controller
    {
        ChoiceDB db = new ChoiceDB();
        /// <summary>
        /// 根据当前登陆账号匹配文档
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            const int pageSize = 20;
            //采用List传送对象
            //var doc = new List<MultipleChoice>();
            //doc = db.MultipleChoices.OrderBy(d => d.Id).ToList();
            //采用ToPagedList传送对象
            var doc = db.MultipleChoices.OrderBy(d => d.Id).ToPagedList(page, pageSize);
            return View(doc);
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleChoice choice = db.MultipleChoices.Find(id);
            if (id==null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }
        public ActionResult Testing()
        {
            return View();
        }
        public ActionResult VIP()
        {
            var doc = new List<MultipleChoice>();
            doc = db.MultipleChoices.OrderBy(d => d.Id).ToList();
            return View(doc);
        }
        /// <summary>
        /// 导入题库
        /// </summary>
        /// <returns></returns>
        public ActionResult SetTopic()
        {
            return View();
        }
    }
}