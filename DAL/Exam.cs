﻿using System;
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
                try
                {
                    int[] multipleDB = ArrayRandom_Question(Convert.ToInt32(_examinfo.MultipleCount), 0, multipledt.Rows.Count-1);
                    int[] singleDB = ArrayRandom_Question(Convert.ToInt32(_examinfo.SingleCount), 0, singledt.Rows.Count-1);
                    for (int i = 0; i < singleDB.Length; i++)
                    {
                        QuestionInfo QInfo = new QuestionInfo();
                        int position = singleDB[i];
                        QInfo.QuestionIndex = i+1;
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
                catch (Exception e)
                {
                    string a = e.Message;
                    throw new Exception(e.Message);
                }
            }
        }

        //从已知库中随机抽取题号
        public static int[] ArrayRandom_Question(int count,int min, int max)
        {
            try {
                //生成有序数list
                List<int> originList = new List<int>();
                int listcount = max - min + 1;
                for (int i = 0; i < listcount; i++)
                {
                    originList.Add(i + min);
                }
                //生成随机数list
                List<int> callback = new List<int>();
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    int place = random.Next(0, listcount - i);
                    callback.Add(originList[place]);
                    originList.Remove(originList[place]);
                }
                return callback.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
            //private int[] ArrayRandom_Question(int QCount,int MinIndex,int MaxIndex)
            //{
            //    Random rd = new Random();
            //    int[] tmp = new int[QCount];
            //    try
            //    {
            //        for (int i = 0; i < QCount; i++)
            //        {
            //            int currentRandom = rd.Next(MinIndex, MaxIndex);
            //            bool flag = false; // 没有重复
            //            foreach (int figure in tmp)
            //            {
            //                if (figure == currentRandom)
            //                {
            //                    flag = true;
            //                    break;
            //                }
            //            }
            //            if (flag)
            //                i = i - 1;
            //            else
            //                tmp[i] = currentRandom;
            //        }
            //        return tmp;
            //    }
            //    catch (Exception e)
            //    {
            //        throw new Exception(e.Message);
            //    }

            //}
        }
}
