using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class Exam
    {
        private ExamInfo _examinfo = new ExamInfo();
        private GetData gd = new GetData();

        //获取exam info
        private void ExamInfo(string ExamType) {
            DataTable dt = new DataTable();
            if (ExamType == "0")
            {
                _examinfo.ExamID = "0";
            }
            else {
                dt = gd.GetExamConfig_by_ExamType(ExamType);
                if (dt.Rows.Count > 0)
                {
                    _examinfo.ExamID = dt.Rows[0]["ExamID"].ToString();
                    _examinfo.ExamName = dt.Rows[0]["ExamName"].ToString();
                    _examinfo.SingleCount = dt.Rows[0]["SingleCount"].ToString();
                    _examinfo.SingleScore = dt.Rows[0]["EachSingleScore"].ToString();
                    _examinfo.MultipleCount = dt.Rows[0]["MultipleCount"].ToString();
                    _examinfo.MultipleScore = dt.Rows[0]["EachMultipleScore"].ToString();
                    _examinfo.TotalScore = dt.Rows[0]["TotalScore"].ToString();
                    _examinfo.PassScore = dt.Rows[0]["PassScore"].ToString();
                }
            }
        }
        public ExamInfo Get_examInfo(string ExamType)
        {
            ExamInfo(ExamType);
            ExamInfo tmp = _examinfo;
            return tmp;
        }

        //根据exam info的条件，获取exam question
        public List<QuestionInfo> Get_Question(string ExamType) {
            List<QuestionInfo> questionList = new List<QuestionInfo>();
            ExamInfo(ExamType);
            DataTable singledt = new DataTable();
            DataTable multipledt = new DataTable();
            singledt = gd.GetQuestion_Table(ExamType,"Single");  //单选题库
            multipledt = gd.GetQuestion_Table(ExamType, "Multiple");  //多选题库
            if (singledt.Rows.Count < Convert.ToInt32(_examinfo.SingleCount) || multipledt.Rows.Count < Convert.ToInt32(_examinfo.MultipleCount))
            {
                throw new Exception("Please complete the exam information");
            }
            else {
                int[] singleDB = ArrayRandom_Question(Convert.ToInt32(_examinfo.SingleCount), singledt.Rows.Count);
                int[] multipleDB = ArrayRandom_Question(Convert.ToInt32(_examinfo.MultipleCount), multipledt.Rows.Count);
                for (int i = 0; i < singleDB.Length; i++)
                {
                    QuestionInfo QInfo = new QuestionInfo();
                    int position = singleDB[i];
                    QInfo.QuestionIndex = i + 1;
                    QInfo.Question = singledt.Rows[position]["Question"].ToString();
                    QInfo.QuestionType = "Single";
                    QInfo.S1 = singledt.Rows[position]["SelectA"].ToString();
                    QInfo.S2 = singledt.Rows[position]["SelectB"].ToString();
                    QInfo.S3 = singledt.Rows[position]["SelectC"].ToString();
                    QInfo.S4 = singledt.Rows[position]["SelectD"].ToString();
                    QInfo.Answer = singledt.Rows[position]["Answer"].ToString().Split(',');
                    questionList.Add(QInfo);
                }
                for (int j = 0; j < multipleDB.Length; j++)
                {
                    QuestionInfo QInfo = new QuestionInfo();
                    int position = multipleDB[j];
                    QInfo.QuestionIndex = j + 1 + singleDB.Length;
                    QInfo.Question = multipledt.Rows[position]["Question"].ToString();
                    QInfo.QuestionType = "Multiple";
                    QInfo.S1 = multipledt.Rows[position]["SelectA"].ToString();
                    QInfo.S2 = multipledt.Rows[position]["SelectB"].ToString();
                    QInfo.S3 = multipledt.Rows[position]["SelectC"].ToString();
                    QInfo.S4 = multipledt.Rows[position]["SelectD"].ToString();
                    QInfo.Answer = multipledt.Rows[position]["Answer"].ToString().Split(',');
                    questionList.Add(QInfo);
                }
                return questionList;
            }
        }

        //从已知库中随机抽取题号
        private int[] ArrayRandom_Question(int QCount,int TotalQCunt)
        {
            Random rd = new Random();
            int[] tmp = new int[QCount];
            for (int i = 0; i < QCount; i++)
            {
                tmp[i] = rd.Next(0, TotalQCunt);
            }
            return tmp;
        }

        //判断对错+最终成绩核算
        public void Final_Result_Check(List<QuestionInfo> qlist, out List<QuestionInfo> finalqlist,out int finalScore)
        {
            List<QuestionInfo> tmp = qlist;
            for (int i = 0; i < tmp.Count; i++)
            {
                if (compareArr(tmp[i].Answer,tmp[i].UserAnswer))
                {
                    tmp[i].FinalResult = true;
                }
                else {
                    tmp[i].FinalResult = false;
                }
            }
            finalScore = Final_Score(tmp);
            finalqlist = tmp;
        }
        //比较数组是否一样
        public static bool compareArr(string[] arr1, string[] arr2)
        {
            var q = from a in arr1 join b in arr2 on a equals b select a;
            bool flag = arr1.Length == arr2.Length && q.Count() == arr1.Length;
            return flag;//内容相同返回true,反之返回false。
        }

        //最终成绩核算
        private int Final_Score(List<QuestionInfo> qlist)
        {
            List<QuestionInfo> tmp = qlist;
            int finalScore = 0;
            int singleScore = Convert.ToInt32(_examinfo.SingleScore);
            int multipleScore = Convert.ToInt32(_examinfo.MultipleScore);
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].QuestionType == "Single" && tmp[i].FinalResult)
                {
                    finalScore += singleScore;
                }
                else if (tmp[i].QuestionType == "Multiple" && tmp[i].FinalResult)
                {
                    finalScore += multipleScore;
                }
            }
            return finalScore;
        }
    }
}
