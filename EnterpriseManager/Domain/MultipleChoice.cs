using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseManager.Domain
{
    /// <summary>
    /// 单项选择题实体类
    /// </summary>
    public class MultipleChoice
    {
        public string ChoiceId { get; set; }

        public string Topic { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string Answer { get; set; }

        public int Score { get; set; }

        public string Result { get; set; }
    }
}