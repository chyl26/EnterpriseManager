using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EnterpriseManager.Models;

namespace EnterpriseManager.Controllers
{
    public class TestingsController : Controller
    {
        ChoiceDB db = new ChoiceDB();
        public ActionResult Index()
        {

            Session["Result"] = null;
            Session["ResultCase"] = null;
            Session["CaseAnalysises"] = null;

            return View();
        }

        public ActionResult List()
        {
            return View("List", GetNextMultipleChoice());

        }

        public ActionResult ListAnalysis()
        {
            CaseAnalysis resultCase = (CaseAnalysis)Session["ResultCase"];

            List<int> CaseIds = (List<int>)Session["CaseAnalysises"];
            if (CaseIds == null)
            {
                CaseIds = new List<int>();
            }
            MultipleChoice mc = null;
            if (resultCase != null)
            {
                mc = GetNextMultipleChoice(resultCase);
                if (mc == null)
                {
                    Session["ResultCase"] = null;
                    return ListAnalysis();
                }
                mc.CaseId = resultCase.Id;
                resultCase.Topics.Add(mc);
            }
            else
            {
                CaseAnalysis result = GetNextCaseAnalysis();

                CaseAnalysis aa = new CaseAnalysis();
                aa.Topics = new List<MultipleChoice>();
                aa.Id = result.Id;
                aa.Cases = result.Cases;
                mc = GetNextMultipleChoice(aa);

                if (CaseIds.Contains(result.Id))
                {
                    return ListAnalysis();
                }
                else
                {
                    aa.Topics.Add(mc);
                    CaseIds.Add(result.Id);
                    mc.CaseId = result.Id;
                    Session["CaseAnalysises"] = CaseIds;
                }
                resultCase = aa;
            }



            //显示分类和答题数
            List<MultipleChoice> results = (List<MultipleChoice>)Session["Result"];
            List<MultipleChoice> success = new List<MultipleChoice>();
            if (results != null)
            {
                foreach (MultipleChoice maac in results)
                {
                    if (maac.Answer == maac.Result)
                    {
                        success.Add(maac);
                    }
                }
            }
            string amount = "答题总数：" + (results != null ? results.Count : 0).ToString() + "题";
            string score = "答题总分：" + (success != null ? success.Count * 2 : 0).ToString() + "分"+"(答对一题目得2分）";
            ViewBag.amount = amount;
            ViewBag.score = score;


            //这里处理是第一是还是其它题
            if(resultCase.Topics.Count == 1)
            {
                ViewBag.First = true;
            }else
            {
                ViewBag.First = false;
            }
            
            Session["ResultCase"] = resultCase;
            CaseAnalysis resultCase1 = (CaseAnalysis)Session["ResultCase"];
            ViewBag.anli = resultCase1.Cases;
            return View("List", mc);
        }

        /// <summary>
        /// 获得下一个案例
        /// </summary>
        /// <returns></returns>
        public CaseAnalysis GetNextCaseAnalysis()
        {
            List<CaseAnalysis> andlysis = db.CaseAnalysiss.OrderBy(e => e.Cases).ToList();
            Random rm = new Random();
            CaseAnalysis ga = andlysis[rm.Next(andlysis.Count)];//随机数最大值不能超过list的总数 
            db.Entry(ga).Collection(x => x.Topics).Load();//手动读取List
            return ga;
        }

