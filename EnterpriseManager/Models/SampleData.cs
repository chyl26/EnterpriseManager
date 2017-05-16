using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace EnterpriseManager.Models
{
    public class SampleData : DropCreateDatabaseAlways<ChoiceDB>
    {
        protected override void Seed(ChoiceDB context)
        {
            context.Users.Add(new User
            {
                Classify = 1,
                UserName = "admin",
                PassWord = "admin",
                Choices = new List<MultipleChoice>
                    {
                        new MultipleChoice{Topic="求明细01",OptionA="需求明细01",OptionB="需求01010101010101",OptionC="需求0101010105301",OptionD="需求010101010101001",Answer="A" },
                        new MultipleChoice{Topic="求明细02",OptionA="需求明细02",OptionB="需求01010101010102",OptionC="需求0101010105302",OptionD="需求010101010101002",Answer="B" },
                        new MultipleChoice{Topic="求明细03",OptionA="需求明细03",OptionB="需求01010101010103",OptionC="需求0101010105303",OptionD="需求010101010101003",Answer="D" },
                        new MultipleChoice{Topic="求明细04",OptionA="需求明细04",OptionB="需求01010101010104",OptionC="需求0101010105304",OptionD="需求010101010101004",Answer="C" },
                        new MultipleChoice{Topic="求明细05",OptionA="需求明细05",OptionB="需求01010101010105",OptionC="需求0101010105305",OptionD="需求010101010101005",Answer="A" },
                        new MultipleChoice{Topic="求明细06",OptionA="需求明细06",OptionB="需求01010101010106",OptionC="需求0101010105306",OptionD="需求010101010101006",Answer="C" },
                        new MultipleChoice{Topic="求明细07",OptionA="需求明细07",OptionB="需求01010101010107",OptionC="需求0101010105307",OptionD="需求010101010101007",Answer="B" },
                        new MultipleChoice{Topic="求明细08",OptionA="需求明细08",OptionB="需求01010101010108",OptionC="需求0101010105308",OptionD="需求010101010101008",Answer="C" },
                        new MultipleChoice{Topic="求明细09",OptionA="需求明细09",OptionB="需求01010101010109",OptionC="需求0101010105309",OptionD="需求010101010101009",Answer="C" },
                        new MultipleChoice{Topic="求明细10",OptionA="需求明细10",OptionB="需求01010101010110",OptionC="需求0101010105310",OptionD="需求010101010101010",Answer="D" },
                        new MultipleChoice{Topic="求明细11",OptionA="需求明细11",OptionB="需求01010101010111",OptionC="需求0101010105311",OptionD="需求010101010101011",Answer="C" },
                        new MultipleChoice{Topic="需求明细12",OptionA="需求明细12",OptionB="需求01010101010112",OptionC="需求0101010105312",OptionD="需求010101010101012",Answer="A" },
                        new MultipleChoice{Topic="需求明细13",OptionA="需求明细13",OptionB="需求01010101010113",OptionC="需求0101010105313",OptionD="需求010101010101013",Answer="D" },
                        new MultipleChoice{Topic="需求明细14",OptionA="需求明细14",OptionB="需求01010101010114",OptionC="需求0101010105314",OptionD="需求010101010101014",Answer="A" },
                        new MultipleChoice{Topic="需求明细15",OptionA="需求明细15",OptionB="需求01010101010115",OptionC="需求0101010105315",OptionD="需求010101010101015",Answer="B" },
                        new MultipleChoice{Topic="需求明细16",OptionA="需求明细16",OptionB="需求01010101010116",OptionC="需求0101010105316",OptionD="需求010101010101016",Answer="C" },
                        new MultipleChoice{Topic="需求明细17",OptionA="需求明细17",OptionB="需求01010101010117",OptionC="需求0101010105317",OptionD="需求010101010101017",Answer="C" },
                        new MultipleChoice{Topic="需求明细18",OptionA="需求明细18",OptionB="需求01010101010118",OptionC="需求0101010105318",OptionD="需求010101010101018",Answer="C" },
                        new MultipleChoice{Topic="需求明细18",OptionA="需求明细18",OptionB="需求01010101010118",OptionC="需求0101010105318",OptionD="需求010101010101018",Answer="C" },
                        new MultipleChoice{Topic="需求明细20",OptionA="需求明细20",OptionB="需求01010101010120",OptionC="需求0101010105320",OptionD="需求010101010101020",Answer="C" },
                        new MultipleChoice{Topic="需求明细21",OptionA="需求明细21",OptionB="需求01010101010121",OptionC="需求0101010105321",OptionD="需求010101010101021",Answer="C" },
                        new MultipleChoice{Topic="需求明细22",OptionA="需求明细22",OptionB="需求01010101010122",OptionC="需求0101010105322",OptionD="需求010101010101022",Answer="C" },
                        new MultipleChoice{Topic="需求明细23",OptionA="需求明细23",OptionB="需求01010101010123",OptionC="需求0101010105323",OptionD="需求010101010101023",Answer="C" },
                        new MultipleChoice{Topic="需求明细24",OptionA="需求明细24",OptionB="需求01010101010124",OptionC="需求0101010105324",OptionD="需求010101010101024",Answer="C" },
                    },
            });
            context.Users.Add(new User
            {
                Classify = 2,
                UserName = "xiaohua",
                PassWord = "xiaohua",
                //Analysis=new List<CaseAnalysis>
                //{
                //    new CaseAnalysis
                //    {
                //        Cases = "这是案例分析题目的案例1",
                //        Topics = new List<MultipleChoice>
                //        {
                //            new MultipleChoice { Topic = "ewr求明细01", OptionA = "需求明细01", OptionB = "需求01010101010101", OptionC = "需求0101010105301", OptionD = "需求010101010101001", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细02", OptionA = "需求明细02", OptionB = "需求01010101010102", OptionC = "需求0101010105302", OptionD = "需求010101010101002", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细03", OptionA = "需求明细03", OptionB = "需求01010101010103", OptionC = "需求0101010105303", OptionD = "需求010101010101003", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细04", OptionA = "需求明细04", OptionB = "需求01010101010104", OptionC = "需求0101010105304", OptionD = "需求010101010101004", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细05", OptionA = "需求明细05", OptionB = "需求01010101010105", OptionC = "需求0101010105305", OptionD = "需求010101010101005", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细06", OptionA = "需求明细06", OptionB = "需求01010101010106", OptionC = "需求0101010105306", OptionD = "需求010101010101006", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细07", OptionA = "需求明细07", OptionB = "需求01010101010107", OptionC = "需求0101010105307", OptionD = "需求010101010101007", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细08", OptionA = "需求明细08", OptionB = "需求01010101010108", OptionC = "需求0101010105308", OptionD = "需求010101010101008", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细09", OptionA = "需求明细09", OptionB = "需求01010101010109", OptionC = "需求0101010105309", OptionD = "需求010101010101009", Answer = "A" },
                //            new MultipleChoice { Topic = "ewr求明细10", OptionA = "需求明细10", OptionB = "需求01010101010110", OptionC = "需求0101010105310", OptionD = "需求010101010101010", Answer = "A" },
                //        },
                //    }
                //}
            });

            //context.CaseAnalysis.Add(new CaseAnalysis
            //{
            //    Cases = "这是案例分析题目的案例1",
            //    Topics = new List<MultipleChoice>
            //    {
            //        new MultipleChoice { Topic = "ewr求明细01", OptionA = "需求明细01", OptionB = "需求01010101010101", OptionC = "需求0101010105301", OptionD = "需求010101010101001", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细02", OptionA = "需求明细02", OptionB = "需求01010101010102", OptionC = "需求0101010105302", OptionD = "需求010101010101002", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细03", OptionA = "需求明细03", OptionB = "需求01010101010103", OptionC = "需求0101010105303", OptionD = "需求010101010101003", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细04", OptionA = "需求明细04", OptionB = "需求01010101010104", OptionC = "需求0101010105304", OptionD = "需求010101010101004", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细05", OptionA = "需求明细05", OptionB = "需求01010101010105", OptionC = "需求0101010105305", OptionD = "需求010101010101005", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细06", OptionA = "需求明细06", OptionB = "需求01010101010106", OptionC = "需求0101010105306", OptionD = "需求010101010101006", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细07", OptionA = "需求明细07", OptionB = "需求01010101010107", OptionC = "需求0101010105307", OptionD = "需求010101010101007", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细08", OptionA = "需求明细08", OptionB = "需求01010101010108", OptionC = "需求0101010105308", OptionD = "需求010101010101008", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细09", OptionA = "需求明细09", OptionB = "需求01010101010109", OptionC = "需求0101010105309", OptionD = "需求010101010101009", Answer = "A" },
            //        new MultipleChoice { Topic = "ewr求明细10", OptionA = "需求明细10", OptionB = "需求01010101010110", OptionC = "需求0101010105310", OptionD = "需求010101010101010", Answer = "A" },
            //    },
            //});
            base.Seed(context);
        }
    }
}