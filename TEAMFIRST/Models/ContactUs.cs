using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Models
{
    public class ContactUs
    {
        private int infoId;
        public int InfoId
        {
            get { return infoId; }
            set { infoId = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private string msgContent;
        public string MsgContent
        {
            get { return msgContent; }
            set { msgContent = value; }
        }

        private DateTime addTime;
        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
    }
}