﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class GetData
    {
        private static readonly DAL.GetData _myinfo = new DAL.GetData();

        #region Project(select insert delete)
        public static DataTable GetProject_Table(string project=null)
        {
            return _myinfo.GetProject_Table(project);
        }
        public static string Add_Project(string project)
        {
            return _myinfo.Add_Project(project);
        }
        public static string Delete_Project(string project)
        {
            return _myinfo.Delete_Project(project);
        }
        #endregion

        #region Department(select insert delete)
        public static DataTable GetDepartment_Table(string department=null)
        {
            return _myinfo.GetDepartment_Table(department);
        }
        public static string Add_Department(string department)
        {
            return _myinfo.Add_Department(department);
        }
        public static string Delete_Departemnt(string department)
        {
            return _myinfo.Delete_Departemnt(department);
        }
        #endregion

        #region poweruser(select insert delete)
        public static DataTable GetPoweruser_Table()
        {
            return _myinfo.GetPoweruser_Table();
        }
        public static string Add_Poweruser(string NTID, string project, string department)
        {
            return _myinfo.Add_Poweruser(NTID, project, department);   
        }
        public static string Delete_Poweruser(string NTID)
        {
            return _myinfo.Delete_Poweruser(NTID);
        }
        #endregion

        #region ExamConfig(select insert update delete)
        public static DataTable GetExamConfig_Table(string examName=null)
        {
            return _myinfo.GetExamConfig_Table(examName);
        }
        public static DataTable GetExamConfig_by_ExamType(string examType)
        {
            return _myinfo.GetExamConfig_by_ExamType(examType);
        }
        public static string Add_Exam(string examname, string totalscore, string passscore, string singlecount, string singlescore, string multiplecount, string multiplescore,string ntid=null,string project=null,string department=null)
        {
            return _myinfo.Add_Exam(examname, totalscore, passscore, singlecount, singlescore, multiplecount, multiplescore, ntid, project, department);
        }
        public static string Update_Exam(string ExamID, string examname, string totalscore, string passscore, string singlecount, string singlescore, string multiplecount, string multiplescore)
        {
            return _myinfo.Update_Exam(ExamID, examname, totalscore, passscore, singlecount, singlescore, multiplecount, multiplescore);
        }
        public static string Delete_Exam(string ExamID)
        {
            return _myinfo.Delete_Exam(ExamID);
        }
        #endregion

        #region userlist(select insert update delete)
        public static DataTable GetUser_Table(string ExamType, string Project, string Department, string NTID=null)
        {
            return _myinfo.GetUser_Table(ExamType, Project, Department, NTID);
        }
        public static string Batch_Upload_User(DataTable dt)
        {
            return _myinfo.Batch_Upload_User(dt);
        }
        public static string Add_User(string examType, string NTID, string Project, string Department, string UserLevel)
        {
            return _myinfo.Add_User(examType, NTID, Project, Department, UserLevel);
        }
        public static string Update_User(string ID, string examType, string NTID, string Project, string Department, string UserLevel)
        {
            return _myinfo.Update_User(ID, examType, NTID, Project, Department, UserLevel);
        }
        public static string Delete_User(string ID)
        {
            return _myinfo.Delete_User(ID);
        }
        #endregion

        #region questionlist(select insert update delete)
        public static DataTable GetQuestion_Table(string ExamType=null, string QuestionType=null)
        {
            return _myinfo.GetQuestion_Table(ExamType, QuestionType);
        }
        public static string Batch_Upload_Question(DataTable dt)
        {
            return _myinfo.Batch_Upload_Question(dt);
        }
        public static string Add_Question(string ExamType, string question, string questionType, string s1, string s2,string answer, string s3=null, string s4=null)
        {
            return _myinfo.Add_Question(ExamType, question, questionType, s1, s2,answer, s3, s4);
        }
        public static string Update_Question(string ID, string ExamType, string question, string questionType, string s1, string s2,string answer, string s3 = null, string s4 = null)
        {
            return _myinfo.Update_Question(ID, ExamType, question, questionType, s1, s2, answer, s3, s4);
        }
        public static string Delete_Question(string ID)
        {
            return _myinfo.Delete_Question(ID);
        }
        #endregion

        #region examscore (select replace delete)
        public static DataTable GetExamScore_Table(string examtype, string project, string department, string NTID)
        {
            return _myinfo.GetExamScore_Table(examtype, project, department, NTID);
        }
        public static string Replace_ExamScore(string ExamType, string NTID, string Score)
        {
            return _myinfo.Replace_ExamScore(ExamType, NTID, Score);
        }
        public static string Delete_ExamScore(string ExamType, string NTID)
        {
            return _myinfo.Delete_ExamScore(ExamType, NTID);
        }

        public static string Insert_ExamScore(string ExamType, string NTID, string UserName, string Score) {
            return _myinfo.Insert_ExamScore(ExamType, NTID, UserName, Score);
        }
        #endregion
    }
}
