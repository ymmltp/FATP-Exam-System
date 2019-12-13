
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class Auth
    {
        private static DAL.Auth ad = new DAL.Auth();
        public static bool CheckNTIDAuth(string ntid, string password)
        {
            return ad.CheckNTIDAuth(ntid, password);
        }
        public static UserInfo GetUserInfo(string ntid,string role, string examtype)
        {
            return ad.GetUserInfo(ntid, role, examtype);
        }
    }
}
