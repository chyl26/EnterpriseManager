using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseManager.Domain
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {
        public string UserId { get; set; }

        public string ClassifyId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    
    }
}