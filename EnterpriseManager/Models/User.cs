using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnterpriseManager.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "用户分类")]
        public int Classify { get; set; }
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="密  码")]
        public string PassWord { get; set; }
        [Display(Name = "单项选择题")]
        public virtual List<MultipleChoice> Choices { get; set; }

        public virtual List<CaseAnalysis> Analysis { get; set; }
    }
}