using System.Collections.Generic;
using System.DirectoryServices;

namespace DAL {
    /// 
    /// 活动目录辅助类。封装一系列活动目录操作相关的方法。
    /// 
    public class ADHelper
    {
        private string domain;
        private string username;
        private string password;

        public ADHelper()
        { }

        public string Domain
        {
            get { return this.domain; }
            set { this.domain = value; }
        }

        public string UserName
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        /// <summary>                                   
        /// 验证AD用户是否登录成功
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool TryAuthenticate(string domain, string userName, string password)
        {
            bool isLogin = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}", domain), userName, password);
                entry.RefreshCache();
                isLogin = true;
            }
            catch
            {
                isLogin = false;
            }
            return isLogin;
        }

        public bool TryAuthenticate()
        {
            return TryAuthenticate(domain, username, password);
        }

        /// <summary>
        /// 取 userName 所对应的 Groups
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<string> GetADGroups(string userName)
        {
            List<string> groups = new List<string>();
            try
            {
                var entry = new DirectoryEntry(string.Format("LDAP://{0}", domain), username, password);
                entry.RefreshCache();

                DirectorySearcher search = new DirectorySearcher(entry);

                search.PropertiesToLoad.Add("memberof");
                search.Filter = string.Format("sAMAccountName={0}", userName);

                SearchResult result = search.FindOne();
                if (result != null)
                {
                    ResultPropertyValueCollection c = result.Properties["memberof"];
                    foreach (var a in c)
                    {
                        string temp = a.ToString();
                        //Match match = Regex.Match(temp, @"CN=\s*(?<g>\w*)\s*.");
                        //groups.Add(match.Groups["g"].Value);
                        groups.Add(temp);
                    }
                }
            }
            catch { }
            return groups;
        }

        /// <summary>
        /// 取 userName 所对应的 Display name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetADDispalyName(string userName)
        {
            string displayname = string.Empty;
            try
            {
                var entry = new DirectoryEntry(string.Format("LDAP://{0}", domain));
                entry.RefreshCache();

                DirectorySearcher search = new DirectorySearcher(entry);

                search.PropertiesToLoad.Add("DisplayName");
                search.Filter = string.Format("sAMAccountName={0}", userName);

                SearchResult result = search.FindOne();
                displayname = result.Properties["DisplayName"][0].ToString();
            }
            catch { }
            return displayname;
        }

        /// <summary>
        /// 取 userName 所对应的 Office
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetADOffice(string userName)
        {
            string office = string.Empty;
            try
            {
                var entry = new DirectoryEntry(string.Format("LDAP://{0}", domain), username, password);
                entry.RefreshCache();

                DirectorySearcher search = new DirectorySearcher(entry);

                search.PropertiesToLoad.Add("st");
                search.Filter = string.Format("sAMAccountName={0}", userName);

                SearchResult result = search.FindOne();
                office = result.Properties["st"][0].ToString();
            }
            catch { }
            return office;
        }

        public string GetNTIDByDisplayName(string displayname)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}", domain));
                entry.RefreshCache();
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("displayName={0}", displayname);
                if (search.FindOne() != null)
                    return search.FindOne().Properties["sAMAccountName"][0].ToString();
                else
                    return null;
            }
            catch { return null; }
        }

        public bool NTIDExist(string ntid)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}", domain));
                entry.RefreshCache();
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("sAMAccountName={0}", ntid);
                if (search.FindOne() != null)
                    return true;
                else
                    return false;
                //{
                //    search.Filter = string.Format("displayName={0}", ntid);
                //    if (search.FindOne() != null)
                //        return true;
                //    else
                //        return false;
                //}
            }
            catch { return false; }
        }
    }
}