        /// <summary>
        /// 获得下一个单选
        /// </summary>
        /// <param name="multipleChoices"></param>
        /// <returns></returns>
        public MultipleChoice GetNextMultipleChoice(CaseAnalysis resultCase)
        {
            CaseAnalysis ca = db.CaseAnalysiss.Find(resultCase.Id);
            db.Entry(ca).Collection(x => x.Topics).Load();//手动读取List

            CaseAnalysis andlysis1 = db.CaseAnalysiss.Find(1);
            db.Entry(andlysis1).Collection(x => x.Topics).Load();//手动读取List

            if (resultCase.Topics.Count == ca.Topics.Count)
            {
                //判断是否答完
                List<CaseAnalysis> andlysis = db.CaseAnalysiss.OrderBy(e => e.Id).ToList();

                List<int> CaseIds = (List<int>)Session["CaseAnalysises"];
                if (CaseIds.Count >= andlysis.Count)
                {
                    MultipleChoice end = new MultipleChoice();
                    ViewBag.end = 1;
                    return end;
                }
                return null;
            }

            return ca.Topics[resultCase.Topics.Count];
            //Random rm = new Random();
            //MultipleChoice mc = ca.Topics[rm.Next(ca.Topics.Count)];//随机数最大值不能超过list的总数 

            //if (resultCase.Topics.Contains(mc))
            //{
            //    return GetNextMultipleChoice(resultCase);
            //}
            //return mc;
        }


        /// <summary>
        /// 下一个选择题
        /// </summary>
        /// <returns></returns>
        public MultipleChoice GetNextMultipleChoice()
        {
            List<MultipleChoice> result = (List<MultipleChoice>)Session["Result"];
            List<MultipleChoice> success = new List<MultipleChoice>();
            if (result != null)
            {
                foreach(MultipleChoice maac in result)
                {
                    if(maac.Answer == maac.Result)
                    {
                        success.Add(maac);
                    }
                }
            }
            string amount = "答题总数：" + (result != null ? result.Count : 0).ToString()+"题";
            string score= "答题总分：" + (success != null ? success.Count * 1 : 0).ToString()+"分";
            ViewBag.amount = amount;
            ViewBag.score = score;
            var choiceList = new List<MultipleChoice>();
            choiceList = db.MultipleChoices.OrderBy(e => e.Id).Take(400).ToList();//获取前面400条

            if (result != null && result.Count >= choiceList.Count)
            {
                MultipleChoice end = new MultipleChoice();
                ViewBag.end = 1;
                return end;
            }

            Random rm = new Random();
            MultipleChoice mc = choiceList[rm.Next(choiceList.Count)];//随机数最大值不能超过list的总数 
            //MultipleChoice mc = db.MultipleChoices.Find(rm.Next(doc.Count));
            if (isCunZai(mc))
            {
                return GetNextMultipleChoice();
            }
            return mc;
        }

        /// <summary>
        /// 判断是否有重复的选题
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        public bool isCunZai(MultipleChoice mc)
        {
            List<MultipleChoice> answer = (List<MultipleChoice>)Session["Answer"];
            if (answer == null)
            {
                answer = new List<MultipleChoice>();
                answer.Add(mc);
                Session["Answer"] = answer;
                return false;
            }
            else
            {
                foreach(MultipleChoice item in answer)
                {
                    if(item.Id == mc.Id)
                    {
                        return true;
                    }
                }
                //不存在
                answer.Add(mc);
                Session["Answer"] = answer;
                return false;
            }
            return false;
        }

        /// <summary>
        /// 提交前数据
        /// </summary>
        /// <param name="multipleChoice"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Submit(MultipleChoice multipleChoice)
        {
            List<MultipleChoice> result = (List<MultipleChoice>)Session["Result"];
            CaseAnalysis resultCase = (CaseAnalysis)Session["ResultCase"];                     
           
            if(result == null)
            {
                result = new List<MultipleChoice>();
                result.Add(multipleChoice);
                Session["Result"] = result;
            }else
            {
                result.Add(multipleChoice);
            }

            if (resultCase == null)
            {
                resultCase = new CaseAnalysis();
                resultCase.Topics = new List<MultipleChoice>();
                resultCase.Topics.Add(multipleChoice);
                Session["ResultCase"] = resultCase;
            }

           
            if(multipleChoice.CaseId != 0)
            {
                return ListAnalysis();
            }
            return List();
        }
    }
}