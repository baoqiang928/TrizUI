using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class UserProjectInfo
    {
        int? id;
        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private int projectID;
        public int ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private DateTime? createDateTime;

        public DateTime? CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }

    }
}


