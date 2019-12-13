﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class Auth
    {
        private ADHelper ad = new ADHelper();
        private static string domain = "corp.jabil.org";
        private ManageDatabase sp = new ManageDatabase();
        private DataTable userlist = new DataTable();
        private DataTable poweruser = new DataTable();
        private UserInfo userinfo = new UserInfo();

        //检查用户登录权限
        public bool CheckNTIDAuth(string ntid,string password)
        {
            ad.Domain = domain;
            ad.UserName = ntid;
            ad.Password = password;
            if (ad.TryAuthenticate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取用户信息
        public UserInfo GetUserInfo(string ntid, string role, string examtype)
        {
            userinfo.NTID = ntid;
            userinfo.DisplayName = ad.GetADDispalyName(ntid);
            if (IsPowerUser(ntid))
            {
                userinfo.UserGroup = (UserGroupEnum)(Enum.Parse(typeof(UserGroupEnum), "Power"));
                userinfo.ExamType = Int32.Parse(examtype);
            }
            else {
                if (examtype != "0") //不是 _blank
                {
                    if (IsJoinExam(ntid, examtype))
                    {
                        userinfo.ExamType = Int32.Parse(examtype);
                        userinfo.UserGroup = (UserGroupEnum)(Enum.Parse(typeof(UserGroupEnum), userlist.Rows[0]["UserLevel"].ToString()));
                    }
                    else
                    {
                        userinfo.ExamType = 999999;  //Error
                    }
                }
                else
                {
                    userinfo.ExamType = 999999;  //Error
                }
            }
            return userinfo;
        }

        //检查用户是否参加了这门考试
        private bool IsJoinExam(string ntid, string examtype)
        {
            string sql = "select * from userlist where ExamType='" + examtype + "' and NTID='" + ntid + "'";
            userlist = sp.Query(sql);
            if(userlist.Rows.Count>0)
                return true;
            return false;
        }
        //是不是power权限用户
        private bool IsPowerUser(string ntid)
        {
            string sql = "select * from poweruser where NTID='" + ntid + "'";
            poweruser = sp.Query(sql);
            if (poweruser.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
