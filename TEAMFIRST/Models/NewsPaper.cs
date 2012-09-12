using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Models
{
    public class NewsPaper
    {
        private int newsId;
        public int NewsId
        {
            get { return newsId; }
            set { newsId = value; }
        }

        private string newsTitle;
        public string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }

        private string newsContent;
        public string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }

        private DateTime addTime;
        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }

        private int state;
        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}