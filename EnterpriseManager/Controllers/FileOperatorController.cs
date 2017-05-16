using System;
using System.Collections.Generic;

using System.IO;
using System.Text;
using System.Collections;
using System.Web.Mvc;
using EnterpriseManager.Models;

namespace EnterpriseManager.Controllers
{
    public class FileOperatorController : Controller
    {
        ChoiceDB db = new ChoiceDB();
        MultipleChoice chioice = new MultipleChoice();
        CaseAnalysis andlysis = new CaseAnalysis();

        public ActionResult Index()
        {
            
            return View();
        }


        /// <summary>
        /// 题目
        /// </summary>
        public ActionResult DBChioce()
        {
            IList<TestItem> chioce = new List<TestItem>();
            FileStream fs = new FileStream(@"D:\choice.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //读取文本内容存List
            while (sr.Peek() != -1)
            {
                TestItem t = ReadOne(sr);
                chioce.Add(t);
            }
            //保存数据
            foreach (TestItem item in chioce)
            {

                chioice.Topic = item.Title;
                chioice.Answer = item.result;
                chioice.OptionA = item.answer[0];
                chioice.OptionB = item.answer[1];
                chioice.OptionC = item.answer[2];
                chioice.OptionD = item.answer[3];
                chioice.UserId = 1;
                chioice.CaseId = 0;
                db.MultipleChoices.Add(chioice);
                db.SaveChanges();
            }

            sr.Close();
            return RedirectToAction("Index", "Home");


        }
        #region 读案例
        /// <summary>
        /// 读案例
        /// </summary>
        public ActionResult DBAndlysis()
        {
            IList<TestItems> chioce = new List<TestItems>();
            FileStream fs = new FileStream(@"D:\Analysis.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //读取文本内容存List
            while (sr.Peek() != -1)
            {
                TestItems t = ReadOnes(sr);
                chioce.Add(t);
            }
            //保存数据
            foreach (TestItems item in chioce)
            {
                andlysis.Cases = item.cases;
                andlysis.Topics = new List<MultipleChoice>();
                foreach (TestItem items in item.testItems)
                {
                    MultipleChoice chioice = new MultipleChoice();
                    chioice.Topic = items.Title;
                    chioice.Answer = items.result;
                    chioice.OptionA = items.answer[0];
                    chioice.OptionB = items.answer[1];
                    chioice.OptionC = items.answer[2];
                    chioice.OptionD = items.answer[3];
                    chioice.UserId = 1;
                    andlysis.Topics.Add(chioice);
                }

                db.CaseAnalysiss.Add(andlysis);
                db.SaveChanges();
            }

            sr.Close();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region 读一个案例
        /// <summary>
        /// 读一个案例
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public TestItems ReadOnes(StreamReader sr)
        {
            TestItems t = new TestItems();
            t.cases = ReadCases(sr);
            IList<TestItem> answer = new List<TestItem>();
            for (int i = 0; i < 5; i++)
            {
                TestItem ti = ReadOne(sr);
                answer.Add(ti);
            }
            t.testItems = answer;
            return t;
        }
        #endregion

        public string ReadCases(StreamReader sr)
        {
            StringBuilder result = new StringBuilder();
            string line = null;
            while ((line = sr.ReadLine()) != "NewLine")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        /// <summary>
        /// 单题
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public TestItem ReadOne(StreamReader sr)
        {
            TestItem t = new TestItem();
            t.Title = sr.ReadLine();
            IList<string> answer = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                string answeritem = sr.ReadLine();
                answer.Add(answeritem);
            }
            t.answer = answer;
            t.result = sr.ReadLine();
            return t;
        }
    }

    public class TestItem
    {
        public string Title { get; set; }
        public IList<string> answer { get; set; }
        public string result { get; set; }
    }

    public class TestItems
    {
        public string cases { get; set; }
        public IList<TestItem> testItems { get; set; }
    }








}
