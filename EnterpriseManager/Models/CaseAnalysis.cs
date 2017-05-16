using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EnterpriseManager.Models
{
    /// <summary>
    /// 案例分析
    /// </summary>
    public class CaseAnalysis
    {
        [Display(Name ="案例编号")]
        public int Id { get; set; }
        [Display(Name ="案例分析")]
        [DataType(DataType.MultilineText)]
        public string Cases { get; set; }
        [Display(Name = "题目")]
        public List<MultipleChoice> Topics { get; set; }
        [Display(Name = "用户")]
        public virtual User user { get; set; }
    }
}