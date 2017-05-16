using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseManager.Domain
{
    /// <summary>
    /// 案例分析题实体类
    /// </summary>
    public class CaseAnalysis
    {
        public int CaseId { get; set; }

        public string Cases { get; set; }

        public List<MultipleChoice> Topics { get; set; }
    }
}