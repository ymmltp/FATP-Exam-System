﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class Exam
    {
        private static readonly DAL.Exam _myinfo = new DAL.Exam();
        public static ExamInfo Get_examInfo(string ExamType)
        {
            return _myinfo.Get_examInfo(ExamType);
        }
        public static List<QuestionInfo> Get_Question(string ExamType)
        {
            return _myinfo.Get_Question(ExamType);
        }
        public static void Final_Result_Check(List<QuestionInfo> qlist, out List<QuestionInfo> finalqlist, out int finalScore)
        {
            _myinfo.Final_Result_Check(qlist,out finalqlist,out finalScore);
        }
    }
}
