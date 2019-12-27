using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExamInfo
    {
        public string ExamID { get; set; }
        public string ExamName { get; set; }
        public string SingleCount { get; set; }
        public string SingleScore { get; set; }
        public string MultipleCount { get; set; }
        public string MultipleScore { get; set; }
        public string TotalScore { get; set; }
        public string PassScore { get; set; }
    }
}
