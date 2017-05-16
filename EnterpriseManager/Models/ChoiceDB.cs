using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace EnterpriseManager.Models
{
    public class ChoiceDB : DbContext
    {
        public DbSet<CaseAnalysis> CaseAnalysiss { get; set; }
        public DbSet<MultipleChoice> MultipleChoices { get; set; }
        public DbSet<User> Users { get; set; }
    }
}