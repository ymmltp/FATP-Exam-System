﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class GetData
    {
        private ManageDatabase sp = new ManageDatabase();
        #region Project(select insert delete)
        public DataTable GetProject_Table()
        {
            string sql = "SELECT (@i:= @i + 1) AS IndexID,Project FROM project,(SELECT @i:= 0) as A WHERE 1 ORDER by Project";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_Project(string project)
        {
            string mesg = "Add Project success!";
            string sql = "INSERT into project(Project) VALUES ('" + project + "')";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add Project fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_Project(string project)
        {
            string mesg = "Delete Project success!";
            string sql = "DELETE FROM project WHERE project='" + project + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete Project fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region Department(select insert delete)
        public DataTable GetDepartment_Table()
        {
            string sql = "SELECT (@i:= @i + 1) AS IndexID,Department FROM department,(SELECT @i:= 0) as A WHERE 1 ORDER by Department";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_Department(string department)
        {
            string mesg = "Add Department success!";
            string sql = "INSERT into department(Department) VALUES ('" + department + "')";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add Departemnt fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_Departemnt(string department)
        {
            string mesg = "Delete Department success!";
            string sql = "DELETE FROM department WHERE Department='" + department + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete Department fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region poweruser(select insert delete)
        public DataTable GetPoweruser_Table()
        {
            string sql = "SELECT (@i:= @i + 1) AS IndexID,B.* FROM poweruser B,(SELECT @i:= 0) as A WHERE 1";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_Poweruser(string NTID, string project, string department)
        {
            string mesg = "Add PowerUser success!";
            string sql = "INSERT into poweruser(NTID,Project,Department) VALUES ('" + NTID + "','" + project + "','" + department + "')";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add PowerUser fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_Poweruser(string NTID)
        {
            string mesg = "Delete PowerUser success!";
            string sql = "DELETE FROM poweruser WHERE NTID='" + NTID + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete PowerUser fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region ExamConfig(select insert update delete)
        public DataTable GetExamConfig_Table(string examName) {
            string sql = "SELECT (@i:= @i + 1) AS IndexID,B.* FROM examconfig B,(SELECT @i:= 0) as A WHERE 1 ";
            if (!string.IsNullOrEmpty(examName))
            {
                sql += " and ExamName='" + examName + "'";
            }
            sql += " ORDER by ExamID";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_Exam(string examname,string totalscore,string passscore,string singlecount,string singlescore,string miltiplecount,string miltiplescore)
        {
            string mesg = "Add Exam success!";
            string sql = "INSERT into examconfig (ExamName,TotalScore,PassScore,SingleCount,EachSingleScore,MiltipleCount,EachMiltipleScore) VALUES('" + examname + "','" + totalscore + "','" + passscore + "','" + singlecount + "','" + singlescore + "','" + miltiplecount + "','" + miltiplescore + "' )";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add Exam fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Update_Exam(string ExamID, string examname, string totalscore, string passscore, string singlecount, string singlescore, string miltiplecount, string miltiplescore)
        {
            string mesg = "Update Exam success!";
            string sql = "UPDATE examconfig SET ExamName='" + examname + "',TotalScore='" + totalscore + "',PassScore='" + passscore + "',SingleCount='" + singlecount + "',EachSingleScore='" + singlescore + "',MiltipleCount='" + miltiplecount + "',EachMiltipleScore='" + miltiplescore + "' WHERE examID='" + ExamID + "'";
            try
            {
                sp.Update(sql);
            }
            catch (Exception e)
            {
                mesg = "Update Exam fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_Exam(string ExamID)
        {
            string mesg = "Delete Exam success!";
            string sql = "DELETE FROM examconfig WHERE ExamID='" + ExamID + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete Exam fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region userlist(select insert update delete)
        public DataTable GetUser_Table(string ExamType,string Project,string Department, string NTID)
        {
            string sql = @"SELECT (@i:=@i+1) AS IndexID, D.* FROM 
                        (SELECT C.ExamName as ExamType,B.ID,B.NTID, B.Department, B.Project, B.UserLevel FROM userlist B INNER JOIN examconfig C on B.ExamType = C.ExamID WHERE 1 ";
            if (!string.IsNullOrEmpty(ExamType))
            {
                sql += " AND B.ExamType='" + ExamType + "'";
            }
            if (!string.IsNullOrEmpty(NTID))
            {
                sql += " AND B.NTID='" + NTID + "'";
            }
            if (!string.IsNullOrEmpty(Project))
            {
                sql += " AND B.Project='" + Project + "'";
            }
            if (!string.IsNullOrEmpty(Department))
            {
                sql += " AND B.Department='" + Department + "'";
            }
            sql += " ORDER BY ExamType) D, (SELECT @i:= 0) AS A";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_User(string examType, string NTID, string Project, string Department,string UserLevel)
        {
            string mesg = "Add User success!";
            string sql = "INSERT into userlist(ExamType,NTID,Department,Project,UserLevel) VALUES('" + examType + "','" + NTID + "','" + Department + "','" + Project + "','" + UserLevel + "')";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add User fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Update_User(string ID,string examType, string NTID, string Project, string Department, string UserLevel)
        {
            string mesg = "Update User success!";
            string sql = "UPDATE userlist SET ExamType='" + examType + "',NTID='" + NTID + "',Department='" + Department + "',Project='" + Project + "',UserLevel='" + UserLevel + "' WHERE ID='" + ID + "'";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Update User fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_User(string ID)
        {
            string mesg = "Delete User success!";
            string sql = "DELETE FROM userlist WHERE ID='" + ID + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete User fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region questionlist(select insert update delete)
        public DataTable GetQuestion_Table(string ExamType,string QuestionType)
        {
            string sql = @"SELECT (@i:= @i + 1) AS IndexID,D.* FROM
                            (SELECT B.ID, C.ExamName AS ExamType, B.Question, B.QuestionType, B.Select1, B.Select2, B.Select3, B.Select4 FROM questionlist B INNER JOIN examconfig C on B.ExamType = C.ExamID WHERE 1 ";
            if (!string.IsNullOrEmpty(ExamType))
            {
                sql += " and B.ExamType='" + ExamType + "'";
            }
            if (!string.IsNullOrEmpty(QuestionType))
            {
                sql += " and B.QuestionType='" + QuestionType + "'";
            }
            sql+= " ORDER BY ExamType) D,(SELECT @i:= 0) as A  ";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Add_Question(string ExamType, string question, string questionType, string s1, string s2, string s3, string s4) 
        {
            string mesg = "Add Question success!";
            string sql = "INSERT INTO questionlist (ExamType,Question,QuestionType,Select1,Select2,Select3,Select4) VALUES ('" + ExamType + "','" + question + "','" + questionType + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "')";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Add PowerUser fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Update_Question(string ID,string ExamType, string question, string questionType, string s1, string s2, string s3 = "", string s4 = "")
        {
            string mesg = "Update Question success!";
            string sql = "UPDATE questionlist SET ExamType='" + ExamType + "',Question='" + question + "',QuestionType='" + questionType + "',Select1='" + s1 + "',Select2='" + s2 + "',Select3='" + s3 + "',Select4='" + s4 + "' WHERE ID='" + ID + "'";
            try
            {
                sp.Insert(sql);
            }
            catch (Exception e)
            {
                mesg = "Update Question fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_Question(string ID)
        {
            string mesg = "Delete Question success!";
            string sql = "DELETE FROM questionlist WHERE ID='" + ID + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete Question fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion

        #region examscore (select replace delete)
        public DataTable GetExamScore_Table(string examtype, string NTID)
        {
            string sql = "SELECT (@i:= @i+1) AS IndexID, B.* FROM examscore B,(SELECT @i:= 0) as A WHERE 1 ";
            if (!string.IsNullOrEmpty(examtype))
            {
                sql += " AND B.ExamType='" + examtype + "'";
            }
            if (!string.IsNullOrEmpty(NTID))
            {
                sql += " AND B.NTID='" + NTID + "'";
            }
            sql += " ORDER by ExamType,ExamTime DESC";
            DataTable dt = sp.Query(sql);
            return dt;
        }
        public string Replace_ExamScore(string ExamType, string NTID, string Score)
        {
            string mesg = "Update Score success!";
            string ExamTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string sql = "REPLACE into examscore (ExamType,NTID,Score,ExamTime) VALUES('" + ExamType + "','" + NTID + "','" + Score + "','" + ExamTime + "')";
            try
            {
                sp.Update(sql);
            }
            catch (Exception e)
            {
                mesg = "Update Score fail!\n" + e.Message;
            }
            return mesg;
        }
        public string Delete_ExamScore(string ExamType, string NTID)
        {
            string mesg = "Delete Score success!";
            string sql = "DELETE FROM examscore WHERE ExamType='" + ExamType + "' and NTID='" + NTID + "'";
            try
            {
                sp.Delete(sql);
            }
            catch (Exception e)
            {
                mesg = "Delete Score fail!\n" + e.Message;
            }
            return mesg;
        }
        #endregion
    }
}