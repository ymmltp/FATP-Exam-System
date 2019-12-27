namespace Model
{
    public enum UserGroupEnum
    {
        User = 1,
        Admin = 3,
        Power = 7,
    }

    public class UserInfo
    {
        private string _NTID;
        private string _DisplayName;
        private string _Email;
        private string _PhoneNumber;
        private bool _MailEnable;
        private bool _SMSEnable;
        private int _ExamType;
        private string _Project;
        private string _Department;
        private UserGroupEnum _userGroup;

        public UserInfo()
        { }

        public UserInfo(string ntid, string fullname,string email,string phonenumber,bool mailenable,bool smsenable, string department,string project, int examType, UserGroupEnum userGroup)
        {
            this._NTID = ntid;
            this._DisplayName = fullname;
            this._Email = email;
            this._PhoneNumber = phonenumber;
            this._MailEnable = mailenable;
            this._SMSEnable = smsenable;
            this._Department = department;
            this._Project = project;
            this._ExamType = examType;
            this._userGroup = userGroup;
        }

        public UserGroupEnum UserGroup
        {
            get
            {
                return this._userGroup;
            }
            set
            {
                this._userGroup = value;
            }
        }
        public string NTID
        {
            get
            {
                return this._NTID;
            }
            set
            {
                this._NTID = value;
            }
        }
        public string DisplayName
        {
            get
            {
                return this._DisplayName;
            }
            set
            {
                this._DisplayName = value;
            }
        }
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this._PhoneNumber;
            }
            set
            {
                this._PhoneNumber = value;
            }
        }
        public bool MailEnable
        {
            get
            {
                return this._MailEnable;
            }
            set
            {
                this._MailEnable = value;
            }
        }
        public bool SMSEnable
        {
            get
            {
                return this._SMSEnable;
            }
            set
            {
                this._SMSEnable = value;
            }
        }
        public string Department
        {
            get
            {
                return this._Department;
            }
            set
            {
                this._Department = value;
            }
        }
        public string Project
        {
            get
            {
                return this._Project;
            }
            set
            {
                this._Project = value;
            }
        }
        public int ExamType
        {
            get
            {
                return this._ExamType;
            }
            set
            {
                this._ExamType = value;
            }
        }
    }
}
