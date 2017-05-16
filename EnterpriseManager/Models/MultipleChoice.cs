using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace EnterpriseManager.Models
{
    /// <summary>
    /// 单项选择题
    /// </summary>
    public class MultipleChoice
    {
        [Display(Name = "题目编号")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="题目")]
        public string Topic { get; set; }
        [Required]
        [Display(Name ="A选项")]
        public string OptionA { get; set; }
        [Required]
        [Display(Name = "B选项")]
        public string OptionB { get; set; }
        [Required]
        [Display(Name = "C选项")]
        public string OptionC { get; set; }
        [Required]
        [Display(Name = "D选项")]
        public string OptionD { get; set; }
        [Required]
        [Display(Name = "答案")]
        public string Answer { get; set; }
        [Display(Name ="成绩")]
        public int Score { get; set; }
        
        public int CaseId { get; set; }//案例Id
        public string Result { get; set; }

        [Display(Name ="测试次数")]
        public int Amount { get; set; }
        [Display(Name = "用户编号")]
        public int UserId { get; set; }
        [Display(Name = "用户")]
        public virtual User user { get; set; }//virtual表示关键字，可以通过.方式直接调用
    }
}